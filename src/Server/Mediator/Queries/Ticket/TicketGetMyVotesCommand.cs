using MediatR;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Server.Core.Interface;
using VerusDate.Shared.ViewModel.Command;

namespace VerusDate.Server.Mediator.Queries.Ticket
{
    public class TicketGetMyVotesCommand : BaseCommandQuery<IEnumerable<TicketVoteVM>> { }

    public class TicketGetMyVotesHandler : IRequestHandler<TicketGetMyVotesCommand, IEnumerable<TicketVoteVM>>
    {
        private readonly IRepository _repo;

        public TicketGetMyVotesHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<TicketVoteVM>> Handle(TicketGetMyVotesCommand request, CancellationToken cancellationToken)
        {
            return await _repo.Query<TicketVoteVM>(new StringBuilder("SELECT * FROM TicketVote WHERE IdUser = @IdUser"), request, cancellationToken);
        }
    }
}