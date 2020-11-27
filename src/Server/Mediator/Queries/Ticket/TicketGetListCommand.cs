using MediatR;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Server.Core.Interface;
using VerusDate.Shared.ViewModel;

namespace VerusDate.Server.Mediator.Queries.Ticket
{
    public class TicketGetListCommand : BaseCommandQuery<IEnumerable<TicketVM>> { }

    public class TicketGetListHandler : IRequestHandler<TicketGetListCommand, IEnumerable<TicketVM>>
    {
        private readonly IRepository _repo;

        public TicketGetListHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<TicketVM>> Handle(TicketGetListCommand request, CancellationToken cancellationToken)
        {
            return await _repo.Query<TicketVM>(new StringBuilder("SELECT * FROM TicketVote"), null, cancellationToken);
        }
    }
}