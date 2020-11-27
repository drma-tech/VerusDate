using MediatR;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Server.Core.Interface;
using VerusDate.Shared.ViewModel;

namespace VerusDate.Server.Mediator.Queries.Interaction
{
    public class InteractionGetChatListCommand : BaseCommandQuery<IEnumerable<ProfileChatListVM>> { }

    public class InteractionGetChatListHandler : IRequestHandler<InteractionGetChatListCommand, IEnumerable<ProfileChatListVM>>
    {
        private readonly IRepository _repo;

        public InteractionGetChatListHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<ProfileChatListVM>> Handle(InteractionGetChatListCommand request, CancellationToken cancellationToken)
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
            SQL.Append("  , (   SELECT ");
            SQL.Append("			COUNT(*) ");
            SQL.Append("		FROM ");
            SQL.Append("			Chat ");
            SQL.Append("		WHERE ");
            SQL.Append("			IdChat            = I.IdChat ");
            SQL.Append("			AND IdUserSender != P.Id ");
            SQL.Append("			AND IsRead        = 0 ) QtdUnread ");
            SQL.Append("FROM ");
            SQL.Append("	Profile                  P ");
            SQL.Append("	INNER JOIN Interaction   I  ON I.Id     = P.Id ");
            SQL.Append("	INNER JOIN profile       PV ON PV.Id    = I.IdUserInteraction ");
            SQL.Append("	INNER JOIN ProfilePhotos PP ON PP.Id    = I.IdUserInteraction ");
            SQL.Append("WHERE ");
            SQL.Append("	P.Id                   = @IdUser ");
            SQL.Append("	AND I.Matched          = 1 ");
            SQL.Append("	AND I.IdChat IS NOT NULL");

            return await _repo.Query<ProfileChatListVM>(SQL, request, cancellationToken);
        }
    }
}