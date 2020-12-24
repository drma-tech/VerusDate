using MediatR;
using Microsoft.Azure.CosmosRepository;
using System.Threading;
using System.Threading.Tasks;

namespace VerusDate.Api.Mediator.Command.Ticket
{
    public class TicketInsertCommand : Shared.Model.Ticket, IRequest<Shared.Model.Ticket> { }

    public class TicketInsertHandler : IRequestHandler<TicketInsertCommand, Shared.Model.Ticket>
    {
        private readonly IRepository<Shared.Model.Ticket> _repo;

        public TicketInsertHandler(IRepositoryFactory factory)
        {
            _repo = factory.RepositoryOf<Shared.Model.Ticket>();
        }

        public async Task<Shared.Model.Ticket> Handle(TicketInsertCommand request, CancellationToken cancellationToken)
        {
            request.Type = "Ticket";

            return await _repo.CreateAsync(request, cancellationToken);
        }
    }
}