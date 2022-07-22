using VerusDate.Shared.Core;

namespace VerusDate.Shared.Enum
{
    public enum EducationLevel
    {
        [Custom(Name = "Basic", ResourceType = typeof(Resources.Enum.EducationLevel))]
        Basic = 1,

        [Custom(Name = "Intermediary", ResourceType = typeof(Resources.Enum.EducationLevel))]
        Intermediary = 2,

        [Custom(Name = "Advanced", ResourceType = typeof(Resources.Enum.EducationLevel))]
        Advanced = 3
    }
}