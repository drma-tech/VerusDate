using VerusDate.Shared.Core;

namespace VerusDate.Shared.Enum
{
    /// <summary>
    /// invented by me (dhiogo)
    /// </summary>
    public enum SplitTheBill
    {
        [Custom(Name = "Dependent_Name", Description = "Dependent_Description", ResourceType = typeof(Resources.Enum.SplitTheBill))]
        Dependent = 1,

        [Custom(Name = "GetGifts_Name", Description = "GetGifts_Description", ResourceType = typeof(Resources.Enum.SplitTheBill))]
        GetGifts = 2,

        [Custom(Name = "Balanced_Name", Description = "Balanced_Description", ResourceType = typeof(Resources.Enum.SplitTheBill))]
        Balanced = 3,

        [Custom(Name = "SendGifts_Name", Description = "SendGifts_Description", ResourceType = typeof(Resources.Enum.SplitTheBill))]
        SendGifts = 4,

        [Custom(Name = "Provider_Name", Description = "Provider_Description", ResourceType = typeof(Resources.Enum.SplitTheBill))]
        Provider = 5
    }
}