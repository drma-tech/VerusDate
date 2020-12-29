using Blazored.SessionStorage;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using VerusDate.Shared.Model.Interaction;
using VerusDate.Web.Core;

namespace VerusDate.Web.Api
{
    public static class ChatApi
    {
        public static string StorageKey => ComponenteUtils.GetStorageKey("Chat");

        public async static Task<Chat> Chat_Get(this HttpClient http, ISessionStorageService session, string IdChat, string IdUser)
        {
            return await http.GetCustomSession<Chat>(session, StorageKey, $"Chat/Get/{IdChat}/{IdUser}");
        }

        public async static Task<HttpResponseMessage> Chat_Insert(this HttpClient http, Chat chat)
        {
            //foreach (var item in LstChat)
            //{
            //    item.SetSync();
            //}

            return await http.PostAsJsonAsync("Chat/Insert", chat);
        }
    }
}