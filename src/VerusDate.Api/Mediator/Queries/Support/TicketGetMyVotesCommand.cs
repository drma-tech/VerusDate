using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Model.Support;

namespace VerusDate.Api.Mediator.Queries.Support
{
    public class TicketGetMyVotesCommand : MediatorQuery<List<TicketVote>> { }

    public class TicketGetMyVotesHandler : IRequestHandler<TicketGetMyVotesCommand, List<TicketVote>>
    {
        private readonly IRepository _repo;

        public TicketGetMyVotesHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<TicketVote>> Handle(TicketGetMyVotesCommand request, CancellationToken cancellationToken)
        {
            return await _repo.Query<TicketVote>(x => x.IdVotedUser == request.IdLoggedUser, cancellationToken);
        }
    }
}