using MediatR;
using Microsoft.Azure.CosmosRepository;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace VerusDate.Api.Mediator.Queries.Ticket
{
    public class TicketGetMyVotesCommand : IRequest<IEnumerable<Shared.Model.TicketVote>> { }

    public class TicketGetMyVotesHandler : IRequestHandler<TicketGetMyVotesCommand, IEnumerable<Shared.Model.TicketVote>>
    {
        private readonly IRepository<Shared.Model.TicketVote> _repo;

        public TicketGetMyVotesHandler(IRepositoryFactory factory)
        {
            _repo = factory.RepositoryOf<Shared.Model.TicketVote>();
        }

        public async Task<IEnumerable<Shared.Model.TicketVote>> Handle(TicketGetMyVotesCommand request, CancellationToken cancellationToken)
        {
            return await _repo.GetByQueryAsync("SELECT * FROM TicketVote where", cancellationToken);
        }
    }
}