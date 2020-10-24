using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Server.Core.Interface;
using VerusDate.Shared.Helper;
using VerusDate.Shared.Interface.App;
using VerusDate.Shared.ViewModel;
using static VerusDate.Shared.Helper.ProfileHelper;

namespace RealDate.Data.App
{
    public class ProfileApp : IProfileApp
    {
        private readonly IRepository _repos;

        public ProfileApp(IRepository repos)
        {
            _repos = repos;
        }

        public async Task<ProfileUserVM> GetUser(string ProfileId, CancellationToken cancellationToken)
        {
            return await repRead.Get<ProfileUserVM>(ProfileId, cancellationToken);
        }

        public async Task<ProfileViewVM> GetView(string IdUser, string IdUserView, CancellationToken cancellationToken)
        {
            var SQL = new StringBuilder();

            var typeDistance = DistanceType.Km;
            var valueCalDistance = typeDistance == DistanceType.Km ? 1000 : 1609;

            SQL.Append("SELECT ");
            SQL.Append("	P.* ");
            SQL.Append($"  , ROUND(geography::Point(P.Latitude, P.Longitude, 4326).STDistance(geography::Point(PV.Latitude, PV.Longitude, 4326)) / {valueCalDistance}, 1) Distance ");
            SQL.Append("  , PP.PhotoFace ");
            SQL.Append("  , CASE ");
            SQL.Append("		WHEN CAST(P.DtLastLogin AS DATE)  = CAST(GETDATE() AS DATE) THEN 0 ");
            SQL.Append("		WHEN CAST(P.DtLastLogin AS DATE) >= CAST(GETDATE()-7 AS DATE) THEN 1 ");
            SQL.Append("		WHEN CAST(P.DtLastLogin AS DATE) >= CAST(GETDATE()-30 AS DATE) THEN 2 ");
            SQL.Append("		ELSE 3 ");
            SQL.Append("	END ActivityStatus ");
            SQL.Append("FROM ");
            SQL.Append("	Profile                  P ");
            SQL.Append("	INNER JOIN ProfilePhotos PP ON P.Id  = PP.Id ");
            SQL.Append("	INNER JOIN Profile       PV ON PV.Id = @IdUser ");
            SQL.Append("WHERE ");
            SQL.Append("    P.ID = @IdUserView");

            return await repRead.GetCustom<ProfileViewVM>(SQL.ToString(), new { IdUser, IdUserView }, cancellationToken);
            //return await repRead.GetCustom<ProfileVM>("SELECT @p.Serialize() as location", new { p = new Point(47, 52) { SRID = 4326 } });
        }

