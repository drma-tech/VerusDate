using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;

namespace VerusDate.Api.Mediator.Queries.Profile
{
    public class ProfileGetCommand : IRequest<Shared.Model.Profile.Profile>
    {
        public string Id { get; set; }
    }

    public class ProfileGetHandler : IRequestHandler<ProfileGetCommand, Shared.Model.Profile.Profile>
    {
        private readonly IRepository _repo;

        public ProfileGetHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<Shared.Model.Profile.Profile> Handle(ProfileGetCommand request, CancellationToken cancellationToken)
        {
            return await _repo.Get<Shared.Model.Profile.Profile>(request.Id, request.Id, cancellationToken);
        }
    }
}