using MediatR;
using Microsoft.Azure.CosmosRepository;
using System.Threading;
using System.Threading.Tasks;

namespace VerusDate.Api.Mediator.Queries.Profile
{
    public class ProfileGetCommand : IRequest<Shared.Model.Profile>
    {
        public string Id { get; set; }
    }

    public class ProfileGetHandler : IRequestHandler<ProfileGetCommand, Shared.Model.Profile>
    {
        private readonly IRepository<Shared.Model.Profile> _repo;

        public ProfileGetHandler(IRepositoryFactory factory)
        {
            _repo = factory.RepositoryOf<Shared.Model.Profile>();
        }

        public async Task<Shared.Model.Profile> Handle(ProfileGetCommand request, CancellationToken cancellationToken)
        {
            return await _repo.GetAsync(request.Id, cancellationToken: cancellationToken);
        }
    }
}