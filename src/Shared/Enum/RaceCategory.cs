using System.ComponentModel.DataAnnotations;

namespace VerusDate.Shared.Enum
{
    public enum RaceCategory
    {
        [Display(Name = "Índio Americano ou Nativo do Alasca", Description = "Pessoa originária de qualquer um dos povos originais da América do Norte e do Sul (incluindo América Central) e que mantém afiliação tribal ou vínculo com a comunidade")]
        AmericanIndianAlaskaNative = 1,

        [Display(Name = "Asiática", Description = "Uma pessoa com origem em qualquer um dos povos originais do Extremo Oriente, Sudeste Asiático ou subcontinente indiano, incluindo, por exemplo, Camboja, China, Índia, Japão, Coréia, Malásia, Paquistão, Ilhas Filipinas, Tailândia e Vietnã")]
        Asian = 2,

        [Display(Name = "Negro ou Afro-Americano", Description = "Uma pessoa com origem em qualquer um dos grupos raciais negros da África. Termos como 'haitiano' ou 'negro' podem ser usados além de 'preto ou afro-americano'")]
        Black_AfricanAmerican = 3,

        [Display(Name = "Nativo do Havaí ou de outras ilhas do Pacífico", Description = "Uma pessoa com origem em qualquer um dos povos originais do Havaí, Guam, Samoa ou outras ilhas do Pacífico")]
        NativeHawaiian_OtherPacificIslander = 4,

        [Display(Name = "Branca", Description = "Uma pessoa com origem em qualquer um dos povos originais da Europa, Oriente Médio ou Norte da África")]
        White = 5,

        [Display(Name = "Raças Mistas", Description = "Caso possua duas ou mais raças entre as disponíveis")]
        MixedRaces = 6,

        [Display(Name = "Outra", Description = "Caso não possua nenhuma das raças entre as disponíveis")]
        Other = 7,

        //listados abaixo: não é raça e sim etinia

        //[Display(Name = "Hispânico ou Latino", Description = "Pessoa da cultura cubana, mexicana, porto-riquenha, cubana, sul ou centro-americana ou outra cultura ou origem espanhola, independentemente da raça. O termo 'origem espanhola' pode ser usado além de 'hispânico ou latino'")]
        //Hispanic_Latino = 8,

        //[Display(Name = "Não Hispânico ou Latino")]
        //NotHispanicOrLatino = 9
    }
}