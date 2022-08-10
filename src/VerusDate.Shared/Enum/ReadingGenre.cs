using VerusDate.Shared.Core;

namespace VerusDate.Shared.Enum
{
    public enum ReadingGenre
    {
        [Custom(Name = "FictionGenres_Name", Description = "FictionGenres_Description", ResourceType = typeof(Resources.Enum.ReadingGenre))]
        FictionGenres = 10,

        [Custom(Name = "Biography_Name", Description = "Biography_Description", ResourceType = typeof(Resources.Enum.ReadingGenre))]
        Biography = 31,

        [Custom(Name = "Comics_Name", Description = "Comics_Description", ResourceType = typeof(Resources.Enum.ReadingGenre))]
        Comics = 32,

        [Custom(Name = "Essay_Name", Description = "Essay_Description", ResourceType = typeof(Resources.Enum.ReadingGenre))]
        Essay = 33,

        [Custom(Name = "Journalism_Name", Description = "Journalism_Description", ResourceType = typeof(Resources.Enum.ReadingGenre))]
        Journalism = 34,

        [Custom(Name = "Memoir_Name", Description = "Memoir_Description", ResourceType = typeof(Resources.Enum.ReadingGenre))]
        Memoir = 35,

        [Custom(Name = "NarrativeNonfictionPersonalNarrative_Name", Description = "NarrativeNonfictionPersonalNarrative_Description", ResourceType = typeof(Resources.Enum.ReadingGenre))]
        NarrativeNonfictionPersonalNarrative = 36,

        [Custom(Name = "Reference_Name", Description = "Reference_Description", ResourceType = typeof(Resources.Enum.ReadingGenre))]
        Reference = 37,

        [Custom(Name = "SelfHelp_Name", Description = "SelfHelp_Description", ResourceType = typeof(Resources.Enum.ReadingGenre))]
        SelfHelp = 38,

        [Custom(Name = "ScientificArticle_Name", Description = "ScientificArticle_Description", ResourceType = typeof(Resources.Enum.ReadingGenre))]
        ScientificArticle = 39,

        [Custom(Name = "Textbook_Name", Description = "Textbook_Description", ResourceType = typeof(Resources.Enum.ReadingGenre))]
        Textbook = 40
    }
}