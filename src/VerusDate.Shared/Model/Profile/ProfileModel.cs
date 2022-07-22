using System;
using System.Linq;
using VerusDate.Shared.Core;
using VerusDate.Shared.Enum;
using VerusDate.Shared.Helper;
using static VerusDate.Shared.Helper.ImageHelper;

namespace VerusDate.Shared.Model
{
    public class ProfileModel : CosmosBase
    {
        public ProfileModel() : base(CosmosType.Profile)
        {
        }

        public DateTime? DtTopList { get; set; } = DateTime.UtcNow;
        public DateTime? DtLastLogin { get; set; } = DateTime.UtcNow;

        private readonly string BlobPath = "https://storageverusdate.blob.core.windows.net";

        public ProfileBasicModel Basic { get; set; }
        public ProfileBioModel Bio { get; set; }
        public ProfileLifestyleModel Lifestyle { get; set; }
        public ProfileInterestModel Interest { get; set; }
        public ProfilePreferenceModel Preference { get; set; }
        public ProfileGamificationModel Gamification { get; set; }
        public ProfileBadgeModel Badge { get; set; }
        public ProfilePhotoModel Photo { get; set; }
        public ProfileReportModel[] Reports { get; set; } = Array.Empty<ProfileReportModel>();

        //public string[] ActiveInteractions { get; set; } = Array.Empty<string>();
        public string[] PassiveInteractions { get; set; } = Array.Empty<string>();

        public void UpList()
        {
            DtTopList = DateTime.UtcNow;
        }

        public void Login()
        {
            DtLastLogin = DateTime.UtcNow;
        }

        public void UpdateProfile(ProfileBasicModel basic, ProfileBioModel bio, ProfileLifestyleModel lifestyle, ProfileInterestModel interest)
        {
            Basic = basic;
            Bio = bio;
            Lifestyle = lifestyle;
            Interest = interest;

            DtUpdate = DateTime.UtcNow;
        }

        public void UpdateLooking(ProfilePreferenceModel obj)
        {
            Preference = obj;

            DtUpdate = DateTime.UtcNow;
        }

        public void UpdateGamification(ProfileGamificationModel obj)
        {
            Gamification = obj;

            DtUpdate = DateTime.UtcNow;
        }

        public void UpdateBadge(ProfileBadgeModel obj)
        {
            Badge = obj;

            DtUpdate = DateTime.UtcNow;
        }

        public void UpdatePhoto(ProfilePhotoModel obj)
        {
            Photo = obj;

            DtUpdate = DateTime.UtcNow;
        }

        public void ClearSimpleView()
        {
            if (Basic.Intentions.IsShortTerm(exclusive: true))
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

                Interest.Food = null;
                Interest.Vacation = null;
                Interest.Sports = null;
                Interest.LeisureActivities = null;
                Interest.MusicGenre = null;
                Interest.MovieGenre = null;
                Interest.TVGenre = null;
                Interest.ReadingGenre = null;
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

        public string GetMainPhoto()
        {
            if (Photo == null || string.IsNullOrEmpty(Photo.Main))
                return GetNoUserPhoto;
            else
                return $"{BlobPath}/{GetPhotoContainer(PhotoType.PhotoFace)}/{Photo.Main}";
        }

        public string[] GetGalleryPhotos()
        {
            if (Photo == null || !Photo.Gallery.Any())
                return Array.Empty<string>();
            else
                return Photo.Gallery.Select(s => $"{BlobPath}/{GetPhotoContainer(PhotoType.PhotoGallery)}/{s}").ToArray();
        }

        public override void SetIds(string IdLoggedUser)
        {
            this.SetId(IdLoggedUser);
            this.SetPartitionKey(IdLoggedUser);
        }
    }

    public class ProfileView : ProfileModel
    {
        public ActivityStatus ActivityStatus { get; set; }
        public double Distance { get; set; }
        public int Age { get; set; }
    }
}