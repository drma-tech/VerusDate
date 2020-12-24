using MediatR;
using Microsoft.Azure.CosmosRepository;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VerusDate.Api.Mediator.Queries.Interaction
{
    public class InteractionGetNewMatchesCommand : IRequest<IEnumerable<Shared.ModelQuery.ProfileBasic>> { }

    public class InteractionGetNewMatchesHandler : IRequestHandler<InteractionGetNewMatchesCommand, IEnumerable<Shared.ModelQuery.ProfileBasic>>
    {
        //private readonly IRepository<Shared.ModelQuery.ProfileBasic> _repo;

        public InteractionGetNewMatchesHandler(IRepositoryFactory factory)
        {
            //_repo = factory.RepositoryOf<Shared.ModelQuery.ProfileBasic>();
        }

        public async Task<IEnumerable<Shared.ModelQuery.ProfileBasic>> Handle(InteractionGetNewMatchesCommand request, CancellationToken cancellationToken)
        {
            var SQL = new StringBuilder();

            SQL.Append("SELECT ");
            SQL.Append("	PV.Id ");
            SQL.Append("  , PV.NickName ");
            SQL.Append("  , PV.BirthDate ");
            SQL.Append("  , geography::Point(P.Latitude, P.Longitude, 4326).STDistance(geography::Point(PV.Latitude, PV.Longitude, 4326)) Distance ");
            SQL.Append("  , PP.PhotoFace ");
            SQL.Append("  , CASE ");
            SQL.Append("		WHEN CAST(PV.DtLastLogin AS DATE)  = CAST(GETDATE() AS DATE) THEN 0 ");
            SQL.Append("		WHEN CAST(PV.DtLastLogin AS DATE) >= CAST(GETDATE()-7 AS DATE) THEN 1 ");
            SQL.Append("		WHEN CAST(PV.DtLastLogin AS DATE) >= CAST(GETDATE()-30 AS DATE) THEN 2 ");
            SQL.Append("		ELSE 3 ");
            SQL.Append("	END ActivityStatus ");
            SQL.Append("FROM ");
            SQL.Append("	Profile                  P ");
            SQL.Append("	INNER JOIN Interaction   I  ON I.Id  = P.Id ");
            SQL.Append("	INNER JOIN profile       PV ON PV.Id = I.IdUserInteraction ");
            SQL.Append("	INNER JOIN ProfilePhotos PP ON PP.Id = I.IdUserInteraction ");
            SQL.Append("WHERE ");
            SQL.Append("	P.Id                   = @IdUser ");
            SQL.Append("	AND I.Matched          = 1 ");
            SQL.Append("	AND I.IdChat IS NULL");

            //return await _repo.Query(SQL, request, cancellationToken);
            return null;
        }
    }
}