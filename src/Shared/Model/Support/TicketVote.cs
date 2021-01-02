using System;
using VerusDate.Shared.Core;

namespace VerusDate.Shared.Model.Support
{
    public class TicketVote : CosmosBase
    {
        public TicketVote() : base(nameof(TicketVote))
        {
            Id = Guid.NewGuid().ToString();
        }

        public string IdVotedUser { get; set; }

        public override void SetIds(string IdLoggedUser)
        {
            IdVotedUser = IdLoggedUser;
        }

        public void SetKey(string IdTicket)
        {
            Key = IdTicket;
        }
    }
}