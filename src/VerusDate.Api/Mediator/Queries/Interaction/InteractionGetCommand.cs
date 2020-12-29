using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;

namespace VerusDate.Api.Mediator.Queries.Interaction
{
    public class InteractionGetCommand : IRequest<Shared.Model.Interaction.Interaction>
    {
        public string Id { get; set; }
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
            return await _repo.Get<Shared.Model.Interaction.Interaction>(request.Id, request.Id, cancellationToken: cancellationToken);
        }
    }
}