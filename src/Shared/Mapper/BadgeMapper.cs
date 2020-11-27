using Dapper.FluentMap.Mapping;
using VerusDate.Shared.ViewModel;

namespace VerusDate.Shared.Mapper
{
    public class BadgeMapper : EntityMap<BadgeVM>
    {
        public BadgeMapper()
        {
            Map(p => p.Rank.Level)
                .ToColumn("Rank_Level");

            Map(p => p.Seniority.Level)
                .ToColumn("Seniority_Level");

            Map(p => p.CompletedProfile.Level)
                .ToColumn("CompletedProfile_Level");

            Map(p => p.VerifiedProfile.Level)
                .ToColumn("VerifiedProfile_Level");

            Map(p => p.Popular.Level)
                .ToColumn("Popular_Level");
        }
    }
}