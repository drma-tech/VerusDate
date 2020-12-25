using MediatR;
using Microsoft.Azure.CosmosRepository;
using System.Threading;
using System.Threading.Tasks;

namespace VerusDate.Api.Mediator.Queries.Profile
{
    public class ProfileGetViewCommand : IRequest<Shared.Model.Profile.Profile>
    {
        public string Id { get; set; }
    }

    public class ProfileGetViewHandler : IRequestHandler<ProfileGetViewCommand, Shared.Model.Profile.Profile>
    {
        private readonly IRepository<Shared.Model.Profile.Profile> _repo;

        public ProfileGetViewHandler(IRepositoryFactory factory)
        {
            _repo = factory.RepositoryOf<Shared.Model.Profile.Profile>();
        }

        public async Task<Shared.Model.Profile.Profile> Handle(ProfileGetViewCommand request, CancellationToken cancellationToken)
        {
            var result = await _repo.GetAsync(request.Id, cancellationToken: cancellationToken);

            result.ProtectSensitiveData();

            return result;
        }
    }
}