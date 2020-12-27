using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;

namespace VerusDate.Api.Mediator.Command.Profile
{
    public class ProfileUpdateLookingCommand : Shared.Model.Profile.Profile, IRequest<Shared.Model.Profile.Profile> { }

    public class ProfileLookingAddHandler : IRequestHandler<ProfileUpdateLookingCommand, Shared.Model.Profile.Profile>
    {
        private readonly IRepository _repo;

        public ProfileLookingAddHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<Shared.Model.Profile.Profile> Handle(ProfileUpdateLookingCommand request, CancellationToken cancellationToken)
        {
            //var obj = await _profileValidationApp.Get(request.Id, cancellationToken);

            //if (!obj.ProfileCriteria.HasValue)
            //{
            //    await _gamificationApp.AddXP(request.Id, EventAddXP.ValidateProfileCriteria, cancellationToken);
            //}

            //await _profileValidationApp.ValidateProfileCriteria(request.Id, true, cancellationToken);

            var obj = await _repo.Get<Shared.Model.Profile.Profile>(request.Id, request.Id, cancellationToken);

            obj.UpdateLooking(request.Looking);

            return await _repo.Update(obj, request.Id, request.Id, cancellationToken);
        }
    }
}