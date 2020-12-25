using MediatR;
using Microsoft.Azure.CosmosRepository;
using System.Threading;
using System.Threading.Tasks;

namespace VerusDate.Api.Mediator.Command.Profile
{
    public class ProfileUpdateLookingCommand : Shared.Model.Profile.Profile, IRequest<Shared.Model.Profile.Profile> { }

    public class ProfileLookingAddHandler : IRequestHandler<ProfileUpdateLookingCommand, Shared.Model.Profile.Profile>
    {
        private readonly IRepository<Shared.Model.Profile.Profile> _repo;

        public ProfileLookingAddHandler(IRepositoryFactory factory)
        {
            _repo = factory.RepositoryOf<Shared.Model.Profile.Profile>();
        }

        public async Task<Shared.Model.Profile.Profile> Handle(ProfileUpdateLookingCommand request, CancellationToken cancellationToken)
        {
            //var obj = await _profileValidationApp.Get(request.Id, cancellationToken);

            //if (!obj.ProfileCriteria.HasValue)
            //{
            //    await _gamificationApp.AddXP(request.Id, EventAddXP.ValidateProfileCriteria, cancellationToken);
            //}

            //await _profileValidationApp.ValidateProfileCriteria(request.Id, true, cancellationToken);

            var obj = await _repo.GetAsync(request.Id, cancellationToken: cancellationToken);

            obj.UpdateLooking(request.Looking);

            return await _repo.UpdateAsync(obj, cancellationToken);
        }
    }
}