using Dapper.Contrib.Extensions;
using System;
using VerusDate.Shared.Core;

namespace VerusDate.Shared.ViewModel.Command
{
    [Table("TicketVote")]
    public class TicketVoteVM : ViewModelCommand
    {
        [ExplicitKey]
        public string IdTicket { get; init; }

        [ExplicitKey]
        public string IdUser { get; init; }

        public override void LoadDefatultData()
        {
            throw new NotImplementedException();
        }
    }
}