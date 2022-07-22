using VerusDate.Shared.Core;

namespace VerusDate.Shared.Enum
{
    public enum WantChildren
    {
        [Custom(Name = "No", ResourceType = typeof(Resources.Enum.WantChildren))]
        No = 1,

        [Custom(Name = "Maybe", ResourceType = typeof(Resources.Enum.WantChildren))]
        Maybe = 2,

        [Custom(Name = "Yes", ResourceType = typeof(Resources.Enum.WantChildren))]
        Yes = 3
    }
}