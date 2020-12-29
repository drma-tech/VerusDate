using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;

namespace VerusDate.Api.Mediator.Command.Ticket
{
    public class TicketInsertCommand : Shared.Model.Ticket.Ticket, IRequest<Shared.Model.Ticket.Ticket> { }

    public class TicketInsertHandler : IRequestHandler<TicketInsertCommand, Shared.Model.Ticket.Ticket>
    {
        private readonly IRepository _repo;

        public TicketInsertHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<Shared.Model.Ticket.Ticket> Handle(TicketInsertCommand request, CancellationToken cancellationToken)
        {
            return await _repo.Add(request, request.Id, cancellationToken);
        }
    }
}