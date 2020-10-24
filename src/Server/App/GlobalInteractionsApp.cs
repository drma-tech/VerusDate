using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Server.Core.Interface;
using VerusDate.Shared.Interface.App;
using VerusDate.Shared.ViewModel;

namespace VerusDate.Server.App
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Critical Code Smell", "S2479:Whitespace and control characters in string literals should be explicit", Justification = "<Pending>")]
    public class GlobalInteractionsApp : IGlobalInteractionsApp
    {
        private readonly IRepositoryRead repRead;

        public GlobalInteractionsApp(IRepositoryRead repRead)
        {
            this.repRead = repRead;
        }

        public async Task<GlobalInteractionsVM> Get(string Id, CancellationToken cancellationToken)
        {
            var SQL = new StringBuilder();

            SQL.Append("SELECT ");
            SQL.Append("	COUNT(I.IdChat) TotalMessages ");
            SQL.Append("	, (SELECT COUNT(DISTINCT C.IdChat) FROM Chat C WHERE C.IdChat IN(SELECT II.IdChat FROM Interaction II WHERE II.Id = @Id) AND C.IsRead = 0 AND C.IdUserSender != @Id) UnreadMessages ");
            SQL.Append("	, (SELECT COUNT(*) FROM Interaction II WHERE II.IdUserInteraction = @Id AND II.Liked = 1 AND II.Matched = 0) TotalLikes ");
            SQL.Append("	, (SELECT COUNT(*) FROM Interaction II WHERE II.IdUserInteraction = @Id AND II.Blinked = 1 AND II.Matched = 0) TotalBlinks ");
            SQL.Append("FROM ");
            SQL.Append("	Interaction I ");
            SQL.Append("WHERE ");
            SQL.Append("	I.Id                   = @Id ");
            SQL.Append("	AND I.IdChat IS NOT NULL");

            return await repRead.GetCustom<GlobalInteractionsVM>(SQL.ToString(), new { Id }, cancellationToken);
        }
    }
}