using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Model;

namespace VerusDate.Api.Mediator.Queries.Profile
{
    public class ProfileGetCommand : MediatorQuery<ProfileModel> { }

    public class ProfileGetHandler : IRequestHandler<ProfileGetCommand, ProfileModel>
    {
        private readonly IRepository _repo;

        public ProfileGetHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<ProfileModel> Handle(ProfileGetCommand request, CancellationToken cancellationToken)
        {
            return await _repo.Get<ProfileModel>(request.IdLoggedUser, request.IdLoggedUser, cancellationToken);
        }
    }
}