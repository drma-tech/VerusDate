using System;
using System.ComponentModel.DataAnnotations;
using VerusDate.Shared.Core;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.Model.Support
{
    public class Ticket : CosmosBase
    {
        public Ticket() : base(nameof(Ticket))
        {
        }

        public string IdUserOwner { get; private set; }

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

        public override void SetIds(string IdLoggedUser)
        {
            Id = Guid.NewGuid().ToString();
            IdUserOwner = IdLoggedUser;
            Key = Id;
        }

        public void Vote()
        {
            TotalVotes++;

            DtUpdate = DateTimeOffset.UtcNow;
        }
    }
}