using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;

namespace VerusDate.Api.Mediator.Command.Profile
{
    public class ProfileUpdateCommand : Shared.Model.Profile.Profile, IRequest<Shared.Model.Profile.Profile> { }

    public class ProfileUpdateHandler : IRequestHandler<ProfileUpdateCommand, Shared.Model.Profile.Profile>
    {
        private readonly IRepository _repo;

        public ProfileUpdateHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<Shared.Model.Profile.Profile> Handle(ProfileUpdateCommand request, CancellationToken cancellationToken)
        {
            //await _gamificationApp.RemoveXP(request.Id, EventRemoveXP.UpdateProfile, cancellationToken);

            var obj = await _repo.Get<Shared.Model.Profile.Profile>(request.Id, request.Id, cancellationToken);

            obj.UpdateProfile(request.Basic, request.Bio, request.Lifestyle);

            return await _repo.Update(obj, request.Id, request.Id, cancellationToken);
        }
    }
}