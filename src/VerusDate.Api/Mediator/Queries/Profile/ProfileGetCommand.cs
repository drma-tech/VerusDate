using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Cosmos;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Core;
using VerusDate.Shared.Model;

namespace VerusDate.Api.Mediator.Queries.Profile
{
    public class ProfileGetCommand : MediatorQuery<ProfileModel>
    {
        public ProfileGetCommand() : base(CosmosType.Profile)
        {
        }

        public override void SetParameters(IQueryCollection query)
        {
            //do nothing
        }
    }

    public class ProfileGetHandler : IRequestHandler<ProfileGetCommand, ProfileModel>
    {
        private readonly IRepository _repo;

        public ProfileGetHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<ProfileModel> Handle(ProfileGetCommand request, CancellationToken cancellationToken)
        {
            return await _repo.Get<ProfileModel>(request.Id, new PartitionKey(request.IdLoggedUser), cancellationToken);
        }
    }
}