        public async Task<IEnumerable<ProfileViewVM>> GetListMatch(ProfileLookingVM looking, CancellationToken cancellationToken)
        {
            if (looking == null) throw new NotificationException("Critérios de busca ainda não definidos");

            var typeDistance = DistanceType.Km;
            var valueCalDistance = typeDistance == DistanceType.Km ? 1000 : 1609;

            dynamic param = new System.Dynamic.ExpandoObject();

            param.Id = looking.Id;
            param.Distance = looking.Distance;
            param.MinimalAge = looking.MinimalAge;
            param.MaxAge = looking.MaxAge;
            param.Intent = looking.Intent;

            var SQL = new StringBuilder();

            SQL.Append("SELECT ");
            SQL.Append("	TOP 20 P.Id ");
            SQL.Append("  , P.NickName ");
            SQL.Append("  , P.BirthDate ");
            SQL.Append("  , P.BiologicalSex ");
            SQL.Append("  , P.MaritalStatus ");
            SQL.Append("  , P.Intent ");
            SQL.Append("  , P.GenderIdentity ");
            SQL.Append("  , P.SexualOrientation ");
            SQL.Append("  , P.Smoke ");
            SQL.Append("  , P.Drink ");
            SQL.Append("  , P.Height ");
            SQL.Append("  , P.BodyMass ");
            SQL.Append("  , P.RaceCategory ");
            SQL.Append("  , P.Diet ");
            SQL.Append("  , P.HaveChildren ");
            SQL.Append("  , P.WantChildren ");
            SQL.Append("  , P.Religion ");
            SQL.Append("  , P.EducationLevel ");
            SQL.Append("  , P.CareerCluster ");
            SQL.Append("  , P.MoneyPersonality ");
            SQL.Append("  , P.PersonalityTraits ");
            SQL.Append("  , P.RelationshipPersonality ");
            SQL.Append("  , P.City ");
            SQL.Append($"  , ROUND(geography::Point(P.Latitude, P.Longitude, 4326).STDistance(geography::Point(PV.Latitude, PV.Longitude, 4326)) / {valueCalDistance}, 1) Distance ");
            SQL.Append("  , PP.PhotoFace ");
            SQL.Append("  , CASE ");
            SQL.Append("		WHEN CAST(P.DtLastLogin AS DATE)  = CAST(GETDATE() AS DATE) THEN 0 ");
            SQL.Append("		WHEN CAST(P.DtLastLogin AS DATE) >= CAST(GETDATE()-7 AS DATE) THEN 1 ");
            SQL.Append("		WHEN CAST(P.DtLastLogin AS DATE) >= CAST(GETDATE()-30 AS DATE) THEN 2 ");
            SQL.Append("		ELSE 3 ");
            SQL.Append("	END ActivityStatus ");
            SQL.Append("FROM ");
            SQL.Append("	Profile                  P ");
            SQL.Append("	INNER JOIN ProfilePhotos PP ON P.Id  = PP.Id ");
            SQL.Append("	INNER JOIN Profile       PV ON PV.Id = @Id ");
            SQL.Append("WHERE ");
            SQL.Append("	P.Id != @Id ");
            //SQL.Append("	AND P.MinimalAge >= @MinimalAge AND P.MaxAge <= @MaxAge ");
            SQL.Append("	AND P.Intent IN @Intent ");

            if (looking.BiologicalSex.HasValue)
            {
                SQL.Append("	AND P.BiologicalSex = @BiologicalSex ");
                param.BiologicalSex = (int)looking.BiologicalSex.Value;
            }
            if (looking.MaritalStatus.HasValue)
            {
                SQL.Append("	AND P.MaritalStatus = @MaritalStatus ");
                param.MaritalStatus = (int)looking.MaritalStatus.Value;
            }
            if (looking.GenderIdentity.HasValue)
            {
                SQL.Append("	AND P.GenderIdentity = @GenderIdentity ");
                param.GenderIdentity = (int)looking.GenderIdentity.Value;
            }
            if (looking.SexualOrientation.HasValue)
            {
                SQL.Append("	AND P.SexualOrientation = @SexualOrientation ");
                param.SexualOrientation = (int)looking.SexualOrientation.Value;
            }
            if (looking.Smoke.HasValue)
            {
                SQL.Append("	AND P.Smoke = @Smoke ");
                param.Smoke = (int)looking.Smoke.Value;
            }
            if (looking.Drink.HasValue)
            {
                SQL.Append("	AND P.Drink = @Drink ");
                param.Drink = (int)looking.Drink.Value;
            }
            if (looking.MinimalHeight.HasValue)
            {
                SQL.Append("	AND P.Height >= @MinimalHeight ");
                param.MinimalHeight = (int)looking.MinimalHeight.Value;
            }
            if (looking.MaxHeight.HasValue)
            {
                SQL.Append("	AND P.Height <= @MaxHeight ");
                param.MaxHeight = (int)looking.MaxHeight.Value;
            }
            if (looking.BodyMass.HasValue)
            {
                SQL.Append("	AND P.BodyMass = @BodyMass ");
                param.BodyMass = (int)looking.BodyMass.Value;
            }
            if (looking.RaceCategory.HasValue)
            {
                SQL.Append("	AND P.RaceCategory = @RaceCategory ");
                param.RaceCategory = (int)looking.RaceCategory.Value;
            }
            if (looking.HaveChildren.HasValue)
            {
                SQL.Append("	AND P.HaveChildren = @HaveChildren ");
                param.HaveChildren = (int)looking.HaveChildren.Value;
            }
            if (looking.WantChildren.HasValue)
            {
                SQL.Append("	AND P.WantChildren = @WantChildren ");
                param.WantChildren = (int)looking.WantChildren.Value;
            }
            if (looking.Religion.HasValue)
            {
                SQL.Append("	AND P.Religion = @Religion ");
                param.Religion = (int)looking.Religion.Value;
            }
            if (looking.EducationLevel.HasValue)
            {
                SQL.Append("	AND P.EducationLevel = @EducationLevel ");
                param.EducationLevel = (int)looking.EducationLevel.Value;
            }
            if (looking.CareerCluster.HasValue)
            {
                SQL.Append("	AND P.CareerCluster = @CareerCluster ");
                param.CareerCluster = (int)looking.CareerCluster.Value;
            }
            if (looking.MoneyPersonality.HasValue)
            {
                SQL.Append("	AND P.MoneyPersonality = @MoneyPersonality ");
                param.MoneyPersonality = (int)looking.MoneyPersonality.Value;
            }
            if (looking.PersonalityTraits.HasValue)
            {
                SQL.Append("	AND P.PersonalityTraits = @PersonalityTraits ");
                param.PersonalityTraits = (int)looking.PersonalityTraits.Value;
            }
            if (looking.RelationshipPersonality.HasValue)
            {
                SQL.Append("	AND P.RelationshipPersonality = @RelationshipPersonality ");
                param.RelationshipPersonality = (int)looking.RelationshipPersonality.Value;
            }

            SQL.Append($"	AND ROUND(geography::Point(P.Latitude, P.Longitude, 4326).STDistance(geography::Point(PV.Latitude, PV.Longitude, 4326)) / {valueCalDistance}, 1) <= @Distance ");
            SQL.Append("ORDER BY ");
            SQL.Append("	P.DtTopList DESC");

            return await repRead.Query<ProfileViewVM>(SQL.ToString(), param);
        }

