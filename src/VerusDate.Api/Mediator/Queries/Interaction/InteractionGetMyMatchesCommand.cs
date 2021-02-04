using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Core;
using VerusDate.Shared.ModelQuery;

namespace VerusDate.Api.Mediator.Queries.Interaction
{
    public class InteractionGetMyMatchesCommand : MediatorQuery<List<ProfileSearch>>
    {
        public InteractionGetMyMatchesCommand() : base(CosmosType.Profile)
        {
        }

        public override void SetParameters(IQueryCollection query)
        {
            //do nothing
        }
    }

    public class InteractionGetMyMatchesHandler : IRequestHandler<InteractionGetMyMatchesCommand, List<ProfileSearch>>
    {
        private readonly IRepository _repo;

        public InteractionGetMyMatchesHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<ProfileSearch>> Handle(InteractionGetMyMatchesCommand request, CancellationToken cancellationToken)
        {
            //recupera as interações com matches

            var sqlIds = new StringBuilder();

            sqlIds.Append("SELECT c.idUserInteraction id ");
            sqlIds.Append("FROM c ");
            sqlIds.Append("WHERE ");
            sqlIds.Append($"	c.type             = {(int)CosmosType.Interaction} ");
            sqlIds.Append($"	AND c.key          = '{request.IdLoggedUser}' ");
            sqlIds.Append("	AND c.match[\"value\"] = true ");
            sqlIds.Append("	AND c.block[\"value\"] != true ");

            var queryIds = new QueryDefinition(sqlIds.ToString());

            var lstIds = await _repo.Query<ProfileIds>(queryIds, cancellationToken);

            if (lstIds.Any())
            {
                //recupera os perfis de acordo com os ids

                var sqlMatches = new StringBuilder();

                sqlMatches.Append("SELECT TOP 10 ");
                sqlMatches.Append("	c.key as id ");
                sqlMatches.Append("  , c.basic.nickName ");
                sqlMatches.Append("  , c.bio.birthDate ");
                sqlMatches.Append("  , c.photo ");
                sqlMatches.Append("  , c.dtLastLogin ");
                sqlMatches.Append("  , c.basic.longitude ");
                sqlMatches.Append("  , c.basic.latitude ");
                sqlMatches.Append("FROM ");
                sqlMatches.Append("	c ");
                sqlMatches.Append("WHERE ");
                sqlMatches.Append($"	c.id IN ({string.Join(",", lstIds.Select(s => $"'{CosmosType.Profile}:{s.Id}'"))}) ");
                sqlMatches.Append("ORDER BY ");
                sqlMatches.Append("	c.dtTopList");

                var queryMatches = new QueryDefinition(sqlMatches.ToString());

                return await _repo.Query<ProfileSearch>(queryMatches, cancellationToken);
            }
            else
            {
                return new List<ProfileSearch>();
            }
        }
    }
}