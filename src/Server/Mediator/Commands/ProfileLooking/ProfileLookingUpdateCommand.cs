using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Server.Core.Interface;
using VerusDate.Shared.ViewModel.Command;

namespace VerusDate.Server.Mediator.Commands.ProfileLooking
{
    public class ProfileLookingUpdateCommand : ProfileLookingVM, IBaseCommand<bool> { }

    public class ProfileLookingUpdateHandler : IRequestHandler<ProfileLookingUpdateCommand, bool>
    {
        private readonly IRepository _repo;

        public ProfileLookingUpdateHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(ProfileLookingUpdateCommand request, CancellationToken cancellationToken)
        {
            return await _repo.Update(request);
        }
    }
}