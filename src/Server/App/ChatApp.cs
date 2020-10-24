using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Server.Core.Interface;
using VerusDate.Shared.Interface.App;
using VerusDate.Shared.ViewModel;

namespace VerusDate.Server.App
{
    public class ChatApp : IChatApp
    {
        private readonly IRepository _repos;

        public ChatApp(IRepository repos)
        {
            _repos = repos;
        }

        public async Task<IEnumerable<ChatVM>> Get(string IdChat, string IdUser, CancellationToken cancellationToken)
        {
            await _repos.Execute("UPDATE Chat SET IsRead = 1 WHERE IdChat = @IdChat AND IdUserSender != @IdUser AND IsRead = 0", new { IdChat, IdUser }, cancellationToken);

            return await _repos.Query<ChatVM>("SELECT * FROM Chat WHERE IdChat = @IdChat", new { IdChat }, cancellationToken);
        }

        public async Task<bool> Insert(List<ChatVM> lstChat, CancellationToken cancellationToken)
        {
            return await _repos.BulkInsert(lstChat, cancellationToken);
        }
    }
}