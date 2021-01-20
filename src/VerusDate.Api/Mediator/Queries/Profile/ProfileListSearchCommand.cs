using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
            var user = await _repo.Get<ProfileModel>(request.Id, new PartitionKey(request.IdLoggedUser), cancellationToken);
            var looking = user?.Looking;

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

            //BASIC
            SQL.Append("	AND ROUND(ST_DISTANCE({'type': 'Point', 'coordinates':[@latitude, @longitude]},{'type': 'Point', 'coordinates':[c.basic.latitude, c.basic.longitude]}) / @valueCalDistance) <= @distance ");
            filter.Add("@latitude", user.Basic.Latitude);
            filter.Add("@longitude", user.Basic.Longitude);
            filter.Add("@valueCalDistance", valueCalDistance);
            filter.Add("@distance", user.Looking.Distance);

            if (looking.MaritalStatus.HasValue)
            {
                SQL.Append("	AND c.basic.maritalStatus = @maritalStatus ");
                filter.Add("@maritalStatus", (int)looking.MaritalStatus.Value);
            }
            SQL.Append("    AND EXISTS(SELECT VALUE n FROM n IN c.basic.intent WHERE n in (" + string.Join(",", user.Looking.Intent.Cast<int>()) + ")) ");
            if (looking.BiologicalSex.HasValue)
            {
                SQL.Append("	AND c.basic.biologicalSex = @biologicalSex ");
                filter.Add("@biologicalSex", (int)looking.BiologicalSex.Value);
            }
            if (looking.GenderIdentity.HasValue)
            {
                SQL.Append("	AND c.basic.genderIdentity = @genderIdentity ");
                filter.Add("@genderIdentity", (int)looking.GenderIdentity.Value);
            }
            if (looking.SexualOrientation.HasValue)
            {
                SQL.Append("	AND c.basic.sexualOrientation = @sexualOrientation ");
                filter.Add("@sexualOrientation", (int)looking.SexualOrientation.Value);
            }

            //BIO
            SQL.Append("    AND TRUNC(DateTimeDiff('month',c.bio.birthDate,GetCurrentDateTime())/12) >= @minAge ");
            SQL.Append("    AND TRUNC(DateTimeDiff('month',c.bio.birthDate,GetCurrentDateTime())/12) <= @maxAge ");
            filter.Add("@minAge", user.Looking.MinimalAge);
            filter.Add("@maxAge", user.Looking.MaxAge);
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
            if (looking.RaceCategory.HasValue)
            {
                SQL.Append("	AND c.bio.raceCategory = @RaceCategory ");
                filter.Add("@RaceCategory", (int)looking.RaceCategory.Value);
            }
            if (looking.BodyMass.HasValue)
            {
                SQL.Append("	AND c.bio.bodyMass = @BodyMass ");
                filter.Add("@BodyMass", (int)looking.BodyMass.Value);
            }

            //LIFESTYLE
            if (looking.Drink.HasValue)
            {
                SQL.Append("	AND c.lifestyle.drink = @Drink ");
                filter.Add("@Drink", (int)looking.Drink.Value);
            }
            if (looking.Smoke.HasValue)
            {
                SQL.Append("	AND c.lifestyle.smoke = @Smoke ");
                filter.Add("@Smoke", (int)looking.Smoke.Value);
            }
            if (looking.Diet.HasValue)
            {
                SQL.Append("	AND c.lifestyle.diet = @Diet ");
                filter.Add("@Diet", (int)looking.Diet.Value);
            }
            if (looking.HaveChildren.HasValue)
            {
                SQL.Append("	AND c.lifestyle.haveChildren = @HaveChildren ");
                filter.Add("@HaveChildren", (int)looking.HaveChildren.Value);
            }
            if (looking.WantChildren.HasValue)
            {
                SQL.Append("	AND c.lifestyle.wantChildren = @WantChildren ");
                filter.Add("@WantChildren", (int)looking.WantChildren.Value);
            }
            if (looking.EducationLevel.HasValue)
            {
                SQL.Append("	AND c.lifestyle.educationLevel = @EducationLevel ");
                filter.Add("@EducationLevel", (int)looking.EducationLevel.Value);
            }
            if (looking.CareerCluster.HasValue)
            {
                SQL.Append("	AND c.lifestyle.careerCluster = @CareerCluster ");
                filter.Add("@CareerCluster", (int)looking.CareerCluster.Value);
            }
            if (looking.Religion.HasValue)
            {
                SQL.Append("	AND c.lifestyle.religion = @Religion ");
                filter.Add("@Religion", (int)looking.Religion.Value);
            }

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