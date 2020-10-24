using Dapper.Contrib.Extensions;
using System;
using VerusDate.Shared.Core;

namespace VerusDate.Shared.ViewModel
{
    [Table("TicketVote")]
    public class TicketVoteVM : ViewModelType
    {
        public TicketVoteVM()
        {
        }

        public TicketVoteVM(string IdTicket, string IdUser)
        {
            this.IdTicket = IdTicket;
            this.IdUser = IdUser;
        }

        [ExplicitKey]
        public string IdTicket { get; set; }

        [ExplicitKey]
        public string IdUser { get; set; }

        public DateTimeOffset DtVote { get; set; } = DateTimeOffset.UtcNow;
    }
}