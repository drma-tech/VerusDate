using Blazored.SessionStorage;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using VerusDate.Shared.Model;
using VerusDate.Web.Core;

namespace VerusDate.Web.Api
{
    public static class ChatApi
    {
        public async static Task<ChatModel> Chat_Get(this HttpClient http, ISyncSessionStorageService storage, string IdChat, string IdUser)
        {
            return await http.Get<ChatModel>($"Chat/Get/{IdChat}/{IdUser}", storage);
        }

        public async static Task<HttpResponseMessage> Chat_Insert(this HttpClient http, ChatModel chat)
        {
            return await http.PostAsJsonAsync("Chat/Insert", chat);
        }
    }
}