using MediatR;
using Microsoft.Azure.CosmosRepository;
using System.Threading;
using System.Threading.Tasks;

namespace VerusDate.Api.Mediator.Queries.Badge
{
    public class BadgeGetCommand : IRequest<Shared.Model.Badge>
    {
        public string Id { get; set; }
    }

    public class BadgeGetHandler : IRequestHandler<BadgeGetCommand, Shared.Model.Badge>
    {
        private readonly IRepository<Shared.Model.Badge> _repo;

        public BadgeGetHandler(IRepositoryFactory factory)
        {
            _repo = factory.RepositoryOf<Shared.Model.Badge>();
        }

        public async Task<Shared.Model.Badge> Handle(BadgeGetCommand request, CancellationToken cancellationToken)
        {
            return await _repo.GetAsync(request.Id, cancellationToken: cancellationToken);
        }
    }
}