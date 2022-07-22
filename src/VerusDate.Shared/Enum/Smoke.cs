using VerusDate.Shared.Core;

namespace VerusDate.Shared.Enum
{
    public enum Smoke
    {
        [Custom(Name = "No", ResourceType = typeof(Resources.Enum.Smoke))]
        No = 1,

        [Custom(Name = "YesOccasionally", ResourceType = typeof(Resources.Enum.Smoke))]
        YesOccasionally = 2,

        [Custom(Name = "YesOften", ResourceType = typeof(Resources.Enum.Smoke))]
        YesOften = 3
    }
}