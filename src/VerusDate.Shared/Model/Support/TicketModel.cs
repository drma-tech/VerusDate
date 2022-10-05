using System;
using VerusDate.Shared.Core;

namespace VerusDate.Shared.Model
{
    public class TicketModel : CosmosBase
    {
        public TicketModel() : base(CosmosType.Ticket)
        {
        }

        public string IdUserOwner { get; set; }

        [Custom(Name = "Título", Prompt = "Uma frase que resume seu feedback")]
        public string Title { get; set; }

        [Custom(Name = "Descrição", Prompt = "Descreva o mais detalhado possível para que possamos entender melhor a situação")]
        public string Description { get; set; }

        [Custom(Name = "Tipo")]
        public TicketType TicketType { get; set; }

        [Custom(Name = "Status")]
        public TicketStatus TicketStatus { get; set; }

        [Custom(Name = "Total de Votos")]
        public int TotalVotes { get; set; }

        public void ChangeStatus(TicketStatus ticketStatus)
        {
            TicketStatus = ticketStatus;

            DtUpdate = DateTime.UtcNow;
        }

        public override void SetIds(string IdLoggedUser)
        {
            var guid = Guid.NewGuid().ToString();
            this.SetId(guid);
            this.SetPartitionKey(guid);
            IdUserOwner = IdLoggedUser;
        }

        public void Vote(VoteType voteType)
        {
            if (voteType == VoteType.PlusOne)
                TotalVotes++;
            else
                TotalVotes--;

            DtUpdate = DateTime.UtcNow;
        }
    }

    public enum TicketType
    {
        [Custom(Name = "Erro")]
        BugReport = 1,

        [Custom(Name = "Idéia")]
        Improvement = 2
    }

    public enum TicketStatus
    {
        [Custom(Name = "Novo")]
        New = 1,

        [Custom(Name = "Em Análise")]
        UnderConsideration = 2,

        [Custom(Name = "Planejado")]
        Planned = 3,

        [Custom(Name = "Em progresso")]
        Progress = 4,

        [Custom(Name = "Finalizado")]
        Done = 5,

        [Custom(Name = "Recusado")]
        Declined = 6
    }
}