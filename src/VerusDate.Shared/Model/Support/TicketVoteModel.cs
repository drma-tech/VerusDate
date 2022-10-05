using System;
using VerusDate.Shared.Core;

namespace VerusDate.Shared.Model
{
    public class TicketVoteModel : CosmosBase
    {
        public TicketVoteModel() : base(CosmosType.TicketVote)
        {
            SetId(Guid.NewGuid().ToString());
        }

        public string IdVotedUser { get; set; }

        public VoteType VoteType { get; set; }

        public override void SetIds(string IdLoggedUser)
        {
            IdVotedUser = IdLoggedUser;
        }

        public void SetKey(string IdTicket)
        {
            SetPartitionKey(IdTicket);
        }
    }

    public enum VoteType
    {
        MinusOne = -1,
        PlusOne = 1
    }
}