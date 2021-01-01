using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;

namespace VerusDate.Api.Mediator.Queries.Support
{
    public class TicketGetListCommand : MediatorQuery<List<Shared.Model.Support.Ticket>> { }

    public class TicketGetListHandler : IRequestHandler<TicketGetListCommand, List<Shared.Model.Support.Ticket>>
    {
        private readonly IRepository _repo;

        public TicketGetListHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<Shared.Model.Support.Ticket>> Handle(TicketGetListCommand request, CancellationToken cancellationToken)
        {
            return await _repo.Query<Shared.Model.Support.Ticket>(null, cancellationToken);
        }
    }
}