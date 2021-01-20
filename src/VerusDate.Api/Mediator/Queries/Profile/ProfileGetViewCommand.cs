using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Cosmos;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Shared.Core;
using VerusDate.Shared.Model;

namespace VerusDate.Api.Mediator.Queries.Profile
{
    public class ProfileGetViewCommand : MediatorQuery<ProfileView>
    {
        public ProfileGetViewCommand() : base(CosmosType.Profile)
        {
        }

        public string IdUserView { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public override void SetParameters(IQueryCollection query)
        {
            IdUserView = query["id"];
        }
    }

    public class ProfileGetViewHandler : IRequestHandler<ProfileGetViewCommand, ProfileView>
    {
        private readonly IRepository _repo;

        public ProfileGetViewHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<ProfileView> Handle(ProfileGetViewCommand request, CancellationToken cancellationToken)
        {
            //var result = await _repo.Get<ProfileView>(request.Type + ":" + request.IdUserView, new PartitionKey(request.IdUserView), cancellationToken);

            //return result;

            var SQL = new StringBuilder();

            SQL.Append("SELECT ");
            SQL.Append("	c.key as id ");
            SQL.Append("  , c.basic ");
            SQL.Append("  , c.bio ");
            SQL.Append("  , c.lifestyle ");
            SQL.Append("  , c.looking ");
            SQL.Append("  , c.gamification ");
            SQL.Append("  , c.badge ");
            SQL.Append("  , c.photo ");
            SQL.Append("  , TRUNC(DateTimeDiff('month',c.bio.birthDate,GetCurrentDateTime())/12) Age ");
            SQL.Append("  , c.dtLastLogin >= DateTimeAdd('d',-1,GetCurrentDateTime()) ? 1 ");
            SQL.Append("        : c.dtLastLogin >= DateTimeAdd('d',-7,GetCurrentDateTime()) ? 2 ");
            SQL.Append("        : c.dtLastLogin >= DateTimeAdd('m',-1,GetCurrentDateTime()) ? 3 ");
            SQL.Append("        : 4 ");
            SQL.Append("    as ActivityStatus ");
            SQL.Append("  , ROUND(ST_DISTANCE({'type': 'Point', 'coordinates':[@latitude, @longitude]},{'type': 'Point', 'coordinates':[c.basic.latitude, c.basic.longitude]}) / @valueCalDistance) as Distance ");
            SQL.Append("FROM ");
            SQL.Append("	c ");
            SQL.Append("WHERE ");
            SQL.Append("	c.id = '" + request.Type + ":" + request.IdUserView + "' ");

            var query = new QueryDefinition(SQL.ToString());

            return await _repo.Get<ProfileView>(query, cancellationToken);
        }
    }
}