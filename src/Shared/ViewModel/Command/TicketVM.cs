using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations;
using VerusDate.Shared.Core;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.ViewModel.Command
{
    [Table("Ticket")]
    public class TicketVM : ViewModelCommand
    {
        [ExplicitKey]
        public string Id { get; set; }

        public string IdUserOwner { get; private set; }

        [Display(Name = "Tipo")]
        public TicketType TicketType { get; set; }

        [Display(Name = "Descrição", Prompt = "Descreva o mais detalhado possível para que possamos entender melhor o problema")]
        public string Description { get; set; }

        [Display(Name = "Status")]
        public TicketStatus TicketStatus { get; private set; }

        [Display(Name = "Total de Votos")]
        public int TotalVotes { get; private set; }

        public override void LoadDefatultData()
        {
            TicketStatus = TicketStatus.Published;
        }

        public void ChangeStatus(TicketStatus ticketStatus)
        {
            TicketStatus = ticketStatus;

            base.Update();
        }

        public void Vote()
        {
            TotalVotes++;

            base.Update();
        }
    }
}