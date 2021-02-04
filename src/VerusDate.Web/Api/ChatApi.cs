using Blazored.SessionStorage;
using System.Net.Http;
using System.Threading.Tasks;
using VerusDate.Shared.Model;
using VerusDate.Web.Core;

namespace VerusDate.Web.Api
{
    public static class ChatApi
    {
        public async static Task<ChatModel> Chat_Get(this HttpClient http, ISyncSessionStorageService storage, string IdUserInteraction)
        {
            return await http.Get<ChatModel>($"Chat/Get?id={IdUserInteraction}", storage);
        }

        public async static Task<HttpResponseMessage> Chat_Insert(this HttpClient http, ChatModel chat, string IdUserInteraction, ISyncSessionStorageService storage)
        {
            return await http.Post("Chat/Insert", chat, storage, $"Chat/Get?id={IdUserInteraction}");
        }
    }
}