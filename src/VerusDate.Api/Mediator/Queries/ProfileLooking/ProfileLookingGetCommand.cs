using MediatR;
using Microsoft.Azure.CosmosRepository;
using System.Threading;
using System.Threading.Tasks;

namespace VerusDate.Api.Mediator.Queries.ProfileLooking
{
    public class ProfileLookingGetCommand : IRequest<Shared.Model.ProfileLooking>
    {
        public string Id { get; set; }
    }

    public class ProfileLookingGetHandler : IRequestHandler<ProfileLookingGetCommand, Shared.Model.ProfileLooking>
    {
        private readonly IRepository<Shared.Model.ProfileLooking> _repo;

        public ProfileLookingGetHandler(IRepositoryFactory factory)
        {
            _repo = factory.RepositoryOf<Shared.Model.ProfileLooking>();
        }

        public async Task<Shared.Model.ProfileLooking> Handle(ProfileLookingGetCommand request, CancellationToken cancellationToken)
        {
            return await _repo.GetAsync(request.Id, cancellationToken: cancellationToken);
        }
    }
}