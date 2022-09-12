using VerusDate.Shared.Core;

namespace VerusDate.Shared.Enum
{
    public enum Section
    {
        [Custom(Name = "Basic", ResourceType = typeof(Resources.Enum.Section))]
        Basic,

        [Custom(Name = "Bio", ResourceType = typeof(Resources.Enum.Section))]
        Bio,

        [Custom(Name = "Lifestyle", ResourceType = typeof(Resources.Enum.Section))]
        Lifestyle,

        [Custom(Name = "Personality", ResourceType = typeof(Resources.Enum.Section))]
        Personality,

        [Custom(Name = "Interest", ResourceType = typeof(Resources.Enum.Section))]
        Interest
    }
}