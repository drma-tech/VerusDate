using VerusDate.Shared.Core;

namespace VerusDate.Shared.Enum
{
    /// <summary>
    /// https://en.wikipedia.org/wiki/List_of_languages_by_the_number_of_countries_in_which_they_are_recognized_as_an_official_language
    /// </summary>
    ///
    public enum Language
    {
        [Custom(Name = "English", ResourceType = typeof(Resources.Enum.Language))]
        English = 1,

        [Custom(Name = "French", ResourceType = typeof(Resources.Enum.Language))]
        French = 2,

        [Custom(Name = "Arabic", ResourceType = typeof(Resources.Enum.Language))]
        Arabic = 3,

        [Custom(Name = "Spanish", ResourceType = typeof(Resources.Enum.Language))]
        Spanish = 4,

        [Custom(Name = "Portuguese", ResourceType = typeof(Resources.Enum.Language))]
        Portuguese = 5,

        [Custom(Name = "German", ResourceType = typeof(Resources.Enum.Language))]
        German = 6,

        [Custom(Name = "Russian", ResourceType = typeof(Resources.Enum.Language))]
        Russian = 7,

        [Custom(Name = "Swahili", ResourceType = typeof(Resources.Enum.Language))]
        Swahili = 8,

        [Custom(Name = "SerboCroatian", ResourceType = typeof(Resources.Enum.Language))]
        SerboCroatian = 9,

        [Custom(Name = "Italian", ResourceType = typeof(Resources.Enum.Language))]
        Italian = 10,

        [Custom(Name = "Malay", ResourceType = typeof(Resources.Enum.Language))]
        Malay = 11,

        [Custom(Name = "Tswana", ResourceType = typeof(Resources.Enum.Language))]
        Tswana = 12,

        [Custom(Name = "Persian", ResourceType = typeof(Resources.Enum.Language))]
        Persian = 13,

        [Custom(Name = "Dutch", ResourceType = typeof(Resources.Enum.Language))]
        Dutch = 14,

        [Custom(Name = "Sotho", ResourceType = typeof(Resources.Enum.Language))]
        Sotho = 15,

        [Custom(Name = "Albanian", ResourceType = typeof(Resources.Enum.Language))]
        Albanian = 16,

        [Custom(Name = "StandardChinese", ResourceType = typeof(Resources.Enum.Language))]
        StandardChinese = 17,

        [Custom(Name = "Romanian", ResourceType = typeof(Resources.Enum.Language))]
        Romanian = 18,

        [Custom(Name = "Turkish", ResourceType = typeof(Resources.Enum.Language))]
        Turkish = 19,

        [Custom(Name = "Berber", ResourceType = typeof(Resources.Enum.Language))]
        Berber = 20,

        [Custom(Name = "Aymara", ResourceType = typeof(Resources.Enum.Language))]
        Aymara = 21,

        [Custom(Name = "Quechua", ResourceType = typeof(Resources.Enum.Language))]
        Quechua = 22,

        [Custom(Name = "RwandaRundi", ResourceType = typeof(Resources.Enum.Language))]
        RwandaRundi = 23,

        [Custom(Name = "Tigrinya", ResourceType = typeof(Resources.Enum.Language))]
        Tigrinya = 24,

        [Custom(Name = "Swati", ResourceType = typeof(Resources.Enum.Language))]
        Swati = 25,

        [Custom(Name = "Greek", ResourceType = typeof(Resources.Enum.Language))]
        Greek = 26,

        [Custom(Name = "HindiUrdu", ResourceType = typeof(Resources.Enum.Language))]
        HindiUrdu = 27,

        [Custom(Name = "Chichewa", ResourceType = typeof(Resources.Enum.Language))]
        Chichewa = 28,

        [Custom(Name = "Korean", ResourceType = typeof(Resources.Enum.Language))]
        Korean = 29,

        [Custom(Name = "Guarani", ResourceType = typeof(Resources.Enum.Language))]
        Guarani = 30,

        [Custom(Name = "Venda", ResourceType = typeof(Resources.Enum.Language))]
        Venda = 31,

        [Custom(Name = "Xhosa", ResourceType = typeof(Resources.Enum.Language))]
        Xhosa = 32,

        [Custom(Name = "Tamil", ResourceType = typeof(Resources.Enum.Language))]
        Tamil = 33,

        [Custom(Name = "Swedish", ResourceType = typeof(Resources.Enum.Language))]
        Swedish = 34,

        [Custom(Name = "Armenian", ResourceType = typeof(Resources.Enum.Language))]
        Armenian = 35,

        [Custom(Name = "Somali", ResourceType = typeof(Resources.Enum.Language))]
        Somali = 36
    }

    public enum LanguageOld
    {
        [Custom(Name = "Chinês Mandarim")]
        MandarinChinese = 1,

        [Custom(Name = "Espanhol")]
        Spanish = 2,

