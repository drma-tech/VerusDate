using Bogus;
using VerusDate.Shared.Model;

namespace VerusDate.Api.Seed
{
    public static class InteractionSeed
    {
        public static Faker<T> GetInteraction<T>() where T : InteractionModel
        {
            return new Faker<T>("pt_BR")
                .Rules((s, p) =>
                {
                    p.SetIds(s.Random.Guid().ToString());
                    p.SetIdInteraction(s.Random.Guid().ToString());
                });
        }
    }
}