using VerusDate.Shared.Core;

namespace VerusDate.Shared.Enum
{
    /// <summary>
    /// https://www.academia.edu/39976315/6_General_Types_Of_Disabilities_Physical_Disabilities
    /// </summary>
    public enum Disability
    {
        [Custom(Name = "Physical_Name", Description = "Physical_Description", ResourceType = typeof(Resources.Enum.Disability))]
        Physical = 1,

        [Custom(Name = "Visual_Name", Description = "Visual_Description", ResourceType = typeof(Resources.Enum.Disability))]
        Visual = 2,

        [Custom(Name = "Hearing_Name", Description = "Hearing_Description", ResourceType = typeof(Resources.Enum.Disability))]
        Hearing = 3,

        [Custom(Name = "MentalHealth_Name", Description = "MentalHealth_Description", ResourceType = typeof(Resources.Enum.Disability))]
        MentalHealth = 4,

        [Custom(Name = "Intellectual_Name", Description = "Intellectual_Description", ResourceType = typeof(Resources.Enum.Disability))]
        Intellectual = 5,

        [Custom(Name = "Learning_Name", Description = "Learning_Description", ResourceType = typeof(Resources.Enum.Disability))]
        Learning = 6,
    }
}