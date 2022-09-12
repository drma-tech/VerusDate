using VerusDate.Shared.Core;

namespace VerusDate.Shared.Enum
{
    public enum TravelFrequency
    {
        [Custom(Name = "NeverRarely_Name", Description = "NeverRarely_Description", ResourceType = typeof(Resources.Enum.TravelFrequency))]
        NeverRarely = 1,

        [Custom(Name = "SometimesFrequently_Name", Description = "SometimesFrequently_Description", ResourceType = typeof(Resources.Enum.TravelFrequency))]
        SometimesFrequently = 2,

        [Custom(Name = "UsuallyAlwaysNomad_Name", Description = "UsuallyAlwaysNomad_Description", ResourceType = typeof(Resources.Enum.TravelFrequency))]
        UsuallyAlwaysNomad = 3,
    }
}