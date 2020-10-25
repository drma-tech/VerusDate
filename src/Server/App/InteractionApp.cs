using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Server.Core.Interface;
using VerusDate.Shared.Helper;
using VerusDate.Shared.Interface.App;
using VerusDate.Shared.ViewModel;

namespace RealDate.Data.App
{
    public class InteractionApp : IInteractionApp
    {
        private readonly IRepository _repos;

        public InteractionApp(IRepository repos)
        {
            _repos = repos;
        }

        public async Task<InteractionVM> Get(string Id, string IdUserInteraction, CancellationToken cancellationToken)
        {
            if (Id == IdUserInteraction) throw new InvalidOperationException();

            var obj = await _repos.Get<InteractionVM>("SELECT * FROM Interaction WHERE Id = @Id AND IdUserInteraction = @IdUserInteraction", new { Id, IdUserInteraction });

            if (obj == null)
            {
                obj = new InteractionVM(Id, IdUserInteraction);
                await _repos.Insert(obj);
            }

            return obj;
        }

        public async Task<IEnumerable<InteractionVM>> GetList(string Id, CancellationToken cancellationToken)
        {
            return await _repos.Query<InteractionVM>("SELECT * FROM Interaction WHERE Id = @Id", new { Id }, cancellationToken);
        }

        public async Task<IEnumerable<ProfileBasicVM>> GetLikes(string Id, CancellationToken cancellationToken)
        {
            var SQL = new StringBuilder();

            SQL.Append("SELECT ");
            SQL.Append("	I.Id ");
            SQL.Append("  , P.NickName ");
            SQL.Append("  , P.BirthDate ");
            SQL.Append("  , PP.PhotoFace ");
            SQL.Append("FROM ");
            SQL.Append("	Interaction              I ");
            SQL.Append("	INNER JOIN profile       P  ON I.Id = P.Id ");
            SQL.Append("	INNER JOIN ProfilePhotos PP ON I.Id = PP.Id ");
            SQL.Append("WHERE ");
            SQL.Append("	I.IdUserInteraction = @Id ");
            SQL.Append("	AND I.Liked         = 1 ");
            SQL.Append("	AND I.Matched       = 0");

            return await _repos.Query<ProfileBasicVM>(SQL.ToString(), new { Id }, cancellationToken);
        }

        public async Task<IEnumerable<ProfileBasicVM>> GetBlinks(string Id, CancellationToken cancellationToken)
        {
            var SQL = new StringBuilder();

            SQL.Append("SELECT ");
            SQL.Append("	I.Id ");
            SQL.Append("  , P.NickName ");
            SQL.Append("  , P.BirthDate ");
            SQL.Append("  , PP.PhotoFace ");
            SQL.Append("FROM ");
            SQL.Append("	Interaction              I ");
            SQL.Append("	INNER JOIN profile       P  ON I.Id = P.Id ");
            SQL.Append("	INNER JOIN ProfilePhotos PP ON I.Id = PP.Id ");
            SQL.Append("WHERE ");
            SQL.Append("	I.IdUserInteraction   = @Id ");
            SQL.Append("	AND I.Blinked         = 1 ");
            SQL.Append("	AND I.Matched         = 0");

            return await _repos.Query<ProfileBasicVM>(SQL.ToString(), new { Id }, cancellationToken);
        }

        public async Task<IEnumerable<ProfileBasicVM>> GetNewMatches(string Id, CancellationToken cancellationToken)
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
            SQL.Append("	P.Id                   = @Id ");
            SQL.Append("	AND I.Matched          = 1 ");
            SQL.Append("	AND I.IdChat IS NULL");

            return await _repos.Query<ProfileBasicVM>(SQL.ToString(), new { Id }, cancellationToken);
        }

        public async Task<IEnumerable<ProfileChatListVM>> GetChatList(string Id, CancellationToken cancellationToken)
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
            SQL.Append("	P.Id                   = @Id ");
            SQL.Append("	AND I.Matched          = 1 ");
            SQL.Append("	AND I.IdChat IS NOT NULL");

            return await _repos.Query<ProfileChatListVM>(SQL.ToString(), new { Id }, cancellationToken);
        }

        public async Task<bool> Blink(string Id, string IdUserInteraction, CancellationToken cancellationToken)
        {
            var obj = await Get(Id, IdUserInteraction, cancellationToken);

            obj.ExecuteBlink();

            return await _repos.Update(obj);
        }

        public async Task<bool> Block(string Id, string IdUserInteraction, CancellationToken cancellationToken)
        {
            var obj = await Get(Id, IdUserInteraction, cancellationToken);

            if (obj == null)
            {
                throw new InvalidOperationException("Block");
            }
            else
            {
                obj.ExecuteBlock();
                return await Update(obj);
            }
        }

        public async Task<bool> Deslike(string Id, string IdUserInteraction, CancellationToken cancellationToken)
        {
            var obj = await Get(Id, IdUserInteraction, cancellationToken);

            if (obj == null)
            {
                obj = new InteractionVM(Id, IdUserInteraction);
                obj.ExecuteDeslike();
                return await _repos.Insert(obj);
            }
            else
            {
                obj.ExecuteDeslike();
                return await Update(obj);
            }
        }

        public async Task<bool> Like(string Id, string IdUserInteraction, CancellationToken cancellationToken)
        {
            var obj = await Get(Id, IdUserInteraction, cancellationToken);

            obj.ExecuteLike();

            var mergeLike = await _repos.Update(obj);

            var matched = await Get(IdUserInteraction, Id, cancellationToken);

            if (matched != null && matched.Like.Value) //se o outro tbm deu like, gera o match para os dois
            {
                obj.ExecuteMatch();

                matched.ExecuteMatch();

                var mergeUser1 = await _repos.Update(obj);

                var mergeUser2 = await _repos.Update(matched);

                return mergeUser1 && mergeUser2;
            }
            else
            {
                return mergeLike;
            }
        }

        public async Task<bool> GenerateChat(string Id, string IdUserInteraction, CancellationToken cancellationToken)
        {
            if (Id == IdUserInteraction) throw new InvalidOperationException();

            var obj = await Get(Id, IdUserInteraction, cancellationToken);

            if (!obj.Match.Value)
            {
                throw new NotificationException("Match ainda não ocorreu nesta interação");
            }
            else if (!string.IsNullOrEmpty(obj.IdChat))
            {
                throw new NotificationException("Chat já gerado");
            }
            else
            {
                var IdChat = Guid.NewGuid();
                var sql = new StringBuilder();

                sql.AppendLine("UPDATE Interaction SET IdChat = @IdChat WHERE Id = @Id AND IdUserInteraction = @IdUserInteraction; ");
                sql.AppendLine("UPDATE Interaction SET IdChat = @IdChat WHERE Id = @IdUserInteraction AND IdUserInteraction = @Id; ");
                sql.AppendLine("INSERT INTO Chat (IdChat) VALUES (@IdChat); ");

                return await _repos.Execute(sql.ToString(), new { IdChat, Id, IdUserInteraction }, cancellationToken);
            }
        }

        private async Task<bool> Update(InteractionVM obj)
        {
            return await _repos.Update(obj);
        }
    }
}