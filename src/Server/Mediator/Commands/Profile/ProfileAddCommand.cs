using Dapper.Contrib.Extensions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Server.Core.Interface;
using VerusDate.Shared.ViewModel.Command;

namespace VerusDate.Server.Mediator.Commands.Profile
{
    [Table("Profile")]
    public class ProfileAddCommand : ProfileVM, IBaseCommand<bool> { }

    public class ProfileAddHandler : IRequestHandler<ProfileAddCommand, bool>
    {
        private readonly IRepository _repo;

        public ProfileAddHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(ProfileAddCommand request, CancellationToken cancellationToken)
        {
            //var pv = await _profileValidationApp.Get(request.IdUser, cancellationToken);

            //if (!pv.ProfileData.HasValue)
            //{
            //    await _gamificationApp.AddXP(request.Id, EventAddXP.ValidateProfileData, cancellationToken);
            //}

            //await _profileValidationApp.ValidateProfileData(request.Id, true, cancellationToken);

            return await _repo.Insert(request);
        }
    }
}