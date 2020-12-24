using MediatR;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Server.Core.Interface;
using VerusDate.Shared.ViewModel.Query;

namespace VerusDate.Api.Mediator.Queries.GlobalInteraction
{
    public class GlobalInteractionsGetCommand : IRequest<Shared.Model.glo>
    {
        public string Id { get; set; }
    }

    public class GlobalInteractionsGetHandler : IRequestHandler<GlobalInteractionsGetCommand, Shared.Model.Gamification>
    {
        private readonly IRepository _repo;

        public GlobalInteractionsGetHandler(IRepository repo)
        {
            _repo = repo;
        }

        public async Task<Shared.Model.Gamification> Handle(GlobalInteractionsGetCommand request, CancellationToken cancellationToken)
        {
            var SQL = new StringBuilder();

            SQL.Append("SELECT ");
            SQL.Append("	COUNT(I.IdChat) TotalMessages ");
            SQL.Append("	, (SELECT COUNT(DISTINCT C.IdChat) FROM Chat C WHERE C.IdChat IN (SELECT II.IdChat FROM Interaction II WHERE II.Id = @IdUser) AND C.IsRead = 0 AND C.IdUserSender != @IdUser) UnreadMessages ");
            SQL.Append("	, (SELECT COUNT(*) FROM Interaction II WHERE II.IdUserInteraction = @IdUser AND II.Like_Value = 1 AND II.Match_Value = 0) TotalLikes ");
            SQL.Append("	, (SELECT COUNT(*) FROM Interaction II WHERE II.IdUserInteraction = @IdUser AND II.Blink_Value = 1 AND II.Match_Value = 0) TotalBlinks ");
            SQL.Append("FROM ");
            SQL.Append("	Interaction I ");
            SQL.Append("WHERE ");
            SQL.Append("	I.Id                   = @IdUser ");
            SQL.Append("	AND I.IdChat IS NOT NULL");

            return await _repo.Get<GlobalInteractionsVM>(SQL, request);
        }
    }
}