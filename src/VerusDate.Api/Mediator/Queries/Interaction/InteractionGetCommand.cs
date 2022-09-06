using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Core;
using VerusDate.Shared.Model;

namespace VerusDate.Api.Mediator.Queries.Interaction
{
    public class InteractionGetCommand : MediatorQuery<InteractionModel>
    {
        public InteractionGetCommand() : base(CosmosType.Interaction)
        {
        }

        public string IdUserInteraction { get; set; }

        public override void SetParameters(IQueryCollection query)
        {
            IdUserInteraction = query["id"];
        }
    }

    public class InteractionGetHandler : IRequestHandler<InteractionGetCommand, InteractionModel>
    {
        private readonly IRepository _repo;

        public InteractionGetHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<InteractionModel> Handle(InteractionGetCommand request, CancellationToken cancellationToken)
        {
            var Id = InteractionModel.GetId(CosmosType.Interaction, request.IdLoggedUser, request.IdUserInteraction);

            return await _repo.Get<InteractionModel>(Id, request.IdLoggedUser, cancellationToken);
        }
    }
}