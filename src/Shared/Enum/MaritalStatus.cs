using System.ComponentModel.DataAnnotations;

namespace VerusDate.Shared.Enum
{
    public enum MaritalStatus
    {
        [Display(Name = "Solteiro (a)", Description = "quem não está em nenhum tipo de relacionamento amoroso/sexual")]
        Single = 1,

        [Display(Name = "Relacionamento monogâmico (fechado)", Description = "quem está em um relacionamento amoroso/sexual de forma exclusiva")]
        Monogamous = 2,

        [Display(Name = "Relacionamento não monogâmico (aberto)", Description = "onde há abertura para outros envolvimentos, tais como: relacionamento aberto, híbrido, múltiplo, amor livre, poliamor, swing, etc")]
        Polyamorous = 3
    }
}