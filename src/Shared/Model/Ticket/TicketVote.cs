using System;
using VerusDate.Shared.Core;

namespace VerusDate.Shared.Model.Ticket
{
    public class TicketVote : CosmosBase
    {
        public TicketVote() : base("TicketVote")
        {
        }

        public DateTimeOffset? DtInsert { get; set; } = DateTimeOffset.UtcNow;
        public string IdVotedUser { get; set; }
    }
}