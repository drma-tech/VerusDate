using System.ComponentModel.DataAnnotations;

namespace VerusDate.Shared.Enum
{
    public enum LoveLanguage
    {
        [Display(Name = "Palavras de Afirmação", Description = "Esta linguagem do amor expressa o amor com palavras que edificam o seu parceiro. Elogios verbais não precisam ser complicados; os elogios mais curtos e simples podem ser os mais eficazes.")]
        WordsOfAffirmation = 1,

        [Display(Name = "Gestos de Serviço", Description = "Essa linguagem do amor se expressa fazendo coisas que você sabe que seu cônjuge gostaria. Cozinhar uma refeição, lavar a roupa e pegar uma receita são atos de serviço. Eles exigem algum pensamento, tempo e esforço.")]
        ActsOfServices = 2,

        [Display(Name = "Presentes", Description = "Essa linguagem do amor não é necessariamente materialista. Significa apenas que um presente significativo ou atencioso faz seu parceiro se sentir amado e apreciado. Algo tão simples como pegar meio litro de seu sorvete favorito depois de uma longa semana de trabalho pode ter um grande impacto.")]
        Gifts = 3,

        [Display(Name = "Qualidade de Tempo", Description = "Essa linguagem do amor tem tudo a ver com atenção exclusiva. Sem televisores, sem smartphones ou qualquer outra distração. Se este for o idioma principal do seu parceiro, eles não querem apenas ser incluídos durante este período, eles querem ser o centro da sua atenção. Eles querem que seus parceiros olhem para eles e apenas para eles.")]
        QualityTime = 4,

        [Display(Name = "Toque Físico", Description = "Para as pessoas com essa linguagem do amor, nada é mais impactante do que o toque físico de seu parceiro. Eles não gostam de DPA (demonstração pública de afeto) exagerado, mas se sentem mais conectados e seguros em um relacionamento, dando as mãos, beijando, abraçando, etc.")]
        PhysicalTouch = 5
    }
}