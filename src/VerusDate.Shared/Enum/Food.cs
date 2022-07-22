using VerusDate.Shared.Core;

namespace VerusDate.Shared.Enum
{
    /// <summary>
    /// https://food.allwomenstalk.com/cuisines-of-the-world/
    /// https://www.ranker.com/crowdranked-list/favorite-types-of-cuisine
    /// </summary>
    public enum Food
    {
        [Custom(Name = "ItalianFood", ResourceType = typeof(Resources.Enum.Food))]
        ItalianFood,

        [Custom(Name = "MexicanFood", ResourceType = typeof(Resources.Enum.Food))]
        MexicanFood,

        [Custom(Name = "ThaiFood", ResourceType = typeof(Resources.Enum.Food))]
        ThaiFood,

        [Custom(Name = "MediterraneanFood", ResourceType = typeof(Resources.Enum.Food))]
        MediterraneanFood,

        [Custom(Name = "MoroccanFood", ResourceType = typeof(Resources.Enum.Food))]
        MoroccanFood,

        [Custom(Name = "ChineseFood", ResourceType = typeof(Resources.Enum.Food))]
        ChineseFood,

        [Custom(Name = "IndianCuisine", ResourceType = typeof(Resources.Enum.Food))]
        IndianCuisine,

        [Custom(Name = "JapaneseCuisine", ResourceType = typeof(Resources.Enum.Food))]
        JapaneseCuisine,

        [Custom(Name = "Seafood", ResourceType = typeof(Resources.Enum.Food))]
        Seafood,

        [Custom(Name = "GreekFood", ResourceType = typeof(Resources.Enum.Food))]
        GreekFood,

        [Custom(Name = "AmericanFood", ResourceType = typeof(Resources.Enum.Food))]
        AmericanFood,

        [Custom(Name = "SoulFood", ResourceType = typeof(Resources.Enum.Food))]
        SoulFood,

        [Custom(Name = "SouthernAmericanFood", ResourceType = typeof(Resources.Enum.Food))]
        SouthernAmericanFood,

        [Custom(Name = "SpanishCuisine", ResourceType = typeof(Resources.Enum.Food))]
        SpanishCuisine,

        [Custom(Name = "VietnameseFood", ResourceType = typeof(Resources.Enum.Food))]
        VietnameseFood,

        [Custom(Name = "TexMexFood", ResourceType = typeof(Resources.Enum.Food))]
        TexMexFood,

        [Custom(Name = "KoreanBarbecue", ResourceType = typeof(Resources.Enum.Food))]
        KoreanBarbecue,

        [Custom(Name = "MiddleEasternFood", ResourceType = typeof(Resources.Enum.Food))]
        MiddleEasternFood,

        [Custom(Name = "CajunFood", ResourceType = typeof(Resources.Enum.Food))]
        CajunFood,

        [Custom(Name = "LebaneseFood", ResourceType = typeof(Resources.Enum.Food))]
        LebaneseFood,

        [Custom(Name = "TexasBarbecue", ResourceType = typeof(Resources.Enum.Food))]
        TexasBarbecue,

        [Custom(Name = "SicilianCuisine", ResourceType = typeof(Resources.Enum.Food))]
        SicilianCuisine,

        [Custom(Name = "CaribbeanFood", ResourceType = typeof(Resources.Enum.Food))]
        CaribbeanFood,

        [Custom(Name = "SouthKoreanFood", ResourceType = typeof(Resources.Enum.Food))]
        SouthKoreanFood,

        [Custom(Name = "BrazilianBarbecue", ResourceType = typeof(Resources.Enum.Food))]
        BrazilianBarbecue,

        [Custom(Name = "FrenchFood", ResourceType = typeof(Resources.Enum.Food))]
        FrenchFood,

        [Custom(Name = "TurkishFood", ResourceType = typeof(Resources.Enum.Food))]
        TurkishFood,

        [Custom(Name = "JunkFood", ResourceType = typeof(Resources.Enum.Food))]
        JunkFood,

        [Custom(Name = "MidwesternFood", ResourceType = typeof(Resources.Enum.Food))]
        MidwesternFood,

        [Custom(Name = "PortugueseFood", ResourceType = typeof(Resources.Enum.Food))]
        PortugueseFood,

        [Custom(Name = "GermanFood", ResourceType = typeof(Resources.Enum.Food))]
        GermanFood,

        [Custom(Name = "BrazilianFood", ResourceType = typeof(Resources.Enum.Food))]
        BrazilianFood,

        [Custom(Name = "CubanFood", ResourceType = typeof(Resources.Enum.Food))]
        CubanFood,

        [Custom(Name = "IrishFood", ResourceType = typeof(Resources.Enum.Food))]
        IrishFood,

