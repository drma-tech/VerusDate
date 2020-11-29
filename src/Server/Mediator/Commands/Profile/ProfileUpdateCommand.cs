using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Server.Core.Interface;
using VerusDate.Shared.ViewModel.Command;

namespace VerusDate.Server.Mediator.Commands.Profile
{
    public class ProfileUpdateCommand : ProfileVM, IBaseCommand<bool> { }

    public class ProfileUpdateHandler : IRequestHandler<ProfileUpdateCommand, bool>
    {
        private readonly IRepository _repo;

        public ProfileUpdateHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(ProfileUpdateCommand request, CancellationToken cancellationToken)
        {
            //await _gamificationApp.RemoveXP(request.Id, EventRemoveXP.UpdateProfile, cancellationToken);

            request.Update();

            return await _repo.Update(request);
        }
    }
}