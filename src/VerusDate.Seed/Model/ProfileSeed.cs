using Bogus;
using System;
using VerusDate.Shared.Enum;
using VerusDate.Shared.Model;
using VerusDate.Shared.ModelQuery;

namespace VerusDate.Seed.Model
{
    public static class ProfileSeed
    {
        public static Faker<ProfileModel> GetProfile(string Id = null, bool profile = true, bool looking = false, bool gamification = false, bool badge = false, bool photo = false)
        {
            return GetProfile<ProfileModel>(Id, profile, looking, gamification, badge, photo);
        }

        public static Faker<T> GetProfile<T>(string Id = null, bool profile = true, bool looking = false, bool gamification = false, bool badge = false, bool photo = false) where T : ProfileModel
        {
            return new Faker<T>("pt_BR")
                .Rules((s, p) =>
                {
                    p.SetIds(Id ?? s.Random.Guid().ToString());
                    if (profile) p.UpdateProfile(GetProfileBasic<ProfileBasicModel>(), GetProfileBio(), GetProfileLifestyle(), new ProfileInterestModel());
                    if (looking) p.UpdateLooking(GetProfileLookingVM());
                    if (gamification) p.UpdateGamification(GetProfileGamification());
                    if (badge) p.UpdateBadge(GetProfileBadge());
                    if (photo) p.UpdatePhoto(GetProfilePhoto());
                    //p.ActivityStatus = s.PickRandom<ActivityStatus>();
                });
        }

        public static Faker<ProfileBadgeModel> GetProfileBadge()
        {
            return new Faker<ProfileBadgeModel>("pt_BR")
                .Rules((s, p) =>
                {
                    p.Ranking.IncreaseLevel();
                    p.Seniority.IncreaseLevel();
                    p.VerifiedProfile.IncreaseLevel();
                    p.Popular.IncreaseLevel();
                });
        }

        public static Faker<T> GetProfileBasic<T>() where T : ProfileBasicModel
        {
            return new Faker<T>("pt_BR")
                .Rules((s, p) =>
                {
                    p.NickName = s.Name.FirstName();
                    p.Description = s.Lorem.Text();
                    p.Latitude = s.Address.Latitude(-3.220192, -34.316614);
                    p.Longitude = s.Address.Longitude(-35.039519, -69.421414);
                    //p.Latitude = s.Address.Latitude();
                    //p.Longitude = s.Address.Longitude();
                    p.Location = $"{s.Address.Country()} - {s.Address.State()} - {s.Address.City()}";
                    p.CurrentSituation = s.PickRandom<CurrentSituation>();
                    p.Intentions = s.Random.ArrayElements(new Intentions[] { Intentions.Casual, Intentions.Serious, Intentions.Married }, s.Random.Number(1, 4));
                    p.BiologicalSex = s.PickRandom<BiologicalSex>();
                    p.GenderIdentity = s.PickRandom<GenderIdentity>();
                    p.SexualOrientation = s.PickRandom<SexualOrientation>();
                });
        }

        public static Faker<ProfileBioModel> GetProfileBio()
        {
            return new Faker<ProfileBioModel>("pt_BR")
                .Rules((s, p) =>
                {
                    p.BirthDate = s.Date.Past(100, DateTime.UtcNow.AddYears(-18).Date);
                    p.Height = s.PickRandom<Height>();
                    p.RaceCategory = s.PickRandom<RaceCategory>();
                    p.BodyMass = s.PickRandom<BodyMass>();
                });
        }

        public static Faker<ProfileGamificationModel> GetProfileGamification()
        {
            return new Faker<ProfileGamificationModel>("pt_BR")
                .Rules((s, p) =>
                {
                    p.AddXP(s.Random.Number(1, 1000));
                    p.AddDiamond(s.Random.Number(1, 100));
                });
        }

