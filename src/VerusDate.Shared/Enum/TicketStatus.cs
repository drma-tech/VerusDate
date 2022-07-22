using VerusDate.Shared.Core;

namespace VerusDate.Shared.Enum
{
    public enum TicketStatus
    {
        [Custom(Name = "Publicado")]
        Published = 1,

        [Custom(Name = "Em progresso")]
        Progress = 2,

        [Custom(Name = "Finalizado")]
        Done = 3,

        [Custom(Name = "Negado")]
        Declined = 4
    }
}