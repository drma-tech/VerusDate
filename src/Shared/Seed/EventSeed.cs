using Bogus;
using System.Linq;
using VerusDate.Shared.Enum;
using VerusDate.Shared.ViewModel.Command;

namespace VerusDate.Shared.Seed
{
    public static class EventSeed
    {
        public static Faker<EventVM> GetEventVM(string IdEvent = null, string IdUser = null)
        {
            var fakeBD = new Faker<EventVM>("pt_BR")
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

            return new Faker<EventVM>("pt_BR")
                .Rules((s, p) =>
                {
                    p.LoadDefatultData();
                    p.IdEvent = IdEvent ?? s.Random.Guid().ToString();
                    p.IdUser = IdUser ?? s.Random.Guid().ToString();
                    p.NewBlindDate(fakeBD.DtStart, fakeBD.Location, fakeBD.MinimalAge, fakeBD.MaxAge, fakeBD.Intent.ToArray(), fakeBD.SexualOrientation, fakeBD.GenderDivision);
                });
        }
    }
}