        public async Task<IEnumerable<ProfileViewVM>> GetListSearch(ProfileLookingVM looking, CancellationToken cancellationToken)
        {
            if (looking == null) throw new NotificationException("Critérios de busca ainda não definidos");

            var typeDistance = DistanceType.Km;
            var valueCalDistance = typeDistance == DistanceType.Km ? 1000 : 1609;

            dynamic param = new System.Dynamic.ExpandoObject();

            param.Id = looking.Id;
            param.Distance = looking.Distance;
            param.MinimalAge = looking.MinimalAge;
            param.MaxAge = looking.MaxAge;
            param.Intent = looking.Intent;

            var SQL = new StringBuilder();

            SQL.Append("SELECT ");
            SQL.Append("	TOP 20 P.Id ");
            SQL.Append("  , P.NickName ");
            SQL.Append("  , P.BirthDate ");
            SQL.Append("  , P.BiologicalSex ");
            SQL.Append("  , P.MaritalStatus ");
            SQL.Append("  , P.Intent ");
            SQL.Append("  , P.GenderIdentity ");
            SQL.Append("  , P.SexualOrientation ");
            SQL.Append("  , P.Smoke ");
            SQL.Append("  , P.Drink ");
            SQL.Append("  , P.Height ");
            SQL.Append("  , P.BodyMass ");
            SQL.Append("  , P.RaceCategory ");
            SQL.Append("  , P.Diet ");
            SQL.Append("  , P.HaveChildren ");
            SQL.Append("  , P.WantChildren ");
            SQL.Append("  , P.Religion ");
            SQL.Append("  , P.EducationLevel ");
            SQL.Append("  , P.CareerCluster ");
            SQL.Append("  , P.MoneyPersonality ");
            SQL.Append("  , P.PersonalityTraits ");
            SQL.Append("  , P.RelationshipPersonality ");
            SQL.Append("  , P.City ");
            SQL.Append($"  , ROUND(geography::Point(P.Latitude, P.Longitude, 4326).STDistance(geography::Point(PV.Latitude, PV.Longitude, 4326)) / {valueCalDistance}, 1) Distance ");
            SQL.Append("  , PP.PhotoFace ");
            SQL.Append("  , CASE ");
            SQL.Append("		WHEN CAST(P.DtLastLogin AS DATE)  = CAST(GETDATE() AS DATE) THEN 0 ");
            SQL.Append("		WHEN CAST(P.DtLastLogin AS DATE) >= CAST(GETDATE()-7 AS DATE) THEN 1 ");
            SQL.Append("		WHEN CAST(P.DtLastLogin AS DATE) >= CAST(GETDATE()-30 AS DATE) THEN 2 ");
            SQL.Append("		ELSE 3 ");
            SQL.Append("	END ActivityStatus ");
            SQL.Append("FROM ");
            SQL.Append("	Profile                  P ");
            SQL.Append("	INNER JOIN ProfilePhotos PP ON P.Id  = PP.Id ");
            SQL.Append("	INNER JOIN Profile       PV ON PV.Id = @Id ");
            SQL.Append("WHERE ");
            SQL.Append("	P.Id != @Id ");
            //SQL.Append("	AND P.MinimalAge >= @MinimalAge AND P.MaxAge <= @MaxAge ");
            SQL.Append("	AND P.Intent IN @Intent ");

            if (looking.BiologicalSex.HasValue)
            {
                SQL.Append("	AND P.BiologicalSex = @BiologicalSex ");
                param.BiologicalSex = (int)looking.BiologicalSex.Value;
            }
            if (looking.MaritalStatus.HasValue)
            {
                SQL.Append("	AND P.MaritalStatus = @MaritalStatus ");
                param.MaritalStatus = (int)looking.MaritalStatus.Value;
            }
            if (looking.GenderIdentity.HasValue)
            {
                SQL.Append("	AND P.GenderIdentity = @GenderIdentity ");
                param.GenderIdentity = (int)looking.GenderIdentity.Value;
            }
            if (looking.SexualOrientation.HasValue)
            {
                SQL.Append("	AND P.SexualOrientation = @SexualOrientation ");
                param.SexualOrientation = (int)looking.SexualOrientation.Value;
            }
            if (looking.Smoke.HasValue)
            {
                SQL.Append("	AND P.Smoke = @Smoke ");
                param.Smoke = (int)looking.Smoke.Value;
            }
            if (looking.Drink.HasValue)
            {
                SQL.Append("	AND P.Drink = @Drink ");
                param.Drink = (int)looking.Drink.Value;
            }
            if (looking.MinimalHeight.HasValue)
            {
                SQL.Append("	AND P.Height >= @MinimalHeight ");
                param.MinimalHeight = (int)looking.MinimalHeight.Value;
            }
            if (looking.MaxHeight.HasValue)
            {
                SQL.Append("	AND P.Height <= @MaxHeight ");
                param.MaxHeight = (int)looking.MaxHeight.Value;
            }
            if (looking.BodyMass.HasValue)
            {
                SQL.Append("	AND P.BodyMass = @BodyMass ");
                param.BodyMass = (int)looking.BodyMass.Value;
            }
            if (looking.RaceCategory.HasValue)
            {
                SQL.Append("	AND P.RaceCategory = @RaceCategory ");
                param.RaceCategory = (int)looking.RaceCategory.Value;
            }
            if (looking.HaveChildren.HasValue)
            {
                SQL.Append("	AND P.HaveChildren = @HaveChildren ");
                param.HaveChildren = (int)looking.HaveChildren.Value;
            }
            if (looking.WantChildren.HasValue)
            {
                SQL.Append("	AND P.WantChildren = @WantChildren ");
                param.WantChildren = (int)looking.WantChildren.Value;
            }
            if (looking.Religion.HasValue)
            {
                SQL.Append("	AND P.Religion = @Religion ");
                param.Religion = (int)looking.Religion.Value;
            }
            if (looking.EducationLevel.HasValue)
            {
                SQL.Append("	AND P.EducationLevel = @EducationLevel ");
                param.EducationLevel = (int)looking.EducationLevel.Value;
            }
            if (looking.CareerCluster.HasValue)
            {
                SQL.Append("	AND P.CareerCluster = @CareerCluster ");
                param.CareerCluster = (int)looking.CareerCluster.Value;
            }
            if (looking.MoneyPersonality.HasValue)
            {
                SQL.Append("	AND P.MoneyPersonality = @MoneyPersonality ");
                param.MoneyPersonality = (int)looking.MoneyPersonality.Value;
            }
            if (looking.PersonalityTraits.HasValue)
            {
                SQL.Append("	AND P.PersonalityTraits = @PersonalityTraits ");
                param.PersonalityTraits = (int)looking.PersonalityTraits.Value;
            }
            if (looking.RelationshipPersonality.HasValue)
            {
                SQL.Append("	AND P.RelationshipPersonality = @RelationshipPersonality ");
                param.RelationshipPersonality = (int)looking.RelationshipPersonality.Value;
            }

            SQL.Append($"	AND ROUND(geography::Point(P.Latitude, P.Longitude, 4326).STDistance(geography::Point(PV.Latitude, PV.Longitude, 4326)) / {valueCalDistance}, 1) <= @Distance ");
            SQL.Append("ORDER BY ");
            SQL.Append("	P.DtTopList DESC");

            return await repRead.Query<ProfileViewVM>(SQL.ToString(), param, cancellationToken);
        }

        public async Task<bool> Add(ProfileUserVM obj, CancellationToken cancellationToken)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return await _repos.Insert(obj);
        }

        public async Task<bool> Update(ProfileUserVM obj, CancellationToken cancellationToken)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            obj.DtUpdate = DateTimeOffset.UtcNow;

            return await repWrite.Update(obj);
        }

        public async Task RegisterLogin(string ProfileId, CancellationToken cancellationToken)
        {
            await repWrite.Update("UPDATE Profile SET DtLastLogin = @DtLastLogin WHERE Id = @ProfileId", new { DtLastLogin = DateTime.Now, ProfileId });
        }
    }
}