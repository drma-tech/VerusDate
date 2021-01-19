using MediatR;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Core;
using VerusDate.Shared.Model;

namespace VerusDate.Api.Mediator.Queries.Interaction
{
    public class EventGetAllCommand : MediatorQuery<List<EventModel>>
    {
        public EventGetAllCommand() : base(CosmosType.Event)
        {
        }

        public override void SetParameters(IQueryCollection query)
        {
            //do nothing
        }
    }

    public class EventGetAllHandler : IRequestHandler<EventGetAllCommand, List<EventModel>>
    {
        private readonly IRepository _repo;

        public EventGetAllHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<EventModel>> Handle(EventGetAllCommand request, CancellationToken cancellationToken)
        {
            return await _repo.Query<EventModel>(null, null, CosmosType.Event, cancellationToken);
        }
    }
}