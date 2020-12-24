using MediatR;
using Microsoft.Azure.CosmosRepository;
using System.Threading;
using System.Threading.Tasks;

namespace VerusDate.Api.Mediator.Queries.Gamification
{
    public class GamificationGetCommand : IRequest<Shared.Model.Gamification>
    {
        public string Id { get; set; }
    }

    public class GamificationGetHandler : IRequestHandler<GamificationGetCommand, Shared.Model.Gamification>
    {
        private readonly IRepository<Shared.Model.Gamification> _repo;

        public GamificationGetHandler(IRepositoryFactory factory)
        {
            _repo = factory.RepositoryOf<Shared.Model.Gamification>();
        }

        public async Task<Shared.Model.Gamification> Handle(GamificationGetCommand request, CancellationToken cancellationToken)
        {
            return await _repo.GetAsync(request.Id, cancellationToken: cancellationToken);
        }
    }
}