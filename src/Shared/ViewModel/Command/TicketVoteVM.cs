using Dapper.Contrib.Extensions;
using System;
using VerusDate.Shared.Core;

namespace VerusDate.Shared.ViewModel.Command
{
    [Table("TicketVote")]
    public class TicketVoteVM : ViewModelCommand
    {
        [ExplicitKey]
        public string IdTicket { get; set; }

        [ExplicitKey]
        public string IdUser { get; set; }

        public override void LoadDefatultData()
        {
            throw new NotImplementedException();
        }
    }
}