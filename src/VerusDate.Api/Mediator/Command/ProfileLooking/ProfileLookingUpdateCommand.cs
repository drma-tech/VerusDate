using MediatR;
using Microsoft.Azure.CosmosRepository;
using System.Threading;
using System.Threading.Tasks;

namespace VerusDate.Api.Mediator.Command.ProfileLooking
{
    public class ProfileLookingUpdateCommand : Shared.Model.ProfileLooking, IRequest<Shared.Model.ProfileLooking> { }

    public class ProfileLookingUpdateHandler : IRequestHandler<ProfileLookingUpdateCommand, Shared.Model.ProfileLooking>
    {
        private readonly IRepository<Shared.Model.ProfileLooking> _repo;

        public ProfileLookingUpdateHandler(IRepositoryFactory factory)
        {
            _repo = factory.RepositoryOf<Shared.Model.ProfileLooking>();
        }

        public async Task<Shared.Model.ProfileLooking> Handle(ProfileLookingUpdateCommand request, CancellationToken cancellationToken)
        {
            var obj = await _repo.GetAsync(request.Id, cancellationToken: cancellationToken);

            obj.UpdateData(request);

            return await _repo.UpdateAsync(obj, cancellationToken);
        }
    }
}