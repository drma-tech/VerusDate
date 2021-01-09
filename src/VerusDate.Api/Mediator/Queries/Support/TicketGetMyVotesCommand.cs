using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Model;

namespace VerusDate.Api.Mediator.Queries.Support
{
    public class TicketGetMyVotesCommand : MediatorQuery<List<TicketVoteModel>> { }

    public class TicketGetMyVotesHandler : IRequestHandler<TicketGetMyVotesCommand, List<TicketVoteModel>>
    {
        private readonly IRepository _repo;

        public TicketGetMyVotesHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<TicketVoteModel>> Handle(TicketGetMyVotesCommand request, CancellationToken cancellationToken)
        {
            return await _repo.Query<TicketVoteModel>(x => x.IdVotedUser == request.IdLoggedUser, cancellationToken);
        }
    }
}