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
    public class InteractionGetListCommand : MediatorQuery<IEnumerable<InteractionModel>>
    {
        public InteractionGetListCommand() : base(CosmosType.Interaction)
        {
        }

        public override void SetParameters(IQueryCollection query)
        {
            //do nothing
        }
    }

    public class InteractionGetListHandler : IRequestHandler<InteractionGetListCommand, IEnumerable<InteractionModel>>
    {
        private readonly IRepository _repo;

        public InteractionGetListHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<InteractionModel>> Handle(InteractionGetListCommand request, CancellationToken cancellationToken)
        {
            return await _repo.Query<InteractionModel>(null, request.IdLoggedUser, CosmosType.Interaction, cancellationToken);
        }
    }
}