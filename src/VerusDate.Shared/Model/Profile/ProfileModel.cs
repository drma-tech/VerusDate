using System;
using System.Collections.Generic;
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

        #region BASIC

        [Custom(Name = "Modality_Name", ResourceType = typeof(Resources.Model.ProfileBasicModel))]
        public Modality? Modality { get; set; }

        [Custom(Name = "NickName_Name", Prompt = "NickName_Prompt", ResourceType = typeof(Resources.Model.ProfileBasicModel))]
        public string NickName { get; set; }

        [Custom(Name = "Description_Name", Prompt = "Description_Prompt", ResourceType = typeof(Resources.Model.ProfileBasicModel))]
        public string Description { get; set; }

        [Custom(Name = "Location_Name", Prompt = "Location_Prompt", Description = "Location_Description", ResourceType = typeof(Resources.Model.ProfileBasicModel))]
        public string Location { get; set; }

        [Custom(Name = "Languages_Name", Description = "Languages_Description", ResourceType = typeof(Resources.Model.ProfileBasicModel))]
        public IReadOnlyList<Language> Languages { get; set; } = Array.Empty<Language>();

        [Custom(Name = "CurrentSituation_Name", ResourceType = typeof(Resources.Model.ProfileBasicModel))]
        public CurrentSituation? CurrentSituation { get; set; }

        [Custom(Name = "Intentions_Name", Description = "Intentions_Description", ResourceType = typeof(Resources.Model.ProfileBasicModel))]
        public IReadOnlyList<Intentions> Intentions { get; set; } = Array.Empty<Intentions>();

        [Custom(Name = "BiologicalSex_Name", ResourceType = typeof(Resources.Model.ProfileBasicModel))]
        public BiologicalSex? BiologicalSex { get; set; }

        [Custom(Name = "GenderIdentity_Name", Description = "GenderIdentity_Description", ResourceType = typeof(Resources.Model.ProfileBasicModel))]
        public GenderIdentity? GenderIdentity { get; set; }

        [Custom(Name = "SexualOrientation_Name", Description = "SexualOrientation_Description", ResourceType = typeof(Resources.Model.ProfileBasicModel))]
        public SexualOrientation? SexualOrientation { get; set; }

        #endregion BASIC

        #region BIO

        [Custom(Name = "RaceCategory_Name", Description = "RaceCategory_Description", ResourceType = typeof(Resources.Model.ProfileBioModel))]
        public RaceCategory? RaceCategory { get; set; }

        [Custom(Name = "BodyMass_Name", ResourceType = typeof(Resources.Model.ProfileBioModel))]
        public BodyMass? BodyMass { get; set; }

        [Custom(Name = "BirthDate_Name", ResourceType = typeof(Resources.Model.ProfileBioModel))]
        public DateTime BirthDate { get; set; }

        [Custom(Name = "Zodiac_Name", ResourceType = typeof(Resources.Model.ProfileBioModel))]
        public Zodiac Zodiac { get; set; }

        [Custom(Name = "Height_Name", ResourceType = typeof(Resources.Model.ProfileBioModel))]
        public Height? Height { get; set; }

        [Custom(Name = "Neurodiversity_Name", ResourceType = typeof(Resources.Model.ProfileBioModel))]
        public Neurodiversity? Neurodiversity { get; set; }

        [Custom(Name = "Disabilities_Name", ResourceType = typeof(Resources.Model.ProfileBioModel))]
        public IReadOnlyList<Disability> Disabilities { get; set; } = Array.Empty<Disability>();

        #endregion BIO

        #region LIFESTYLE

        [Custom(Name = "Drink_Name", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public Drink? Drink { get; set; }

        [Custom(Name = "Smoke_Name", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public Smoke? Smoke { get; set; }

        [Custom(Name = "Diet_Name", Description = "Diet_Description", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public Diet? Diet { get; set; }

        [Custom(Name = "HaveChildren_Name", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public HaveChildren? HaveChildren { get; set; }

        [Custom(Name = "WantChildren_Name", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public WantChildren? WantChildren { get; set; }

        [Custom(Name = "EducationLevel_Name", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public EducationLevel? EducationLevel { get; set; }

        [Custom(Name = "CareerCluster_Name", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public CareerCluster? CareerCluster { get; set; }

        [Custom(Name = "Religion_Name", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public Religion? Religion { get; set; }

        [Custom(Name = "Travel Frequency")]
        public TravelFrequency? TravelFrequency { get; set; }

        #endregion LIFESTYLE

        #region PERSONALITY

        [Custom(Name = "MoneyPersonality_Name", Description = "MoneyPersonality_Description", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public MoneyPersonality? MoneyPersonality { get; set; }

        [Custom(Name = "SplitTheBill_Name", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public SplitTheBill? SplitTheBill { get; set; }

        [Custom(Name = "RelationshipPersonality_Name", Description = "RelationshipPersonality_Description", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public RelationshipPersonality? RelationshipPersonality { get; set; }

        [Custom(Name = "MyersBriggsTypeIndicator_Name", Description = "MyersBriggsTypeIndicator_Description", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public MyersBriggsTypeIndicator? MyersBriggsTypeIndicator { get; set; }

        [Custom(Name = "LoveLanguage_Name", Description = "LoveLanguage_Description", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public LoveLanguage? LoveLanguage { get; set; }

        //[Custom(Name = "SexPersonality_Name", Description = "SexPersonality_Description", FieldInfo = "Sexual compatibility is paramount to healthy relationships. We tend to push it aside in favor of other positive personal qualities such as kindness, a good sense of humor, etc. To be clear, sex isn't the most important thing in a relationship, but research tells us couples that are more happy with their sex life are more happy with their relationship overall. When your sexual interests don't align with your partner's and a satisfying sex life is hard to access together, you're not going to have a very happy partnership.", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        [Custom(Name = "SexPersonality_Name", Description = "SexPersonality_Description", FieldInfo = "A compatibilidade sexual é primordial para relacionamentos saudáveis. Nós tendemos a deixar isso de lado em favor de outras qualidades pessoais positivas, como gentileza, bom senso de humor, etc. Para ser claro, sexo não é a coisa mais importante em um relacionamento, mas pesquisas nos dizem que casais são mais felizes com sua vida sexual são mais felizes com seu relacionamento em geral. Quando os seus interesses sexuais não se alinham com os do seu parceiro e uma vida sexual satisfatória é difícil de alcançar juntos, você não terá uma parceria muito feliz.", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public SexPersonality? SexPersonality { get; set; }

        #endregion PERSONALITY

        #region INTEREST

        [Custom(Name = "Comidas")]
        public IReadOnlyList<Food> Food { get; set; } = Array.Empty<Food>();

        [Custom(Name = "Férias")]
        public IReadOnlyList<Vacation> Vacation { get; set; } = Array.Empty<Vacation>();

        [Custom(Name = "Esportes")]
        public IReadOnlyList<Sports> Sports { get; set; } = Array.Empty<Sports>();

        [Custom(Name = "Lazer")]
        public IReadOnlyList<LeisureActivities> LeisureActivities { get; set; } = Array.Empty<LeisureActivities>();

        [Custom(Name = "Música")]
        public IReadOnlyList<MusicGenre> MusicGenre { get; set; } = Array.Empty<MusicGenre>();

        [Custom(Name = "Filme")]
        public IReadOnlyList<MovieGenre> MovieGenre { get; set; } = Array.Empty<MovieGenre>();

        [Custom(Name = "TV")]
        public IReadOnlyList<TVGenre> TVGenre { get; set; } = Array.Empty<TVGenre>();

        [Custom(Name = "Leitura")]
        public IReadOnlyList<ReadingGenre> ReadingGenre { get; set; } = Array.Empty<ReadingGenre>();

        #endregion INTEREST

        public ProfilePreferenceModel Preference { get; set; }

        //public ProfileGamificationModel Gamification { get; set; }
        public ProfileBadgeModel Badge { get; set; }

        public ProfilePhotoModel Photo { get; set; }
        public ProfileReportModel[] Reports { get; set; } = Array.Empty<ProfileReportModel>();

        //public string[] ActiveInteractions { get; set; } = Array.Empty<string>();
        //public string[] PassiveInteractions { get; set; } = Array.Empty<string>();

        private readonly string BlobPath = "https://storageverusdate.blob.core.windows.net";

        public void UpList()
        {
            DtTopList = DateTime.UtcNow;
        }

        public void Login()
        {
            DtLastLogin = DateTime.UtcNow;
        }

        public void UpdateData(ProfileModel profile)
        {
            //BASIC
            Modality = profile.Modality;
            NickName = profile.NickName;
            Description = profile.Description;
            Location = profile.Location;
            Languages = profile.Languages;
            CurrentSituation = profile.CurrentSituation;
            Intentions = profile.Intentions;
            BiologicalSex = profile.BiologicalSex;
            GenderIdentity = profile.GenderIdentity;
            SexualOrientation = profile.SexualOrientation;

            //BIO
            BirthDate = profile.BirthDate;
            Zodiac = profile.Zodiac;
            Height = profile.Height;
            RaceCategory = profile.RaceCategory;
            BodyMass = profile.BodyMass;

            //LIFESTYLE
            Drink = profile.Drink;
            Smoke = profile.Smoke;
            Diet = profile.Diet;
            HaveChildren = profile.HaveChildren;
            WantChildren = profile.WantChildren;
            EducationLevel = profile.EducationLevel;
            CareerCluster = profile.CareerCluster;
            Religion = profile.Religion;
            TravelFrequency = profile.TravelFrequency;

            //PERSONALITY
            MoneyPersonality = profile.MoneyPersonality;
            SplitTheBill = profile.SplitTheBill;
            RelationshipPersonality = profile.RelationshipPersonality;
            MyersBriggsTypeIndicator = profile.MyersBriggsTypeIndicator;
            LoveLanguage = profile.LoveLanguage;
            SexPersonality = profile.SexPersonality;

            //INTEREST
            Food = profile.Food;
            Vacation = profile.Vacation;
            Sports = profile.Sports;
            LeisureActivities = profile.LeisureActivities;
            MusicGenre = profile.MusicGenre;
            MovieGenre = profile.MovieGenre;
            TVGenre = profile.TVGenre;
            ReadingGenre = profile.ReadingGenre;

            //OTHERS
            Neurodiversity = profile.Neurodiversity;
            Disabilities = profile.Disabilities;

            DtUpdate = DateTime.UtcNow;
        }

        public void UpdateLooking(ProfilePreferenceModel obj)
        {
            Preference = obj;

            DtUpdate = DateTime.UtcNow;
        }

        //public void UpdateGamification(ProfileGamificationModel obj)
        //{
        //    Gamification = obj;

        //    DtUpdate = DateTime.UtcNow;
        //}

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

        public enum LocationType
        {
            Full,
            Country,
            State,
            City
        }

        public string GetLocation(LocationType type)
        {
            if (string.IsNullOrEmpty(Location)) return null;

            var parts = Location.Split(" - ");

            switch (type)
            {
                case LocationType.Full:
                    return Location;

                case LocationType.Country:
                    return parts[0];

                case LocationType.State:
                    return parts[1];

                case LocationType.City:
                    if (parts.Length == 4)
                        return parts[2] + " - " + parts[3]; //county - city
                    else
                        return parts[2];

                default:
                    return null;
            }
        }
    }

    public class ProfileView : ProfileModel
    {
        public ActivityStatus ActivityStatus { get; set; }

        [Custom(Name = "Age_Name", ResourceType = typeof(Resources.Model.ProfileBioModel))]
        public int Age { get; set; }
    }
}