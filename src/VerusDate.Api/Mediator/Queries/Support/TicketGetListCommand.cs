using MediatR;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Core;
using VerusDate.Shared.Model;

namespace VerusDate.Api.Mediator.Queries.Support
{
    public class TicketGetListCommand : MediatorQuery<List<TicketModel>>
    {
        public TicketGetListCommand() : base(CosmosType.Ticket)
        {
        }

        public override void SetParameters(IQueryCollection query)
        {
            //do nothing
        }
    }

    public class TicketGetListHandler : IRequestHandler<TicketGetListCommand, List<TicketModel>>
    {
        private readonly IRepository _repo;

        public TicketGetListHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<TicketModel>> Handle(TicketGetListCommand request, CancellationToken cancellationToken)
        {
            return await _repo.Query<TicketModel>(null, null, CosmosType.Ticket, cancellationToken);
        }
    }
}