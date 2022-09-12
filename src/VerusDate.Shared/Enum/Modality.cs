using VerusDate.Shared.Core;

namespace VerusDate.Shared.Enum
{
    public enum Modality
    {
        [Custom(Name = "Matchmaker_Name", Description = "Matchmaker_Description", ResourceType = typeof(Resources.Enum.Modality))]
        Matchmaker = 1,

        [Custom(Name = "RelationshipAnalysis_Name", Description = "RelationshipAnalysis_Description", ResourceType = typeof(Resources.Enum.Modality))]
        RelationshipAnalysis = 2
    }
}