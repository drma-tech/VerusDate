using Dapper.Contrib.Extensions;
using System;
using System.ComponentModel.DataAnnotations;
using VerusDate.Shared.Core;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.ViewModel
{
    [Table("Ticket")]
    public class TicketVM : ViewModelType
    {
        public TicketVM()
        {
        }

        public TicketVM(string IdUserOwner, TicketType TicketType)
        {
            Id = Guid.NewGuid().ToString();
            this.IdUserOwner = IdUserOwner;
            this.TicketType = TicketType;
        }

        [ExplicitKey]
        public string Id { get; set; }

        public string IdUserOwner { get; set; }
        public DateTimeOffset DtTicket { get; set; } = DateTimeOffset.UtcNow;

        [Display(Name = "Tipo")]
        public TicketType TicketType { get; set; }

        [Display(Name = "Descrição", Prompt = "Descreva o mais detalhado possível para que possamos entender melhor o problema")]
        public string Description { get; set; }

        [Display(Name = "Total de Votos")]
        public int TotalVotes { get; set; }

        [Display(Name = "Status")]
        public TicketStatus TicketStatus { get; set; } = TicketStatus.Published;

        public void Vote()
        {
            TotalVotes++;
        }
    }
}