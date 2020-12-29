using System;
using VerusDate.Shared.Core;

namespace VerusDate.Shared.Model.Ticket
{
    public class TicketVote : CosmosBase
    {
        public TicketVote() : base("TicketVote")
        {
            Id = Guid.NewGuid().ToString();
        }

        public DateTimeOffset? DtInsert { get; set; } = DateTimeOffset.UtcNow;
        public string IdVotedUser { get; private set; }

        public override void SetIdLoggedUser(string IdUser)
        {
            this.IdVotedUser = IdUser;
        }
    }
}