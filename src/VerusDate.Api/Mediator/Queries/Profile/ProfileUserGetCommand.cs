using MediatR;
using Microsoft.Azure.CosmosRepository;
using System.Threading;
using System.Threading.Tasks;

namespace VerusDate.Api.Mediator.Queries.Profile
{
    public class ProfileUserGetCommand : IRequest<Shared.Model.Profile>
    {
        public string Id { get; set; }
    }

    public class ProfileUserGetHandler : IRequestHandler<ProfileUserGetCommand, Shared.Model.Profile>
    {
        private readonly IRepository<Shared.Model.Profile> _repo;

        public ProfileUserGetHandler(IRepositoryFactory factory)
        {
            _repo = factory.RepositoryOf<Shared.Model.Profile>();
        }

        public async Task<Shared.Model.Profile> Handle(ProfileUserGetCommand request, CancellationToken cancellationToken)
        {
            return await _repo.GetAsync(request.Id, cancellationToken: cancellationToken);
        }
    }
}