using System;
using System.ComponentModel.DataAnnotations;
using VerusDate.Shared.Core;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.Model.Ticket
{
    public class Ticket : CosmosBase
    {
        public Ticket() : base("Ticket")
        {
        }

        public DateTimeOffset? DtInsert { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? DtUpdate { get; set; }
        public string IdUserOwner { get; set; }

        [Display(Name = "Tipo")]
        public TicketType TicketType { get; set; }

        [Display(Name = "Descrição", Prompt = "Descreva o mais detalhado possível para que possamos entender melhor o problema")]
        public string Description { get; set; }

        [Display(Name = "Status")]
        public TicketStatus TicketStatus { get; private set; }

        [Display(Name = "Total de Votos")]
        public int TotalVotes { get; private set; }

        public void ChangeStatus(TicketStatus ticketStatus)
        {
            TicketStatus = ticketStatus;

            DtUpdate = DateTimeOffset.UtcNow;
        }

        public void Vote()
        {
            TotalVotes++;

            DtUpdate = DateTimeOffset.UtcNow;
        }
    }
}