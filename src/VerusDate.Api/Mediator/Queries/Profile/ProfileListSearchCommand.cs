using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Core;
using VerusDate.Shared.Helper;
using VerusDate.Shared.Model;
using VerusDate.Shared.ModelQuery;
using static VerusDate.Shared.Helper.ProfileHelper;

namespace VerusDate.Api.Mediator.Queries.Profile
{
    public class ProfileListSearchCommand : MediatorQuery<List<ProfileSearch>>
    {
        public ProfileListSearchCommand() : base(CosmosType.Profile)
        {
        }

        public override void SetParameters(IQueryCollection query)
        {
            //do nothing
        }
    }

    public class ProfileListSearchHandler : IRequestHandler<ProfileListSearchCommand, List<ProfileSearch>>
    {
        private readonly IRepository _repo;

        public ProfileListSearchHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<ProfileSearch>> Handle(ProfileListSearchCommand request, CancellationToken cancellationToken)
        {
            var user = await _repo.Get<ProfileModel>(request.Id, request.IdLoggedUser, cancellationToken);
            var looking = user?.Preference;

            if (looking == null) throw new NotificationException("Critérios de busca ainda não definidos");

            var typeDistance = DistanceType.Km;
            var valueCalDistance = typeDistance == DistanceType.Km ? 1000 : 1609;

            var SQL = new StringBuilder();
            var filter = new Dictionary<string, object>();

            SQL.Append("SELECT TOP 20 ");
            SQL.Append("	c.key as id ");
            SQL.Append("  , c.basic.nickName ");
            SQL.Append("  , c.bio.birthDate ");
            SQL.Append("  , c.looking ");
            SQL.Append("  , c.photo ");
            SQL.Append("  , c.dtLastLogin >= DateTimeAdd('d',-1,GetCurrentDateTime()) ? 1 ");
            SQL.Append("        : c.dtLastLogin >= DateTimeAdd('d',-7,GetCurrentDateTime()) ? 2 ");
            SQL.Append("        : c.dtLastLogin >= DateTimeAdd('m',-1,GetCurrentDateTime()) ? 3 ");
            SQL.Append("        : 4 ");
            SQL.Append("    as ActivityStatus ");
            SQL.Append("  , ROUND(ST_DISTANCE({'type': 'Point', 'coordinates':[@latitude, @longitude]},{'type': 'Point', 'coordinates':[c.basic.latitude, c.basic.longitude]}) / @valueCalDistance) as Distance ");
            SQL.Append("FROM ");
            SQL.Append("	c ");
            SQL.Append("WHERE ");
            SQL.Append("	c.type = " + (int)CosmosType.Profile + " ");
            SQL.Append("    AND c.id != '" + request.Type + ":" + request.IdLoggedUser + "' "); //can't be himself
            SQL.Append("    AND NOT EXISTS (SELECT VALUE t FROM t IN c.passiveInteractions WHERE t = '" + request.IdLoggedUser + "') "); //there can be no interaction with this user

            //TODO: primeiro filtros especificos, depois filtros de intervalo

            // *** BASIC ***

            //if (user.Preference.Distance == Shared.Enum.Distance.Country)
            //{
            //    SQL.Append("	AND SUBSTRING(c.basic.location, 0, INDEX_OF(c.basic.location, ' - ')) = @location ");
            //    filter.Add("@location", user.Basic.GetLocation(LocationType.Country));
            //}
            //else if (user.Preference.Distance == Shared.Enum.Distance.City)
            //{
            //    SQL.Append("	AND c.basic.location = @location ");
            //    filter.Add("@location", user.Basic.Location);
            //}
            //else
            //{
            //SQL.Append("	AND ROUND(ST_DISTANCE({'type': 'Point', 'coordinates':[@latitude, @longitude]},{'type': 'Point', 'coordinates':[c.basic.latitude, c.basic.longitude]}) / @valueCalDistance) <= @distance ");
            //filter.Add("@latitude", user.Latitude);
            //filter.Add("@longitude", user.Longitude);
            //filter.Add("@valueCalDistance", valueCalDistance);
            //filter.Add("@distance", user.Preference.Distance);
            //}

            SQL.AddEnumFilter(looking.CurrentSituation, "c.basic.currentSituation");

            SQL.AddArrayFilter(user.Intentions, "c.basic.intentions");

            SQL.AddEnumFilter(looking.BiologicalSex, "c.basic.biologicalSex");

            SQL.AddEnumFilter(looking.GenderIdentity, "c.basic.genderIdentity");

            SQL.AddEnumFilter(looking.SexualOrientation, "c.basic.sexualOrientation");

            SQL.AddEnumFilter(looking.SexualOrientation, "c.basic.sexualOrientation");

            SQL.AddArrayFilter(looking.Languages, "c.basic.languages");

            // *** BIO ***

            SQL.Append("    AND TRUNC(DateTimeDiff('month',c.bio.birthDate,GetCurrentDateTime())/12) >= @minAge ");
            SQL.Append("    AND TRUNC(DateTimeDiff('month',c.bio.birthDate,GetCurrentDateTime())/12) <= @maxAge ");
            filter.Add("@minAge", user.Preference.MinimalAge);
            filter.Add("@maxAge", user.Preference.MaxAge);

            if (looking.MinimalHeight.HasValue)
            {
                SQL.Append("	AND c.bio.height >= @MinimalHeight ");
                filter.Add("@MinimalHeight", (int)looking.MinimalHeight.Value);
            }
            if (looking.MaxHeight.HasValue)
            {
                SQL.Append("	AND c.bio.height <= @MaxHeight ");
                filter.Add("@MaxHeight", (int)looking.MaxHeight.Value);
            }

            SQL.AddEnumFilter(looking.RaceCategory, "c.bio.raceCategory");

            SQL.AddEnumFilter(looking.BodyMass, "c.bio.bodyMass");

            // *** LIFESTYLE ***

            //if (looking.Drink.HasValue)
            //{
            //    SQL.Append("	AND c.lifestyle.drink = @Drink ");
            //    filter.Add("@Drink", (int)looking.Drink.Value);
            //}
            //if (looking.Smoke.HasValue)
            //{
            //    SQL.Append("	AND c.lifestyle.smoke = @Smoke ");
            //    filter.Add("@Smoke", (int)looking.Smoke.Value);
            //}
            //if (looking.Diet.HasValue)
            //{
            //    SQL.Append("	AND c.lifestyle.diet = @Diet ");
            //    filter.Add("@Diet", (int)looking.Diet.Value);
            //}
            //if (looking.HaveChildren.HasValue)
            //{
            //    SQL.Append("	AND c.lifestyle.haveChildren = @HaveChildren ");
            //    filter.Add("@HaveChildren", (int)looking.HaveChildren.Value);
            //}
            //if (looking.WantChildren.HasValue)
            //{
            //    SQL.Append("	AND c.lifestyle.wantChildren = @WantChildren ");
            //    filter.Add("@WantChildren", (int)looking.WantChildren.Value);
            //}
            //if (looking.EducationLevel.HasValue)
            //{
            //    SQL.Append("	AND c.lifestyle.educationLevel = @EducationLevel ");
            //    filter.Add("@EducationLevel", (int)looking.EducationLevel.Value);
            //}
            //if (looking.CareerCluster.HasValue)
            //{
            //    SQL.Append("	AND c.lifestyle.careerCluster = @CareerCluster ");
            //    filter.Add("@CareerCluster", (int)looking.CareerCluster.Value);
            //}
            //if (looking.Religion.HasValue)
            //{
            //    SQL.Append("	AND c.lifestyle.religion = @Religion ");
            //    filter.Add("@Religion", (int)looking.Religion.Value);
            //}

            SQL.Append("ORDER BY ");
            SQL.Append("	c.dtTopList DESC");

            var query = new QueryDefinition(SQL.ToString());

            foreach (var item in filter)
            {
                query.WithParameter(item.Key, item.Value);
            }

            return await _repo.Query<ProfileSearch>(query, cancellationToken);
        }
    }
}