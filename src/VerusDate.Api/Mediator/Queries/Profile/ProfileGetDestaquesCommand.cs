using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Cosmos;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Core;
using VerusDate.Shared.ModelQuery;

namespace VerusDate.Api.Mediator.Queries.Profile
{
    public class ProfileGetDestaquesCommand : MediatorQuery<List<ProfileSearch>>
    {
        public ProfileGetDestaquesCommand() : base(CosmosType.Profile)
        {
        }

        public override void SetParameters(IQueryCollection query)
        {
            //do nothing
        }
    }

    public class ProfileGetDestaquesHandler : IRequestHandler<ProfileGetDestaquesCommand, List<ProfileSearch>>
    {
        private readonly IRepository _repo;

        public ProfileGetDestaquesHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<ProfileSearch>> Handle(ProfileGetDestaquesCommand request, CancellationToken cancellationToken)
        {
            var SQL = new StringBuilder();

            SQL.Append("SELECT TOP 10 ");
            SQL.Append("	c.key as id ");
            SQL.Append("  , c.basic.nickName ");
            SQL.Append("  , c.bio.birthDate ");
            SQL.Append("  , c.photo ");
            SQL.Append("  , c.dtLastLogin ");
            SQL.Append("  , c.basic.longitude ");
            SQL.Append("  , c.basic.latitude ");
            SQL.Append("FROM ");
            SQL.Append("	c ");
            SQL.Append("WHERE ");
            SQL.Append($"	c.type = {(int)CosmosType.Profile} ");
            SQL.Append("ORDER BY ");
            SQL.Append("	c.dtTopList");

            var query = new QueryDefinition(SQL.ToString());

            return await _repo.Query<ProfileSearch>(query, cancellationToken);
        }
    }
}