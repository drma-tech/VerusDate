using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;

namespace VerusDate.Api.Mediator.Command.Profile
{
    public class ProfileAddCommand : Shared.Model.Profile.Profile, IRequest<Shared.Model.Profile.Profile> { }

    public class ProfileAddHandler : IRequestHandler<ProfileAddCommand, Shared.Model.Profile.Profile>
    {
        private readonly IRepository _repo;

        public ProfileAddHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<Shared.Model.Profile.Profile> Handle(ProfileAddCommand request, CancellationToken cancellationToken)
        {
            //var pv = await _profileValidationApp.Get(request.IdUser, cancellationToken);

            //if (!pv.ProfileData.HasValue)
            //{
            //    await _gamificationApp.AddXP(request.Id, EventAddXP.ValidateProfileData, cancellationToken);
            //}

            //await _profileValidationApp.ValidateProfileData(request.Id, true, cancellationToken);

            return await _repo.Add(request, request.Id, cancellationToken);
        }
    }
}