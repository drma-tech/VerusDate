using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;

namespace VerusDate.Api.Mediator.Queries.Interaction
{
    public class InteractionGetCommand : MediatorQuery<Shared.Model.Interaction.Interaction>
    {
        public string IdUserInteraction { get; set; }
    }

    public class InteractionGetHandler : IRequestHandler<InteractionGetCommand, Shared.Model.Interaction.Interaction>
    {
        private readonly IRepository _repo;

        public InteractionGetHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<Shared.Model.Interaction.Interaction> Handle(InteractionGetCommand request, CancellationToken cancellationToken)
        {
            var Id = Shared.Model.Interaction.Interaction.GetId(request.IdLoggedUser, request.IdUserInteraction);

            return await _repo.Get<Shared.Model.Interaction.Interaction>(Id, Id, cancellationToken: cancellationToken);
        }
    }
}