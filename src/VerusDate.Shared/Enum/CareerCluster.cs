using VerusDate.Shared.Core;

namespace VerusDate.Shared.Enum
{
    /// <summary>
    /// https://www.education.ne.gov/nce/careerdevelopment/nce-career-fields-career-clusters/
    /// https://www.education.ne.gov/wp-content/uploads/2019/08/CTEModel17X22-RGB-2.pdf
    ///
    /// https://careerwise.minnstate.edu/careers/clusters.html
    /// https://careertech.org/career-clusters
    /// https://www.asvabprogram.com/career-cluster
    /// </summary>
    public enum CareerCluster
    {
        [Custom(Name = "NoCareer_Name", Description = "NoCareer_Description", ResourceType = typeof(Resources.Enum.CareerCluster))]
        NoCareer = 0,

        //AGRICULTURE, FOOD & NATURAL RESOURCES

        [Custom(Group = "AgricultureFoodNaturalResources_Group", Name = "AgricultureFoodNaturalResources_Name", Description = "AgricultureFoodNaturalResources_Description", ResourceType = typeof(Resources.Enum.CareerCluster))]
        AgricultureFoodNaturalResources = 1,

        //COMMUNICATION & INFORMATION SYSTEMS

        [Custom(Group = "CommunicationArts_Group", Name = "CommunicationArts_Name", Description = "CommunicationArts_Description", ResourceType = typeof(Resources.Enum.CareerCluster))]
        CommunicationArts = 2,

        [Custom(Group = "InformationTechnology_Group", Name = "InformationTechnology_Name", Description = "InformationTechnology_Description", ResourceType = typeof(Resources.Enum.CareerCluster))]
        InformationTechnology = 3,

        //BUSINESS, MARKETING AND MANAGEMENT

        [Custom(Group = "BusinessManagementAdministration_Group", Name = "BusinessManagementAdministration_Name", Description = "BusinessManagementAdministration_Description", ResourceType = typeof(Resources.Enum.CareerCluster))]
        BusinessManagementAdministration = 4,

        [Custom(Group = "Finance_Group", Name = "Finance_Name", Description = "Finance_Description", ResourceType = typeof(Resources.Enum.CareerCluster))]
        Finance = 5,

        [Custom(Group = "HospitalityTourism_Group", Name = "HospitalityTourism_Name", Description = "HospitalityTourism_Description", ResourceType = typeof(Resources.Enum.CareerCluster))]
        HospitalityTourism = 6,

        [Custom(Group = "Marketing_Group", Name = "Marketing_Name", Description = "Marketing_Description", ResourceType = typeof(Resources.Enum.CareerCluster))]
        Marketing = 7,

        //HUMAN SCIENCES AND EDUCATION

        [Custom(Group = "EducationTraining_Group", Name = "EducationTraining_Name", Description = "EducationTraining_Description", ResourceType = typeof(Resources.Enum.CareerCluster))]
        EducationTraining = 8,

        [Custom(Group = "GovernmentPublicAdministration_Group", Name = "GovernmentPublicAdministration_Name", Description = "GovernmentPublicAdministration_Description", ResourceType = typeof(Resources.Enum.CareerCluster))]
        GovernmentPublicAdministration = 9,

        [Custom(Group = "HumanServices_Group", Name = "HumanServices_Name", Description = "HumanServices_Description", ResourceType = typeof(Resources.Enum.CareerCluster))]
        HumanServices = 10,

        [Custom(Group = "LawPublicSafetyCorrectionsSecurity_Group", Name = "LawPublicSafetyCorrectionsSecurity_Name", Description = "LawPublicSafetyCorrectionsSecurity_Description", ResourceType = typeof(Resources.Enum.CareerCluster))]
        LawPublicSafetyCorrectionsSecurity = 11,

        //HEALTH SCIENCES

        [Custom(Group = "HealthScience_Group", Name = "HealthScience_Name", Description = "HealthScience_Description", ResourceType = typeof(Resources.Enum.CareerCluster))]
        HealthScience = 12,

        //SKILLED & TECHNICAL SCIENCES

        [Custom(Group = "ArchitectureConstruction_Group", Name = "ArchitectureConstruction_Name", Description = "ArchitectureConstruction_Description", ResourceType = typeof(Resources.Enum.CareerCluster))]
        ArchitectureConstruction = 13,

        [Custom(Group = "EnergyEngineering_Group", Name = "EnergyEngineering_Name", Description = "EnergyEngineering_Description", ResourceType = typeof(Resources.Enum.CareerCluster))]
        EnergyEngineering = 14,

        [Custom(Group = "Manufacturing_Group", Name = "Manufacturing_Name", Description = "Manufacturing_Description", ResourceType = typeof(Resources.Enum.CareerCluster))]
        Manufacturing = 15,

        [Custom(Group = "TransportationDistributionLogistics_Group", Name = "TransportationDistributionLogistics_Name", Description = "TransportationDistributionLogistics_Description", ResourceType = typeof(Resources.Enum.CareerCluster))]
        TransportationDistributionLogistics = 16
    }
}