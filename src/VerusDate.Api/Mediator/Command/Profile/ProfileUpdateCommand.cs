using MediatR;
using Microsoft.Azure.CosmosRepository;
using System.Threading;
using System.Threading.Tasks;

namespace VerusDate.Api.Mediator.Command.Profile
{
    public class ProfileUpdateCommand : Shared.Model.Profile.Profile, IRequest<Shared.Model.Profile.Profile> { }

    public class ProfileUpdateHandler : IRequestHandler<ProfileUpdateCommand, Shared.Model.Profile.Profile>
    {
        private readonly IRepository<Shared.Model.Profile.Profile> _repo;

        public ProfileUpdateHandler(IRepositoryFactory factory)
        {
            _repo = factory.RepositoryOf<Shared.Model.Profile.Profile>();
        }

        public async Task<Shared.Model.Profile.Profile> Handle(ProfileUpdateCommand request, CancellationToken cancellationToken)
        {
            //await _gamificationApp.RemoveXP(request.Id, EventRemoveXP.UpdateProfile, cancellationToken);

            var obj = await _repo.GetAsync(request.Id, cancellationToken: cancellationToken);

            obj.UpdateProfile(request.Basic, request.Bio, request.Lifestyle);

            return await _repo.UpdateAsync(obj, cancellationToken);
        }
    }
}