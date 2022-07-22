using Bogus;
using VerusDate.Shared.Enum;
using VerusDate.Shared.Model;

namespace VerusDate.Seed.Model
{
    public static class EventSeed
    {
        public static Faker<EventModel> GetEventVM(string IdUser = null)
        {
            return new Faker<EventModel>("pt_BR")
                .Rules((s, p) =>
                {
                    p.SetIds(IdUser ?? s.Random.Guid().ToString());
                    p.DtStart = s.Date.Future();
                    p.DtEnd = s.Date.Future();
                    p.EventType = s.PickRandom<EventType>();
                    p.Location = s.Address.City();
                    p.MinimalAge = s.Random.Number(18, 40);
                    p.MaxAge = s.Random.Number(30, 120);
                    p.Intentions = s.Random.ArrayElements(new Intentions[] { Intentions.Casual, Intentions.Serious, Intentions.Married });
                    p.SexualOrientation = s.Random.ArrayElements(new SexualOrientation[] { SexualOrientation.Asexual, SexualOrientation.Heterosexual, SexualOrientation.Bisexual, SexualOrientation.Bisexual });
                    p.GenderDivision = s.Random.Bool();
                });
        }
    }
}