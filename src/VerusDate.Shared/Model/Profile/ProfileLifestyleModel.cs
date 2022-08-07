using System;
using System.Collections.Generic;
using VerusDate.Shared.Core;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.Model
{
    public class ProfileLifestyleModel
    {
        [Custom(Name = "Drink_Name", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public Drink? Drink { get; set; }

        [Custom(Name = "Smoke_Name", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public Smoke? Smoke { get; set; }

        [Custom(Name = "Diet_Name", Description = "Diet_Description", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public Diet? Diet { get; set; }

        [Custom(Name = "HaveChildren_Name", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public HaveChildren? HaveChildren { get; set; }

        [Custom(Name = "WantChildren_Name", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public WantChildren? WantChildren { get; set; }

        [Custom(Name = "EducationLevel_Name", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public EducationLevel? EducationLevel { get; set; }

        [Custom(Name = "CareerCluster_Name", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public CareerCluster? CareerCluster { get; set; }

        [Custom(Name = "Religion_Name", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public Religion? Religion { get; set; }

        [Custom(Name = "MoneyPersonality_Name", Description = "MoneyPersonality_Description", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public MoneyPersonality? MoneyPersonality { get; set; }

        [Custom(Name = "SplitTheBill_Name", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public SplitTheBill? SplitTheBill { get; set; }

        [Custom(Name = "RelationshipPersonality_Name", Description = "RelationshipPersonality_Description", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public RelationshipPersonality? RelationshipPersonality { get; set; }

        [Custom(Name = "MyersBriggsTypeIndicator_Name", Description = "MyersBriggsTypeIndicator_Description", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public MyersBriggsTypeIndicator? MyersBriggsTypeIndicator { get; set; }

        [Custom(Name = "LoveLanguage_Name", Description = "LoveLanguage_Description", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public LoveLanguage? LoveLanguage { get; set; }

        [Custom(Name = "SexPersonality_Name", Description = "SexPersonality_Description", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public SexPersonality? SexPersonality { get; set; }

        [Custom(Name = "SexPersonalityPreferences_Name", Description = "SexPersonalityPreferences_Description", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public IReadOnlyList<SexPersonality> SexPersonalityPreferences { get; set; } = Array.Empty<SexPersonality>();
    }
}