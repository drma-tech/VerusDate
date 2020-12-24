using MediatR;
using Microsoft.Azure.CosmosRepository;
using System.Threading;
using System.Threading.Tasks;

namespace VerusDate.Api.Mediator.Queries.Interaction
{
    public class InteractionGetCommand : IRequest<Shared.Model.Interaction>
    {
        public string Id { get; set; }
    }

    public class InteractionGetHandler : IRequestHandler<InteractionGetCommand, Shared.Model.Interaction>
    {
        private readonly IRepository<Shared.Model.Interaction> _repo;

        public InteractionGetHandler(IRepositoryFactory factory)
        {
            _repo = factory.RepositoryOf<Shared.Model.Interaction>();
        }

        public async Task<Shared.Model.Interaction> Handle(InteractionGetCommand request, CancellationToken cancellationToken)
        {
            return await _repo.GetAsync(request.Id, cancellationToken: cancellationToken);
        }
    }
}