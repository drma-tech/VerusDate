using MediatR;
using Microsoft.Azure.CosmosRepository;
using System.Threading;
using System.Threading.Tasks;

namespace VerusDate.Api.Mediator.Queries.Profile
{
    public class ProfileGetCommand : IRequest<Shared.Model.Profile.Profile>
    {
        public string Id { get; set; }
    }

    public class ProfileGetHandler : IRequestHandler<ProfileGetCommand, Shared.Model.Profile.Profile>
    {
        private readonly IRepository<Shared.Model.Profile.Profile> _repo;

        public ProfileGetHandler(IRepositoryFactory factory)
        {
            _repo = factory.RepositoryOf<Shared.Model.Profile.Profile>();
        }

        public async Task<Shared.Model.Profile.Profile> Handle(ProfileGetCommand request, CancellationToken cancellationToken)
        {
            return await _repo.GetAsync(request.Id, cancellationToken: cancellationToken);
        }
    }
}