        [Custom(Name = "TunisianCuisine", ResourceType = typeof(Resources.Enum.Food))]
        TunisianCuisine,

        [Custom(Name = "UnitedKingdomCuisine", ResourceType = typeof(Resources.Enum.Food))]
        UnitedKingdomCuisine,

        [Custom(Name = "SouthIndianCuisine", ResourceType = typeof(Resources.Enum.Food))]
        SouthIndianCuisine,

        [Custom(Name = "JamaicanFood", ResourceType = typeof(Resources.Enum.Food))]
        JamaicanFood,

        [Custom(Name = "CanadianCuisine", ResourceType = typeof(Resources.Enum.Food))]
        CanadianCuisine,

        [Custom(Name = "VegetarianFood", ResourceType = typeof(Resources.Enum.Food))]
        VegetarianFood,

        [Custom(Name = "FilipinoCuisine", ResourceType = typeof(Resources.Enum.Food))]
        FilipinoCuisine,

        [Custom(Name = "ArgentinianFood", ResourceType = typeof(Resources.Enum.Food))]
        ArgentinianFood,

        [Custom(Name = "MalaysianFood", ResourceType = typeof(Resources.Enum.Food))]
        MalaysianFood,

        [Custom(Name = "IranianCuisine", ResourceType = typeof(Resources.Enum.Food))]
        IranianCuisine,

        [Custom(Name = "IndonesianCuisine", ResourceType = typeof(Resources.Enum.Food))]
        IndonesianCuisine,

        [Custom(Name = "SichuanCuisine", ResourceType = typeof(Resources.Enum.Food))]
        SichuanCuisine,

        [Custom(Name = "JewishCuisine", ResourceType = typeof(Resources.Enum.Food))]
        JewishCuisine,

        [Custom(Name = "SwissCuisine", ResourceType = typeof(Resources.Enum.Food))]
        SwissCuisine,

        [Custom(Name = "ShanghaineseCuisine", ResourceType = typeof(Resources.Enum.Food))]
        ShanghaineseCuisine,

        [Custom(Name = "SingaporeanFood", ResourceType = typeof(Resources.Enum.Food))]
        SingaporeanFood,
    }

    public enum FoodOld
    {
        [Custom(Name = "Italian", ResourceType = typeof(Resources.Enum.Food))]
        Italian = 1,

        [Custom(Name = "French", ResourceType = typeof(Resources.Enum.Food))]
        French = 2,

        [Custom(Name = "German", ResourceType = typeof(Resources.Enum.Food))]
        German = 3,

        [Custom(Name = "Greek", ResourceType = typeof(Resources.Enum.Food))]
        Greek = 4,

        [Custom(Name = "Spanish", ResourceType = typeof(Resources.Enum.Food))]
        Spanish = 5,

        [Custom(Name = "MiddleEastern", ResourceType = typeof(Resources.Enum.Food))]
        MiddleEastern = 6,

        [Custom(Name = "Indian", ResourceType = typeof(Resources.Enum.Food))]
        Indian = 7,

        [Custom(Name = "Chinese", ResourceType = typeof(Resources.Enum.Food))]
        Chinese = 8,

        [Custom(Name = "Thai", ResourceType = typeof(Resources.Enum.Food))]
        Thai = 9,

        [Custom(Name = "Vietnamese", ResourceType = typeof(Resources.Enum.Food))]
        Vietnamese = 10,

        [Custom(Name = "Japanese", ResourceType = typeof(Resources.Enum.Food))]
        Japanese = 11,

        [Custom(Name = "Korean", ResourceType = typeof(Resources.Enum.Food))]
        Korean = 12,

        [Custom(Name = "Cuban", ResourceType = typeof(Resources.Enum.Food))]
        Cuban = 13,

        [Custom(Name = "PuertoRican", ResourceType = typeof(Resources.Enum.Food))]
        PuertoRican = 14,

        [Custom(Name = "SouthAmericanCuisine", ResourceType = typeof(Resources.Enum.Food))]
        SouthAmericanCuisine = 15,

        [Custom(Name = "Mexican", ResourceType = typeof(Resources.Enum.Food))]
        Mexican = 16,

        [Custom(Name = "AfricanAmerican", ResourceType = typeof(Resources.Enum.Food))]
        AfricanAmerican = 17,

        [Custom(Name = "Fusionkitchen", ResourceType = typeof(Resources.Enum.Food))]
        Fusionkitchen = 18,

        [Custom(Name = "StreetFood", ResourceType = typeof(Resources.Enum.Food))]
        StreetFood = 19,

        [Custom(Name = "FastFood", ResourceType = typeof(Resources.Enum.Food))]
        FastFood = 20,

        [Custom(Name = "PlainFare", ResourceType = typeof(Resources.Enum.Food))]
        PlainFare = 21
    }
}