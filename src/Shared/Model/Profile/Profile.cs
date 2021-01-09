using System;
using VerusDate.Shared.Core;
using VerusDate.Shared.Enum;
using VerusDate.Shared.Helper;
using static VerusDate.Shared.Helper.ImageHelper;

namespace VerusDate.Shared.Model.Profile
{
    public class Profile : CosmosBase
    {
        public Profile() : base(nameof(Profile))
        {
        }

        public DateTimeOffset? DtTopList { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? DtLastLogin { get; set; } = DateTimeOffset.UtcNow;

        private readonly string BlobPath = "https://storageverusdate.blob.core.windows.net";

        public ProfileBasic Basic { get; set; }
        public ProfileBio Bio { get; set; }
        public ProfileLifestyle Lifestyle { get; set; }
        public ProfileLooking Looking { get; set; }
        public ProfileGamification Gamification { get; set; }
        public ProfileBadge Badge { get; set; }
        public ProfilePhoto Photo { get; set; }

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
                Lifestyle.Drink = null;
                Lifestyle.Smoke = null;
                Lifestyle.Diet = null;
                Lifestyle.HaveChildren = null;
                Lifestyle.WantChildren = null;
                Lifestyle.EducationLevel = null;
                Lifestyle.CareerCluster = null;
                Lifestyle.Religion = null;
                Lifestyle.MoneyPersonality = null;
                Lifestyle.RelationshipPersonality = null;
                Lifestyle.MyersBriggsTypeIndicator = null;
                Lifestyle.Hobbies = Array.Empty<string>();
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

        public ActivityStatus GetActivityStatus()
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

        public string GetMainPhoto()
        {
            if (Photo == null || string.IsNullOrEmpty(Photo.Main))
                return GetNoUserPhoto;
            else
                return $"{BlobPath}/{GetPhotoContainer(PhotoType.PhotoFace)}/{Photo.Main}";
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

        public override void SetIds(string IdLoggedUser)
        {
            this.Id = IdLoggedUser;
            this.Key = IdLoggedUser;
        }
    }

    public class ProfileView : Profile
    {
        public ActivityStatus ActivityStatus { get; set; }
        public double Distance { get; set; }
    }
}