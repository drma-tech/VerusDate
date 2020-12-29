using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;

namespace VerusDate.Api.Mediator.Queries.Ticket
{
    public class TicketGetListCommand : IRequest<List<Shared.Model.Ticket.Ticket>> { }

    public class TicketGetListHandler : IRequestHandler<TicketGetListCommand, List<Shared.Model.Ticket.Ticket>>
    {
        private readonly IRepository _repo;

        public TicketGetListHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Shared.Model.Ticket.Ticket>> Handle(TicketGetListCommand request, CancellationToken cancellationToken)
        {
            return await _repo.Query<Shared.Model.Ticket.Ticket>(null, cancellationToken);
        }
    }
}