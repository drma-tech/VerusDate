using VerusDate.Shared.Core;

namespace VerusDate.Shared.Enum
{
    public enum Intentions
    {
        [Custom( Name = "Serious_Name", Description = "Serious_Description", ResourceType = typeof(Resources.Enum.Intentions))]
        Serious = 1,

        [Custom( Name = "LiveTogether_Name", Description = "LiveTogether_Description", ResourceType = typeof(Resources.Enum.Intentions))]
        LiveTogether = 2,

        [Custom( Name = "Married_Name", Description = "Married_Description", ResourceType = typeof(Resources.Enum.Intentions))]
        Married = 3
    }
}