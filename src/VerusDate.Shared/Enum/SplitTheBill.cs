using System.ComponentModel.DataAnnotations;

namespace VerusDate.Shared.Enum
{
    public enum SplitTheBill
    {
        [Display(Name = "Dependente", Description = "Acho normal ser bancado pelo meu parceiro(a) e/ou receber agrados com frequência (financeiros, presentes, etc.)")]
        Dependent = 1,

        [Display(Name = "Receber Agrados", Description = "Acho normal que meu parceiro(a) pague a maioria das contas/despesas (casa, viagens, saídas, restaurantes, etc.) e/ou me dê presentes de vez em quando")]
        GetGifts = 2,

        [Display(Name = "Equilibrado", Description = "Acho que tudo deve ser pago igualmente, proporcionalmente ou individualmente (o que funcionar melhor para os dois)")]
        Balanced = 3,

        [Display(Name = "Agradar", Description = "Acho normal pagar a maioria das contas/despesas (casa, viagens, saídas, restaurantes, etc.) e/ou presentear meu parceiro(a) de vez em quando")]
        SendGifts = 4,

        [Display(Name = "Provedor", Description = "Acho normal bancar meu parceiro(a) e/ou oferecer agrados com frequência (financeiros, presentes, etc.)")]
        Provider = 5
    }
}