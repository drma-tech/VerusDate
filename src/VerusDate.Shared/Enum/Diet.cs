using VerusDate.Shared.Core;

namespace VerusDate.Shared.Enum
{
    /// <summary>
    /// https://autumnasphodel.com/types-of-diets
    /// </summary>
    public enum Diet
    {
        [Custom(Name = "Omnivore_Name", Description = "Omnivore_Description", ResourceType = typeof(Resources.Enum.Diet))]
        Omnivore = 1,

        [Custom(Name = "Flexitarian_Name", Description = "Flexitarian_Description", ResourceType = typeof(Resources.Enum.Diet))]
        Flexitarian = 2,

        [Custom(Name = "Vegetarian_Name", Description = "Vegetarian_Description", ResourceType = typeof(Resources.Enum.Diet))]
        Vegetarian = 3,

        [Custom(Name = "Vegan_Name", Description = "Vegan_Description", ResourceType = typeof(Resources.Enum.Diet))]
        Vegan = 4,

        [Custom(Name = "RawFood_Name", Description = "RawFood_Description", ResourceType = typeof(Resources.Enum.Diet))]
        RawFood = 5,

        [Custom(Name = "GlutenFree_Name", Description = "GlutenFree_Description", ResourceType = typeof(Resources.Enum.Diet))]
        GlutenFree = 6,

        [Custom(Name = "OrganicAllnaturalLocal_Name", Description = "OrganicAllnaturalLocal_Description", ResourceType = typeof(Resources.Enum.Diet))]
        OrganicAllnaturalLocal = 7,

        [Custom(Name = "DetoxWeightLoss_Name", Description = "DetoxWeightLoss_Description", ResourceType = typeof(Resources.Enum.Diet))]
        DetoxWeightLoss = 8
    }
}