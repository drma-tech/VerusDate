using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Core;
using VerusDate.Shared.Model;

namespace VerusDate.Api.Mediator.Queries.Interaction
{
    public class InteractionGetMyMatchesCommand : MediatorQuery<List<InteractionQuery>>
    {
        public InteractionGetMyMatchesCommand() : base(CosmosType.Profile)
        {
        }

        public override void SetParameters(IQueryCollection query)
        {
            //do nothing
        }
    }

    public class InteractionGetMyMatchesHandler : IRequestHandler<InteractionGetMyMatchesCommand, List<InteractionQuery>>
    {
        private readonly IRepository _repo;

        public InteractionGetMyMatchesHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<InteractionQuery>> Handle(InteractionGetMyMatchesCommand request, CancellationToken cancellationToken)
        {
            var sb = new StringBuilder();

            sb.Append("SELECT * ");
            sb.Append("FROM c ");
            sb.Append("WHERE ");
            sb.Append($"	c.type             = {(int)CosmosType.Interaction} ");
            sb.Append($"	AND c.key          = '{request.IdLoggedUser}' ");
            sb.Append("	AND c.match[\"value\"] = true ");
            sb.Append("	AND c.block[\"value\"] != true ");

            var query = new QueryDefinition(sb.ToString());

            return await _repo.Query<InteractionQuery>(query, cancellationToken);
        }
    }
}