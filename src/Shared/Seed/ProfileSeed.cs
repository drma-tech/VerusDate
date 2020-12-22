using Bogus;
using VerusDate.Shared.Enum;
using VerusDate.Shared.Model;

namespace VerusDate.Shared.Seed
{
    public static class ProfileSeed
    {
        public static Faker<Profile> GetProfileVM(string IdUser = null)
        {
            return new Faker<Profile>("pt_BR")
                .Rules((s, p) =>
                {
                    p.Id = IdUser ?? s.Random.Guid().ToString();
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
                    //p.ActivityStatus = s.PickRandom<ActivityStatus>();
                });
        }
    }
}