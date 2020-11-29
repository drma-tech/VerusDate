using Bogus;
using VerusDate.Shared.Enum;
using VerusDate.Shared.ViewModel.Command;

namespace VerusDate.Shared.Seed
{
    public static class ProfileSeed
    {
        public static ProfileVM GetProfileVM(string id = null, bool view = false)
        {
            return new Faker<ProfileVM>("pt_BR")
                .Rules((s, p) =>
                {
                    //p.Id = id ?? Guid.NewGuid().ToString();
                    p.NickName = s.Internet.UserName();
                    p.Description = s.Lorem.Word();
                    p.BirthDate = s.Date.Past(18).Date;
                    p.BiologicalSex = s.PickRandom<BiologicalSex>();
                    p.MaritalStatus = s.PickRandom<MaritalStatus>();
                    p.Intent = s.Random.ArrayElements(new Intent[] { Intent.OneNightStand, Intent.FriendsWithBenefits, Intent.Relationship, Intent.Married });
                    p.GenderIdentity = s.PickRandom<GenderIdentity>();
                    p.SexualOrientation = s.PickRandom<SexualOrientation>();
                    p.Location = $"{s.Address.Country()} - {s.Address.State()} - {s.Address.City()}";
                    p.Smoke = s.PickRandom<Smoke>();
                    p.Drink = s.PickRandom<Drink>();
                    p.Diet = s.PickRandom<Diet>();
                    p.Height = s.PickRandom<Height>();
                    p.BodyMass = s.PickRandom<BodyMass>();
                    p.RaceCategory = s.PickRandom<RaceCategory>();
                    p.Latitude = s.Address.Latitude(-3.220192, -34.316614);
                    p.Longitude = s.Address.Longitude(-35.039519, -69.421414);
                    //p.Latitude = s.Address.Latitude();
                    //p.Longitude = s.Address.Longitude();
                    p.CareerCluster = s.PickRandom<CareerCluster>();
                    p.EducationLevel = s.PickRandom<EducationLevel>();
                    p.MoneyPersonality = s.PickRandom<MoneyPersonality>();
                    p.MyersBriggsTypeIndicator = s.PickRandom<MyersBriggsTypeIndicator>();
                    p.HaveChildren = s.PickRandom<HaveChildren>();
                    p.RelationshipPersonality = s.PickRandom<RelationshipPersonality>();
                    p.Religion = s.PickRandom<Religion>();
                    p.WantChildren = s.PickRandom<WantChildren>();
                    p.UpdateMainPhoto(s.Image.PicsumUrl());
                    p.UpdatePhotoGallery(new[] { s.Image.PicsumUrl() });
                    p.Hobbies = s.Random.WordsArray(1, 8);
                    p.ActivityStatus = s.PickRandom<ActivityStatus>();
                });
        }

        public static ProfileLookingVM GetProfileLookingVM(string id = null)
        {
            return new Faker<ProfileLookingVM>("pt_BR")
                .Rules((s, p) =>
                {
                    //p.Id = id ?? Guid.NewGuid().ToString();
                    p.MinimalAge = s.Random.Int(18, 120);
                    p.MaxAge = s.Random.Int(18, 120);
                    p.BiologicalSex = s.PickRandom<BiologicalSex>();
                    p.MaritalStatus = s.PickRandom<MaritalStatus>();
                    p.Intent = s.Random.ArrayElements(new Intent[] { Intent.OneNightStand, Intent.FriendsWithBenefits, Intent.Relationship, Intent.Married });
                    p.GenderIdentity = s.PickRandom<GenderIdentity>();
                    p.SexualOrientation = s.PickRandom<SexualOrientation>();
                    p.Smoke = s.PickRandom<Smoke>();
                    p.Drink = s.PickRandom<Drink>();
                    p.Diet = s.PickRandom<Diet>();
                    p.MinimalHeight = s.PickRandom<Height>();
                    p.MaxHeight = s.PickRandom<Height>();
                    p.BodyMass = s.PickRandom<BodyMass>();
                    p.RaceCategory = s.PickRandom<RaceCategory>();
                    p.Distance = s.Random.Int(0, 10000);
                    p.CareerCluster = s.PickRandom<CareerCluster>();
                    p.EducationLevel = s.PickRandom<EducationLevel>();
                    p.HaveChildren = s.PickRandom<HaveChildren>();
                    p.Religion = s.PickRandom<Religion>();
                    p.WantChildren = s.PickRandom<WantChildren>();
                });
        }
    }
}