using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Server.Core.Interface;
using VerusDate.Shared.ViewModel.Command;

namespace VerusDate.Server.Mediator.Queries.ProfileLooking
{
    public class ProfileLookingGetCommand : BaseCommandQuery<ProfileLookingVM> { }

    public class ProfileLookingGetHandler : IRequestHandler<ProfileLookingGetCommand, ProfileLookingVM>
    {
        private readonly IRepository _repo;

        public ProfileLookingGetHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<ProfileLookingVM> Handle(ProfileLookingGetCommand request, CancellationToken cancellationToken)
        {
            return await _repo.Get<ProfileLookingVM>(request.IdUser);
        }
    }
}