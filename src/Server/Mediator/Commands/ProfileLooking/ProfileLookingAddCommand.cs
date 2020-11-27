using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Server.Core.Interface;
using VerusDate.Shared.ViewModel;

namespace VerusDate.Server.Mediator.Commands.ProfileLooking
{
    public class ProfileLookingAddCommand : ProfileLookingVM, IBaseCommand<bool> { }

    public class ProfileLookingAddHandler : IRequestHandler<ProfileLookingAddCommand, bool>
    {
        private readonly IRepository _repo;

        public ProfileLookingAddHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(ProfileLookingAddCommand request, CancellationToken cancellationToken)
        {
            //var obj = await _profileValidationApp.Get(request.Id, cancellationToken);

            //if (!obj.ProfileCriteria.HasValue)
            //{
            //    await _gamificationApp.AddXP(request.Id, EventAddXP.ValidateProfileCriteria, cancellationToken);
            //}

            //await _profileValidationApp.ValidateProfileCriteria(request.Id, true, cancellationToken);

            return await _repo.Insert(request);
        }
    }
}