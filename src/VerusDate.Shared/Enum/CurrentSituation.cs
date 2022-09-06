using VerusDate.Shared.Core;

namespace VerusDate.Shared.Enum
{
    public enum CurrentSituation
    {
        [Custom(Name = "Single_Name", Description = "Single_Description", ResourceType = typeof(Resources.Enum.CurrentSituation))]
        Single = 1,

        [Custom(Name = "NonMonogamous_Name", Description = "NonMonogamous_Description", ResourceType = typeof(Resources.Enum.CurrentSituation))]
        NonMonogamous = 2
    }
}