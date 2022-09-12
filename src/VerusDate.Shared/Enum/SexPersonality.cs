using VerusDate.Shared.Core;

namespace VerusDate.Shared.Enum
{
    /// <summary>
    /// https://aindasolteira.blogs.sapo.pt/qual-a-tua-personalidade-sexual-200268
    /// https://www.mindbodygreen.com/articles/sex-personality-types-by-sex-therapist-vanessa-marin
    /// </summary>
    public enum SexPersonality
    {
        [Custom(Name = "Decompresser_Name", Description = "Decompresser_Description", ResourceType = typeof(Resources.Enum.SexPersonality))]
        Decompresser = 1,

        [Custom(Name = "Explorer_Name", Description = "Explorer_Description", ResourceType = typeof(Resources.Enum.SexPersonality))]
        Explorer = 2,

        [Custom(Name = "FairTrader_Name", Description = "FairTrader_Description", ResourceType = typeof(Resources.Enum.SexPersonality))]
        FairTrader = 3,

        [Custom(Name = "Giver_Name", Description = "Giver_Description", ResourceType = typeof(Resources.Enum.SexPersonality))]
        Giver = 4,

        [Custom(Name = "Guardian_Name", Description = "Guardian_Description", ResourceType = typeof(Resources.Enum.SexPersonality))]
        Guardian = 5,

        [Custom(Name = "PassionPursuer_Name", Description = "PassionPursuer_Description", ResourceType = typeof(Resources.Enum.SexPersonality))]
        PassionPursuer = 6,

        [Custom(Name = "PleasureSeeker_Name", Description = "PleasureSeeker_Description", ResourceType = typeof(Resources.Enum.SexPersonality))]
        PleasureSeeker = 7,

        [Custom(Name = "Prioritizer_Name", Description = "Prioritizer_Description", ResourceType = typeof(Resources.Enum.SexPersonality))]
        Prioritizer = 8,

        [Custom(Name = "Romantic_Name", Description = "Romantic_Description", ResourceType = typeof(Resources.Enum.SexPersonality))]
        Romantic = 9,

        [Custom(Name = "Spiritualist_Name", Description = "Spiritualist_Description", ResourceType = typeof(Resources.Enum.SexPersonality))]
        Spiritualist = 10,

        [Custom(Name = "ThrillSeeker_Name", Description = "ThrillSeeker_Description", ResourceType = typeof(Resources.Enum.SexPersonality))]
        ThrillSeeker = 11
    }
}