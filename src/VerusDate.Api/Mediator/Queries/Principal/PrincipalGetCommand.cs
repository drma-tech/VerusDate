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
    public class PrincipalGetCommand : MediatorQuery<ClientePrincipal>
    {
        public PrincipalGetCommand() : base(CosmosType.Principal)
        {
        }

        public override void SetParameters(IQueryCollection query)
        {
            //do nothing
        }
    }

    public class PrincipalGetHandler : IRequestHandler<PrincipalGetCommand, ClientePrincipal>
    {
        private readonly IRepository _repo;

        public PrincipalGetHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<ClientePrincipal> Handle(PrincipalGetCommand request, CancellationToken cancellationToken)
        {
            return await _repo.Get<ClientePrincipal>(request.Id, new PartitionKey(request.IdLoggedUser), cancellationToken);
        }
    }
}