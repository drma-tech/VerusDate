using Bogus;
using VerusDate.Shared.Enum;
using VerusDate.Shared.ViewModel.Command;

namespace VerusDate.Shared.Seed
{
    public static class ProfileLookingSeed
    {
        public static Faker<ProfileLookingVM> GetProfileLookingVM(string IdUser = null)
        {
            return new Faker<ProfileLookingVM>("pt_BR")
                .Rules((s, p) =>
                {
                    p.IdUser = IdUser ?? s.Random.Guid().ToString();
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