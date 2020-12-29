using Bogus;
using System.Linq;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.Seed
{
    public static class EventSeed
    {
        public static Faker<Model.Event.Event> GetEventVM(string IdEvent = null, string IdUser = null)
        {
            var fakeBD = new Faker<Model.Event.Event>("pt_BR")
                .Rules((s, p) =>
                {
                    p.NewBlindDate(
                        s.Date.FutureOffset(),
                        s.Address.City(),
                        s.Random.Number(18, 120),
                        s.Random.Number(18, 120),
                        s.Random.ArrayElements(new Intent[] { Intent.OneNightStand, Intent.FriendsWithBenefits, Intent.Relationship, Intent.Married }),
                        s.Random.ArrayElements(new SexualOrientation[] { SexualOrientation.Assexual, SexualOrientation.Heteressexual, SexualOrientation.Bissexual, SexualOrientation.Bissexual }),
                        s.Random.Bool()
                        );
                }).Generate();

            return new Faker<Model.Event.Event>("pt_BR")
                .Rules((s, p) =>
                {
                    p.Id = IdEvent ?? s.Random.Guid().ToString();
                    p.IdUserOwner = IdUser ?? s.Random.Guid().ToString();
                    p.NewBlindDate(fakeBD.DtStart, fakeBD.Location, fakeBD.MinimalAge, fakeBD.MaxAge, fakeBD.Intent.ToArray(), fakeBD.SexualOrientation, fakeBD.GenderDivision);
                });
        }
    }
}