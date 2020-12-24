using MediatR;
using Microsoft.Azure.CosmosRepository;
using System.Threading;
using System.Threading.Tasks;

namespace VerusDate.Api.Mediator.Command.Profile
{
    public class ProfileUpdateCommand : Shared.Model.Profile, IRequest<Shared.Model.Profile> { }

    public class ProfileUpdateHandler : IRequestHandler<ProfileUpdateCommand, Shared.Model.Profile>
    {
        private readonly IRepository<Shared.Model.Profile> _repo;

        public ProfileUpdateHandler(IRepositoryFactory factory)
        {
            _repo = factory.RepositoryOf<Shared.Model.Profile>();
        }

        public async Task<Shared.Model.Profile> Handle(ProfileUpdateCommand request, CancellationToken cancellationToken)
        {
            //await _gamificationApp.RemoveXP(request.Id, EventRemoveXP.UpdateProfile, cancellationToken);

            var obj = await _repo.GetAsync(request.Id, cancellationToken: cancellationToken);

            obj.UpdateData(request);

            return await _repo.UpdateAsync(obj, cancellationToken);
        }
    }
}