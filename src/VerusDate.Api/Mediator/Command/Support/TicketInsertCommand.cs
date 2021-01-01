using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;

namespace VerusDate.Api.Mediator.Command.Support
{
    public class TicketInsertCommand : Shared.Model.Support.Ticket, IRequest<Shared.Model.Support.Ticket> { }

    public class TicketInsertHandler : IRequestHandler<TicketInsertCommand, Shared.Model.Support.Ticket>
    {
        private readonly IRepository _repo;

        public TicketInsertHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<Shared.Model.Support.Ticket> Handle(TicketInsertCommand request, CancellationToken cancellationToken)
        {
            return await _repo.Add(request, request.Id, cancellationToken);
        }
    }
}