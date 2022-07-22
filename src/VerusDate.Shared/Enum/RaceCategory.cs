using VerusDate.Shared.Core;

namespace VerusDate.Shared.Enum
{
    /// <summary>
    /// https://www.census.gov/topics/population/race/about.html
    /// https://www.census.gov/quickfacts/fact/note/US/RHI625221
    /// </summary>
    public enum RaceCategory
    {
        [Custom(Name = "White_Name", Description = "White_Description", ResourceType = typeof(Resources.Enum.RaceCategory))]
        White = 1,

        [Custom(Name = "BlackAfricanAmerican_Name", Description = "BlackAfricanAmerican_Description", ResourceType = typeof(Resources.Enum.RaceCategory))]
        BlackAfricanAmerican = 2,

        [Custom(Name = "AmericanIndianAlaskaNative_Name", Description = "AmericanIndianAlaskaNative_Description", ResourceType = typeof(Resources.Enum.RaceCategory))]
        AmericanIndianAlaskaNative = 3,

        [Custom(Name = "Asian_Name", Description = "Asian_Description", ResourceType = typeof(Resources.Enum.RaceCategory))]
        Asian = 4,

        [Custom(Name = "NativeHawaiianOtherPacificIslander_Name", Description = "NativeHawaiianOtherPacificIslander_Description", ResourceType = typeof(Resources.Enum.RaceCategory))]
        NativeHawaiianOtherPacificIslander = 5,

        [Custom(Name = "TwoMoreRaces_Name", Description = "TwoMoreRaces_Description", ResourceType = typeof(Resources.Enum.RaceCategory))]
        TwoMoreRaces = 6,

        [Custom(Name = "Other_Name", Description = "Other_Description", ResourceType = typeof(Resources.Enum.RaceCategory))]
        Other = 7
    }

    public enum RaceCategoryOld
    {
        [Custom(Name = "Índio Americano ou Nativo do Alasca", Description = "Pessoa originária de qualquer um dos povos originais da América do Norte e do Sul (incluindo América Central) e que mantém afiliação tribal ou vínculo com a comunidade")]
        AmericanIndianAlaskaNative = 1,

        [Custom(Name = "Asiática", Description = "Uma pessoa com origem em qualquer um dos povos originais do Extremo Oriente, Sudeste Asiático ou subcontinente indiano, incluindo, por exemplo, Camboja, China, Índia, Japão, Coréia, Malásia, Paquistão, Ilhas Filipinas, Tailândia e Vietnã")]
        Asian = 2,

        [Custom(Name = "Negro ou Afro-Americano", Description = "Uma pessoa com origem em qualquer um dos grupos raciais negros da África. Termos como 'haitiano' ou 'negro' podem ser usados além de 'preto ou afro-americano'")]
        Black_AfricanAmerican = 3,

        [Custom(Name = "Nativo do Havaí ou de outras ilhas do Pacífico", Description = "Uma pessoa com origem em qualquer um dos povos originais do Havaí, Guam, Samoa ou outras ilhas do Pacífico")]
        NativeHawaiian_OtherPacificIslander = 4,

        [Custom(Name = "Branca", Description = "Uma pessoa com origem em qualquer um dos povos originais da Europa, Oriente Médio ou Norte da África")]
        White = 5,

        [Custom(Name = "Raças Mistas", Description = "Caso possua duas ou mais raças entre as disponíveis")]
        MixedRaces = 6,

        [Custom(Name = "Outra", Description = "Caso não possua nenhuma das raças entre as disponíveis")]
        Other = 7,

        //listed below: it's not race but ethnicity

        //[Custom(Name = "Hispânico ou Latino", Description = "Pessoa da cultura cubana, mexicana, porto-riquenha, cubana, sul ou centro-americana ou outra cultura ou origem espanhola, independentemente da raça. O termo 'origem espanhola' pode ser usado além de 'hispânico ou latino'")]
        //Hispanic_Latino = 8,

        //[Custom(Name = "Não Hispânico ou Latino")]
        //NotHispanicOrLatino = 9
    }
}