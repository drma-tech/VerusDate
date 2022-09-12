using VerusDate.Shared.Core;

namespace VerusDate.Shared.Enum
{
    /// <summary>
    /// https://www.ranker.com/crowdranked-list/favorite-types-of-cuisine
    /// </summary>
    public enum Food
    {
        [Custom(Name = "ItalianFood", ResourceType = typeof(Resources.Enum.Food))]
        ItalianFood = 1,

        [Custom(Name = "MexicanFood", ResourceType = typeof(Resources.Enum.Food))]
        MexicanFood = 2,

        [Custom(Name = "ThaiFood", ResourceType = typeof(Resources.Enum.Food))]
        ThaiFood = 3,

        [Custom(Name = "MediterraneanFood", ResourceType = typeof(Resources.Enum.Food))]
        MediterraneanFood = 4,

        [Custom(Name = "MoroccanFood", ResourceType = typeof(Resources.Enum.Food))]
        MoroccanFood = 5,

        [Custom(Name = "ChineseFood", ResourceType = typeof(Resources.Enum.Food))]
        ChineseFood = 6,

        [Custom(Name = "IndianCuisine", ResourceType = typeof(Resources.Enum.Food))]
        IndianCuisine = 7,

        [Custom(Name = "JapaneseCuisine", ResourceType = typeof(Resources.Enum.Food))]
        JapaneseCuisine = 8,

        [Custom(Name = "Seafood", ResourceType = typeof(Resources.Enum.Food))]
        Seafood = 9,

        [Custom(Name = "GreekFood", ResourceType = typeof(Resources.Enum.Food))]
        GreekFood = 10,

        [Custom(Name = "AmericanFood", ResourceType = typeof(Resources.Enum.Food))]
        AmericanFood = 11,

        [Custom(Name = "SoulFood", ResourceType = typeof(Resources.Enum.Food))]
        SoulFood = 12,

        [Custom(Name = "SouthernAmericanFood", ResourceType = typeof(Resources.Enum.Food))]
        SouthernAmericanFood = 13,

        [Custom(Name = "SpanishCuisine", ResourceType = typeof(Resources.Enum.Food))]
        SpanishCuisine = 14,

        [Custom(Name = "VietnameseFood", ResourceType = typeof(Resources.Enum.Food))]
        VietnameseFood = 15,

        [Custom(Name = "TexMexFood", ResourceType = typeof(Resources.Enum.Food))]
        TexMexFood = 16,

        [Custom(Name = "KoreanBarbecue", ResourceType = typeof(Resources.Enum.Food))]
        KoreanBarbecue = 17,

        [Custom(Name = "MiddleEasternFood", ResourceType = typeof(Resources.Enum.Food))]
        MiddleEasternFood = 18,

        [Custom(Name = "CajunFood", ResourceType = typeof(Resources.Enum.Food))]
        CajunFood = 19,

        [Custom(Name = "LebaneseFood", ResourceType = typeof(Resources.Enum.Food))]
        LebaneseFood = 20,

        [Custom(Name = "TexasBarbecue", ResourceType = typeof(Resources.Enum.Food))]
        TexasBarbecue = 21,

        [Custom(Name = "SicilianCuisine", ResourceType = typeof(Resources.Enum.Food))]
        SicilianCuisine = 22,

        [Custom(Name = "CaribbeanFood", ResourceType = typeof(Resources.Enum.Food))]
        CaribbeanFood = 23,

        [Custom(Name = "SouthKoreanFood", ResourceType = typeof(Resources.Enum.Food))]
        SouthKoreanFood = 24,

        [Custom(Name = "BrazilianBarbecue", ResourceType = typeof(Resources.Enum.Food))]
        BrazilianBarbecue = 25,

        [Custom(Name = "FrenchFood", ResourceType = typeof(Resources.Enum.Food))]
        FrenchFood = 26,

        [Custom(Name = "TurkishFood", ResourceType = typeof(Resources.Enum.Food))]
        TurkishFood = 27,

        [Custom(Name = "JunkFood", ResourceType = typeof(Resources.Enum.Food))]
        JunkFood = 28,

        [Custom(Name = "MidwesternFood", ResourceType = typeof(Resources.Enum.Food))]
        MidwesternFood = 29,

        [Custom(Name = "PortugueseFood", ResourceType = typeof(Resources.Enum.Food))]
        PortugueseFood = 30,

        [Custom(Name = "GermanFood", ResourceType = typeof(Resources.Enum.Food))]
        GermanFood = 31,

        [Custom(Name = "BrazilianFood", ResourceType = typeof(Resources.Enum.Food))]
        BrazilianFood = 32,

        [Custom(Name = "CubanFood", ResourceType = typeof(Resources.Enum.Food))]
        CubanFood = 33,

        [Custom(Name = "IrishFood", ResourceType = typeof(Resources.Enum.Food))]
        IrishFood = 34,

        [Custom(Name = "TunisianCuisine", ResourceType = typeof(Resources.Enum.Food))]
        TunisianCuisine = 35,

        [Custom(Name = "UnitedKingdomCuisine", ResourceType = typeof(Resources.Enum.Food))]
        UnitedKingdomCuisine = 36,

        [Custom(Name = "SouthIndianCuisine", ResourceType = typeof(Resources.Enum.Food))]
        SouthIndianCuisine = 37,

        [Custom(Name = "JamaicanFood", ResourceType = typeof(Resources.Enum.Food))]
        JamaicanFood = 38,

        [Custom(Name = "CanadianCuisine", ResourceType = typeof(Resources.Enum.Food))]
        CanadianCuisine = 39,

        [Custom(Name = "VegetarianFood", ResourceType = typeof(Resources.Enum.Food))]
        VegetarianFood = 40,

        [Custom(Name = "FilipinoCuisine", ResourceType = typeof(Resources.Enum.Food))]
        FilipinoCuisine = 41,

        [Custom(Name = "ArgentinianFood", ResourceType = typeof(Resources.Enum.Food))]
        ArgentinianFood = 42,

        [Custom(Name = "MalaysianFood", ResourceType = typeof(Resources.Enum.Food))]
        MalaysianFood = 43,

        [Custom(Name = "IranianCuisine", ResourceType = typeof(Resources.Enum.Food))]
        IranianCuisine = 44,

        [Custom(Name = "IndonesianCuisine", ResourceType = typeof(Resources.Enum.Food))]
        IndonesianCuisine = 45,

        [Custom(Name = "SichuanCuisine", ResourceType = typeof(Resources.Enum.Food))]
        SichuanCuisine = 46,

        [Custom(Name = "JewishCuisine", ResourceType = typeof(Resources.Enum.Food))]
        JewishCuisine = 47,

        [Custom(Name = "SwissCuisine", ResourceType = typeof(Resources.Enum.Food))]
        SwissCuisine = 48,

        [Custom(Name = "ShanghaineseCuisine", ResourceType = typeof(Resources.Enum.Food))]
        ShanghaineseCuisine = 49,

        [Custom(Name = "SingaporeanFood", ResourceType = typeof(Resources.Enum.Food))]
        SingaporeanFood = 50,
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