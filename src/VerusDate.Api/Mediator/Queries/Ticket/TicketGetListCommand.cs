using MediatR;
using Microsoft.Azure.CosmosRepository;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace VerusDate.Api.Mediator.Queries.Ticket
{
    public class TicketGetListCommand : IRequest<IEnumerable<Shared.Model.Ticket>> { }

    public class TicketGetListHandler : IRequestHandler<TicketGetListCommand, IEnumerable<Shared.Model.Ticket>>
    {
        private readonly IRepository<Shared.Model.Ticket> _repo;

        public TicketGetListHandler(IRepositoryFactory factory)
        {
            _repo = factory.RepositoryOf<Shared.Model.Ticket>();
        }

        public async Task<IEnumerable<Shared.Model.Ticket>> Handle(TicketGetListCommand request, CancellationToken cancellationToken)
        {
            return await _repo.GetByQueryAsync("SELECT * FROM Ticket", cancellationToken);
        }
    }
}