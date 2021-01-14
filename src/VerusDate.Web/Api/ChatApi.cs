using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using VerusDate.Shared.Model;
using VerusDate.Web.Core;

namespace VerusDate.Web.Api
{
    public static class ChatApi
    {
        public static string StorageKey => ComponenteUtils.GetStorageKey("Chat");

        public async static Task<ChatModel> Chat_Get(this HttpClient http, string IdChat, string IdUser)
        {
            return await http.Get<ChatModel>($"Chat/Get/{IdChat}/{IdUser}");
        }

        public async static Task<HttpResponseMessage> Chat_Insert(this HttpClient http, ChatModel chat)
        {
            //foreach (var item in LstChat)
            //{
            //    item.SetSync();
            //}

            return await http.PostAsJsonAsync("Chat/Insert", chat);
        }
    }
}