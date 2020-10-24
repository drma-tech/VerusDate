using System.ComponentModel.DataAnnotations;

namespace VerusDate.Shared.Enum
{
    public enum RelationshipPersonality
    {
        [Display(Name = "Exploradora", Description = "Estas pessoas tratam o amor como uma aventura. São impulsivas e autônomas, muito curiosas e estão sempre focadas em aproveitar o momento, mantendo uma atitude no estilo “deixa a vida me levar”. (Combinam com Exploradora)")]
        Explorers = 1, //26.0%

        [Display(Name = "Diretora", Description = "Trata-se de uma personalidade analítica, de pessoas que priorizam a lógica e o bom senso acima de tudo. São pessoas muito equilibradas e práticas, que costumam usar a razão para tomar suas decisões. (Combinam com Negociadora)")]
        Directors = 2, //16.3%

        [Display(Name = "Construtora", Description = "Estas pessoas têm como principal valor na vida a família, os amigos e a união com as pessoas amadas. São pessoas serenas, sociáveis e muito pacíficas. Evitam ao máximo se envolver em conflitos e assumir riscos. (Combinam com Construtora)")]
        Builders = 3, //28.6%

        [Display(Name = "Negociadora", Description = "As pessoas negociadoras são expressivas, empáticas e idealistas. Geralmente têm perfis muito sensíveis, mas possuem muita imaginação e a mente bem aberta. Além disso, precisam se aprofundar em seus sentimentos e gostam que as pessoas satisfaçam suas necessidades emocionais. (Combinam com Diretora)")]
        Negotiator = 4 //29.1%
    }
}