using Microsoft.Azure.CosmosRepository;
using Newtonsoft.Json;
using System;
using VerusDate.Shared.Enum;
using VerusDate.Shared.Helper;

namespace VerusDate.Shared.Model.Profile
{
    public class Profile : Item
    {
        [JsonProperty("type")]
        public new string Type { get; } = "Profile";

        public DateTimeOffset? DtInsert { get; private set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? DtUpdate { get; private set; }
        public DateTimeOffset? DtTopList { get; private set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? DtLastLogin { get; private set; } = DateTimeOffset.UtcNow;

        [JsonIgnore]
        public ActivityStatus ActivityStatus => GetActivityStatus();

        public ProfileBasic Basic { get; private set; }
        public ProfileBio Bio { get; private set; }
        public ProfileLifestyle Lifestyle { get; private set; }
        public ProfileLooking Looking { get; private set; }
        public ProfileGamification Gamification { get; private set; }
        public ProfileBadge Badge { get; private set; }
        public ProfilePhoto Photo { get; private set; }

        public void UpList()
        {
            DtTopList = DateTimeOffset.UtcNow;
        }

        public void Login()
        {
            DtLastLogin = DateTimeOffset.UtcNow;
        }

        public void UpdateProfile(ProfileBasic basic, ProfileBio bio, ProfileLifestyle lifestyle)
        {
            Basic = basic;
            Bio = bio;
            Lifestyle = lifestyle;

            DtUpdate = DateTimeOffset.UtcNow;
        }

        public void UpdateLooking(ProfileLooking obj)
        {
            Looking = obj;

            DtUpdate = DateTimeOffset.UtcNow;
        }

        public void UpdateGamification(ProfileGamification obj)
        {
            Gamification = obj;

            DtUpdate = DateTimeOffset.UtcNow;
        }

        public void UpdateBadge(ProfileBadge obj)
        {
            Badge = obj;

            DtUpdate = DateTimeOffset.UtcNow;
        }

        public void UpdatePhoto(ProfilePhoto obj)
        {
            Photo = obj;

            DtUpdate = DateTimeOffset.UtcNow;
        }

        public void ClearSimpleView()
        {
            if (Basic.Intent.IsShortTerm(exclusive: true))
            {
                Lifestyle = null;
            }
        }

        public int DaysInsert()
        {
            return ProfileHelper.GetDaysPassed(DtInsert.Value);
        }

        public int DaysUpdate()
        {
            if (!DtUpdate.HasValue) return DaysInsert();

            return ProfileHelper.GetDaysPassed(DtUpdate.Value);
        }

        private ActivityStatus GetActivityStatus()
        {
            if (DtLastLogin.Value.Date == DateTime.Now.Date) return ActivityStatus.Today;
            if (DtLastLogin.Value.Date >= DateTime.Now.Date.AddDays(-7)) return ActivityStatus.Week;
            if (DtLastLogin.Value.Date >= DateTime.Now.Date.AddMonths(-1)) return ActivityStatus.Month;
            else return ActivityStatus.Disabled;
        }

        public double GetDistance(double latitude, double longitude)
        {
            return ProfileHelper.GetDistance(Basic.Latitude.Value, latitude, Basic.Longitude.Value, longitude, ProfileHelper.DistanceType.Km);
        }

        /// <summary>
        /// Use para perfis que não sejam do usuário logado
        /// </summary>
        public void ProtectSensitiveData()
        {
            DtInsert = null;
            DtUpdate = null;
            DtTopList = null;
            DtLastLogin = null;
            Basic.Longitude = null;
            Basic.Latitude = null;
        }
    }
}