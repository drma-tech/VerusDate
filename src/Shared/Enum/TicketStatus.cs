using System.ComponentModel.DataAnnotations;

namespace VerusDate.Shared.Enum
{
    public enum TicketStatus
    {
        [Display(Name = "Publicado")]
        Published = 1,

        [Display(Name = "Em progresso")]
        Progress = 2,

        [Display(Name = "Finalizado")]
        Done = 3,

        [Display(Name = "Negado")]
        Declined = 4
    }
}