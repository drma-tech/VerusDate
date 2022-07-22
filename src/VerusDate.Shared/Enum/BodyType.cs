using VerusDate.Shared.Core;

namespace VerusDate.Shared.Enum
{
    public enum BodyMass
    {
        [Custom(Name = "UnderWeight", ResourceType = typeof(Resources.Enum.BodyMass))]
        UnderWeight = 1,

        [Custom(Name = "NormalWeight", ResourceType = typeof(Resources.Enum.BodyMass))]
        NormalWeight = 2,

        [Custom(Name = "Athletic", ResourceType = typeof(Resources.Enum.BodyMass))]
        Athletic = 3,

        [Custom(Name = "OverWeight", ResourceType = typeof(Resources.Enum.BodyMass))]
        OverWeight = 4,

        [Custom(Name = "Obese", ResourceType = typeof(Resources.Enum.BodyMass))]
        Obese = 5,
    }
}