        [Custom(Name = "Inglês")]
        English = 3,

        [Custom(Name = "Hindi")]
        Hindi = 4,

        [Custom(Name = "Português")]
        Portuguese = 5,

        [Custom(Name = "Bengali")]
        Bengali = 6,

        [Custom(Name = "Russo")]
        Russian = 7,

        [Custom(Name = "Japonês")]
        Japanese = 8,

        [Custom(Name = "Punjabi")]
        Punjabi = 9,

        [Custom(Name = "Yue Chinês")]
        YueChinese = 10,

        [Custom(Name = "Vietnamita")]
        Vietnamese = 11,

        [Custom(Name = "Marati")]
        Marathi = 12,

        [Custom(Name = "Telugu")]
        Telugu = 13,

        [Custom(Name = "Turco")]
        Turkish = 14,

        [Custom(Name = "Wu Chinês")]
        WuChinese = 15,

        [Custom(Name = "Coreano")]
        Korean = 16,

        [Custom(Name = "Francês")]
        French = 17,

        [Custom(Name = "Alemão")]
        German = 18,

        [Custom(Name = "Tâmil")]
        Tamil = 19,

        [Custom(Name = "Urdu")]
        Urdu = 20,

        [Custom(Name = "Javanês")]
        Javanese = 21,

        [Custom(Name = "Italiano")]
        Italian = 22,

        [Custom(Name = "Egyptian Arabic")]
        EgyptianArabic = 23,

        [Custom(Name = "Gujarati")]
        Gujarati = 24,

        [Custom(Name = "Iranian Persian")]
        IranianPersian = 25,

        [Custom(Name = "Bhojpuri")]
        Bhojpuri = 26,

        [Custom(Name = "Southern Min")]
        SouthernMin = 27,

        [Custom(Name = "Hakka Chinese")]
        HakkaChinese = 28,

        [Custom(Name = "Jin Chinese")]
        JinChinese = 29,

        [Custom(Name = "Hausa")]
        Hausa = 30,

        [Custom(Name = "Kannada")]
        Kannada = 31,

        [Custom(Name = "Indonésio")]
        Indonesian = 32,

        [Custom(Name = "Yoruba")]
        Yoruba = 33,

        [Custom(Name = "Polish")]
        Polish = 34,

        [Custom(Name = "Xiang Chinese")]
        XiangChinese = 35,

        [Custom(Name = "Malayalam")]
        Malayalam = 36,

        [Custom(Name = "Odia")]
        Odia = 37,

        [Custom(Name = "Maithili")]
        Maithili = 38,

        [Custom(Name = "Sudanese Arabic")]
        SudaneseArabic = 39,

        [Custom(Name = "Burmese")]
        Burmese = 40,

        [Custom(Name = "Eastern Punjabi")]
        EasternPunjabi = 41,

        [Custom(Name = "Sunda")]
        Sunda = 42,

        [Custom(Name = "Algerian Arabic")]
        AlgerianArabic = 43,

        [Custom(Name = "Moroccan Arabic")]
        MoroccanArabic = 44,

        [Custom(Name = "Ukrainian")]
        Ukrainian = 45,

        [Custom(Name = "Igbo")]
        Igbo = 46,

        [Custom(Name = "Northern Uzbek")]
        NorthernUzbek = 47,

        [Custom(Name = "Sindhi")]
        Sindhi = 48,

        [Custom(Name = "North Levantine Arabic")]
        NorthLevantineArabic = 49,

        [Custom(Name = "Romanian")]
        Romanian = 50,

        [Custom(Name = "Tagalog")]
        Tagalog = 51,

        //Dutch 52

        //Saʽidi Arabic 53

        //Gan Chinese 54

        [Custom(Name = "Amharic")]
        Amharic = 55,

        //Northern Pashto 56

        //Magahi 57

        [Custom(Name = "Thai")]
        Thai = 58,

        //Saraiki 59

        //Khmer 60

        //Chhattisgarhi 61

        //Somali 62

        //Malaysian 63

        //Cebuano 64

        //Nepali 65

        //Mesopotamian Arabic 66

        //Assamese 67

        //Sinhalese 68

        //Northern Kurdish 69

        //Hejazi Arabic 70

        //Nigerian Fulfulde 71

        //Bavarian 72

        //South Azerbaijani 73

        //Greek 74

        //Chittagonian 75

        //Kazakh 76

        //Deccan 77

        //Hungarian 78

        //Kinyarwanda 79

        //Zulu 80

        //South Levantine Arabic 81

        //Tunisian Arabic 82

        //Sanaani Spoken Arabic 83

        //Northern Min 84

        //Southern Pashto 85

        //Rundi 86

        //Czech 87

        //Taʽizzi-Adeni Arabic 88

        //Uyghur 89

        //Eastern Min 90

        //Sylheti 91
    }
}