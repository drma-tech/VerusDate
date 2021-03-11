using System.ComponentModel.DataAnnotations;

namespace VerusDate.Shared.Enum
{
    public enum CurrentSituation
    {
        [Display(Name = "Solteiro (a)", Description = "Tipo de relacionamento onde a pessoa não se encontra envolvida em qualquer tipo de vínculo amoroso e/ou sexual.")]
        Single = 1,

        [Display(Name = "Relacionamento monogâmico (fechado)", Description = "Tipo de relacionamento onde o envolvimento amoroso e/ou sexual se dá de forma exclusiva.")]
        Monogamous = 2,

        [Display(Name = "Relacionamento não monogâmico (aberto)", Description = "Tipo de relacionamento onde há abertura para outros envolvimentos, tais como: relacionamento aberto, híbrido, múltiplo, amor livre, poliamor, swing, etc.")]
        NonMonogamous = 3
    }
}