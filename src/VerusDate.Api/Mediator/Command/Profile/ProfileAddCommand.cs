using MediatR;
using Microsoft.Azure.CosmosRepository;
using System.Threading;
using System.Threading.Tasks;

namespace VerusDate.Api.Mediator.Command.Profile
{
    public class ProfileAddCommand : Shared.Model.Profile.Profile, IRequest<Shared.Model.Profile.Profile> { }

    public class ProfileAddHandler : IRequestHandler<ProfileAddCommand, Shared.Model.Profile.Profile>
    {
        private readonly IRepository<Shared.Model.Profile.Profile> _repo;

        public ProfileAddHandler(IRepositoryFactory factory)
        {
            _repo = factory.RepositoryOf<Shared.Model.Profile.Profile>();
        }

        public async Task<Shared.Model.Profile.Profile> Handle(ProfileAddCommand request, CancellationToken cancellationToken)
        {
            //var pv = await _profileValidationApp.Get(request.IdUser, cancellationToken);

            //if (!pv.ProfileData.HasValue)
            //{
            //    await _gamificationApp.AddXP(request.Id, EventAddXP.ValidateProfileData, cancellationToken);
            //}

            //await _profileValidationApp.ValidateProfileData(request.Id, true, cancellationToken);

             return await _repo.CreateAsync(request, cancellationToken);
        }
    }
}