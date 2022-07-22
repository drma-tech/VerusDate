using VerusDate.Shared.Core;

namespace VerusDate.Shared.Enum
{
    public enum BiologicalSex
    {
        [Custom(Name = "MaleName", Description = "MaleDescription", ResourceType = typeof(Resources.Enum.BiologicalSex))]
        Male = 1,

        [Custom(Name = "FemaleName", Description = "FemaleDescription", ResourceType = typeof(Resources.Enum.BiologicalSex))]
        Female = 2,

        [Custom(Name = "OtherName", Description = "OtherDescription", ResourceType = typeof(Resources.Enum.BiologicalSex))]
        Other = 99
    }
}