using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Server.Core.Interface;
using VerusDate.Shared.ViewModel;

namespace VerusDate.Server.Mediator.Queries.Profile
{
    public class ProfileUserGetCommand : BaseCommandQuery<ProfileVM> { }

    public class ProfileUserGetHandler : IRequestHandler<ProfileUserGetCommand, ProfileVM>
    {
        private readonly IRepository _repo;

        public ProfileUserGetHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<ProfileVM> Handle(ProfileUserGetCommand request, CancellationToken cancellationToken)
        {
            return await _repo.Get<ProfileVM>(request.IdUser);
        }
    }
}