using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace VerusDate.Api.Core.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        public async Task SendPrivateMessage(string user, string message, string userId)
        {
            await Clients.User(userId).SendAsync("ReceivePrivateMessage", user, message);
        }
    }
}