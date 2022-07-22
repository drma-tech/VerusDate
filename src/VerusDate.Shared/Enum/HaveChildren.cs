using VerusDate.Shared.Core;

namespace VerusDate.Shared.Enum
{
    public enum HaveChildren
    {
        [Custom(Name = "No", ResourceType = typeof(Resources.Enum.HaveChildren))]
        No = 1,

        [Custom(Name = "YesNo", ResourceType = typeof(Resources.Enum.HaveChildren))]
        YesNo = 2,

        [Custom(Name = "Yes", ResourceType = typeof(Resources.Enum.HaveChildren))]
        Yes = 3
    }
}