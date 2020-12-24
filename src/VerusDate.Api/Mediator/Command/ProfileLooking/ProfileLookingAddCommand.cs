using MediatR;
using Microsoft.Azure.CosmosRepository;
using System.Threading;
using System.Threading.Tasks;

namespace VerusDate.Api.Mediator.Command.ProfileLooking
{
    public class ProfileLookingAddCommand : Shared.Model.ProfileLooking, IRequest<Shared.Model.ProfileLooking> { }

    public class ProfileLookingAddHandler : IRequestHandler<ProfileLookingAddCommand, Shared.Model.ProfileLooking>
    {
        private readonly IRepository<Shared.Model.ProfileLooking> _repo;

        public ProfileLookingAddHandler(IRepositoryFactory factory)
        {
            _repo = factory.RepositoryOf<Shared.Model.ProfileLooking>();
        }

        public async Task<Shared.Model.ProfileLooking> Handle(ProfileLookingAddCommand request, CancellationToken cancellationToken)
        {
            //var obj = await _profileValidationApp.Get(request.Id, cancellationToken);

            //if (!obj.ProfileCriteria.HasValue)
            //{
            //    await _gamificationApp.AddXP(request.Id, EventAddXP.ValidateProfileCriteria, cancellationToken);
            //}

            //await _profileValidationApp.ValidateProfileCriteria(request.Id, true, cancellationToken);

            request.Type = "ProfileLooking";

            return await _repo.CreateAsync(request, cancellationToken);
        }
    }
}