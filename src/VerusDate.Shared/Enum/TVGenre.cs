using VerusDate.Shared.Core;

namespace VerusDate.Shared.Enum
{
    /// <summary>
    /// https://en.wikipedia.org/wiki/List_of_television_formats_and_genres#Genres
    /// https://www.esolcourses.com/content/topics/tv/tv-show-genres.html
    /// </summary>
    public enum TVGenre
    {
        [Custom(Name = "CartoonAnime_Name", Description = "CartoonAnime_Description", ResourceType = typeof(Resources.Enum.TVGenre))]
        CartoonAnime = 1,

        [Custom(Name = "CookingShow_Name", Description = "CookingShow_Description", ResourceType = typeof(Resources.Enum.TVGenre))]
        CookingShow = 2,

        [Custom(Name = "Documentary_Name", Description = "Documentary_Description", ResourceType = typeof(Resources.Enum.TVGenre))]
        Documentary = 3,

        [Custom(Name = "Educational_Name", Description = "Educational_Description", ResourceType = typeof(Resources.Enum.TVGenre))]
        Educational = 4,

        [Custom(Name = "GameShow_Name", Description = "GameShow_Description", ResourceType = typeof(Resources.Enum.TVGenre))]
        GameShow = 5,

        [Custom(Name = "KidsChildren_Name", Description = "KidsChildren_Description", ResourceType = typeof(Resources.Enum.TVGenre))]
        KidsChildren = 6,

        [Custom(Name = "Lifestyle_Name", Description = "Lifestyle_Description", ResourceType = typeof(Resources.Enum.TVGenre))]
        Lifestyle = 7,

        [Custom(Name = "MusicTelevision_Name", Description = "MusicTelevision_Description", ResourceType = typeof(Resources.Enum.TVGenre))]
        MusicTelevision = 8,

        [Custom(Name = "NewsProgramm_Name", Description = "NewsProgramm_Description", ResourceType = typeof(Resources.Enum.TVGenre))]
        NewsProgramm = 9,

        [Custom(Name = "RealityTV_Name", Description = "RealityTV_Description", ResourceType = typeof(Resources.Enum.TVGenre))]
        RealityTV = 10,

        [Custom(Name = "Religious_Name", Description = "Religious_Description", ResourceType = typeof(Resources.Enum.TVGenre))]
        Religious = 11,

        [Custom(Name = "Shopping_Name", Description = "Shopping_Description", ResourceType = typeof(Resources.Enum.TVGenre))]
        Shopping = 12,

        [Custom(Name = "SoapOpera_Name", Description = "SoapOpera_Description", ResourceType = typeof(Resources.Enum.TVGenre))]
        SoapOpera = 13,

        [Custom(Name = "Sports_Name", Description = "Sports_Description", ResourceType = typeof(Resources.Enum.TVGenre))]
        Sports = 14,

        [Custom(Name = "TalkShow_Name", Description = "TalkShow_Description", ResourceType = typeof(Resources.Enum.TVGenre))]
        TalkShow = 15,

        [Custom(Name = "TVSeries_Name", Description = "TVSeries_Description", ResourceType = typeof(Resources.Enum.TVGenre))]
        TVSeries = 16,

        [Custom(Name = "VarietyShow_Name", Description = "VarietyShow_Description", ResourceType = typeof(Resources.Enum.TVGenre))]
        VarietyShow = 17
    }
}