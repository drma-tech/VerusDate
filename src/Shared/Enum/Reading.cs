using System.ComponentModel.DataAnnotations;

namespace VerusDate.Shared.Enum
{
    public enum Reading
    {
        [Display(Name = "Ação e Aventura")]
        ActionAndAdventure = 1,

        [Display(Name = "Literatura Feminina")]
        ChickLit = 2,

        [Display(Name = "Literatura Infantil")]
        ChildrenBooks = 3, //Children’s books

        [Display(Name = "Contemporânea")]
        Contemporary = 4,

        [Display(Name = "Crime")]
        Crime = 5,

        [Display(Name = "Literatura Erótica")]
        Erotica = 6,

        [Display(Name = "Family Saga")]
        FamilySaga = 7,

        [Display(Name = "Fantasia")]
        Fantasy = 8,

        [Display(Name = "Ficção Histórica")]
        HistoricalFiction = 9,

        [Display(Name = "Terror")]
        Horror = 10,

        [Display(Name = "Humor")]
        Humour = 11,

        [Display(Name = "Militar e Espionagem")]
        MilitaryAndEspionage = 12,

        [Display(Name = "Literatura MultiCultural")]
        Multicultural = 13,

        [Display(Name = "Mistério")]
        Mystery = 14,

        [Display(Name = "Religioso e Inspirador")]
        ReligiousAndInspirational = 15,

        [Display(Name = "Romance")]
        Romance = 16,

        [Display(Name = "Ficção Científica")]
        ScienceFiction = 17,

        [Display(Name = "Thrillers e Suspense")]
        ThrillersAndSuspense = 18,

        [Display(Name = "Faroeste")]
        Western = 19,

        [Display(Name = "Filosofia")]
        Philosophy = 20,

        [Display(Name = "Distopia")]
        Dystopia = 21,

        [Display(Name = "Mitologia")]
        Mythology = 22,

        [Display(Name = "Biografia / Memória")]
        BiographyMemoir = 23,

        [Display(Name = "Literatura Especializada")]
        SpecialisedLiterature = 24,

        [Display(Name = "Auto Ajuda")]
        SelfHelp = 25, //Self-help

        [Display(Name = "Contos")]
        ShortStories = 26,

        [Display(Name = "Clássicos")]
        Classics = 27,

        [Display(Name = "Gibi / Mangá")]
        ComicsManga = 28
    }
}