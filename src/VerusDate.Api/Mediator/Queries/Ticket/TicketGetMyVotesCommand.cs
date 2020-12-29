using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;

namespace VerusDate.Api.Mediator.Queries.Ticket
{
    public class TicketGetMyVotesCommand : IRequest<List<Shared.Model.Ticket.TicketVote>>
    {
        public string IdUser { get; set; }
    }

    public class TicketGetMyVotesHandler : IRequestHandler<TicketGetMyVotesCommand, List<Shared.Model.Ticket.TicketVote>>
    {
        private readonly IRepository _repo;

        public TicketGetMyVotesHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Shared.Model.Ticket.TicketVote>> Handle(TicketGetMyVotesCommand request, CancellationToken cancellationToken)
        {
            return await _repo.Query<Shared.Model.Ticket.TicketVote>(x => x.IdVotedUser == request.IdUser, cancellationToken);
        }
    }
}