        public static Faker<ProfileLifestyleModel> GetProfileLifestyle()
        {
            return new Faker<ProfileLifestyleModel>("pt_BR")
                .Rules((s, p) =>
                {
                    p.Drink = s.PickRandom<Drink>();
                    p.Smoke = s.PickRandom<Smoke>();
                    p.Diet = s.PickRandom<Diet>();
                    p.HaveChildren = s.PickRandom<HaveChildren>();
                    p.WantChildren = s.PickRandom<WantChildren>();
                    p.EducationLevel = s.PickRandom<EducationLevel>();
                    p.CareerCluster = s.PickRandom<CareerCluster>();
                    p.Religion = s.PickRandom<Religion>();
                    p.MoneyPersonality = s.PickRandom<MoneyPersonality>();
                    p.RelationshipPersonality = s.PickRandom<RelationshipPersonality>();
                    p.MyersBriggsTypeIndicator = s.PickRandom<MyersBriggsTypeIndicator>();
                });
        }

        public static Faker<ProfilePreferenceModel> GetProfileLookingVM()
        {
            return new Faker<ProfilePreferenceModel>("pt_BR")
                .Rules((s, p) =>
                {
                    p.MinimalAge = s.Random.Int(18, 120);
                    p.MaxAge = s.Random.Int(18, 120);
                    p.BiologicalSex = s.Random.ArrayElements(new BiologicalSex[] { BiologicalSex.Male, BiologicalSex.Female, BiologicalSex.Other });
                    p.CurrentSituation = s.Random.ArrayElements(new CurrentSituation[] { CurrentSituation.Single, CurrentSituation.Monogamous, CurrentSituation.NonMonogamous });
                    p.Intentions = s.Random.ArrayElements(new Intentions[] { Intentions.Casual, Intentions.Serious, Intentions.Married });
                    p.GenderIdentity = s.Random.ArrayElements(new GenderIdentity[] { GenderIdentity.Cisgender, GenderIdentity.Transsexual, GenderIdentity.Transgender, GenderIdentity.NonBinary });
                    p.SexualOrientation = s.Random.ArrayElements(new SexualOrientation[] { SexualOrientation.Heterosexual, SexualOrientation.Homosexual, SexualOrientation.Bisexual, SexualOrientation.Demisexual });
                    //p.Smoke = s.PickRandom<Smoke>();
                    //p.Drink = s.PickRandom<Drink>();
                    //p.Diet = s.PickRandom<Diet>();
                    p.MinimalHeight = s.PickRandom<Height>();
                    p.MaxHeight = s.PickRandom<Height>();
                    p.BodyMass = s.Random.ArrayElements(new BodyMass[] { BodyMass.UnderWeight, BodyMass.NormalWeight, BodyMass.Athletic, BodyMass.OverWeight });
                    p.RaceCategory = s.Random.ArrayElements(new RaceCategory[] { RaceCategory.White, RaceCategory.BlackAfricanAmerican, RaceCategory.Asian, RaceCategory.TwoMoreRaces });
                    p.Distance = s.PickRandom<Distance>();
                    //p.CareerCluster = s.PickRandom<CareerCluster>();
                    //p.EducationLevel = s.PickRandom<EducationLevel>();
                    //p.HaveChildren = s.PickRandom<HaveChildren>();
                    //p.Religion = s.PickRandom<Religion>();
                    //p.WantChildren = s.PickRandom<WantChildren>();
                });
        }

        public static Faker<ProfilePhotoModel> GetProfilePhoto()
        {
            return new Faker<ProfilePhotoModel>("pt_BR")
                .Rules((s, p) =>
                {
                    p.UpdateMainPhoto(s.Internet.Avatar());
                    p.UpdatePhotoGallery(new[] { s.Image.PicsumUrl(), s.Image.PicsumUrl(), s.Image.PicsumUrl() });
                });
        }

        public static Faker<ProfileSearch> GetProfileSearch(string Id = null)
        {
            return new Faker<ProfileSearch>("pt_BR")
                .Rules((s, p) =>
                {
                    p.SetIds(Id ?? s.Random.Guid().ToString());
                    p.NickName = s.Name.FirstName();
                    p.Age = s.Random.Number(18, 100);
                    p.UpdatePhoto(GetProfilePhoto());
                    p.ActivityStatus = s.PickRandom<ActivityStatus>();
                    p.Distance = s.Random.Number(1, 100);
                });
        }
    }
}