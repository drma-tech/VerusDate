using System.ComponentModel.DataAnnotations;

namespace VerusDate.Shared.Enum
{
    public enum TicketType
    {
        [Display(Name = "Erro")]
        Bug = 1,

        [Display(Name = "Sugestão de Melhoria")]
        FeatureRequest = 2
    }
}