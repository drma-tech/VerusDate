using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using VerusDate.Shared.Model;
using VerusDate.Web.Core;

namespace VerusDate.Web.Api
{
    public static class ChatApi
    {
        public async static Task<List<Chat>> Chat_Get(this HttpClient http, string IdChat, string IdUser)
        {
            if (string.IsNullOrEmpty(IdChat)) throw new ArgumentNullException(nameof(IdChat));
            if (string.IsNullOrEmpty(IdUser)) throw new ArgumentNullException(nameof(IdUser));

            return await http.ListCustom<Chat>($"Chat/Get/{IdChat}/{IdUser}");
        }

        public async static Task<HttpResponseMessage> Chat_Insert(this HttpClient http, List<Chat> LstChat)
        {
            if (LstChat == null) throw new ArgumentNullException(nameof(LstChat));

            foreach (var item in LstChat)
            {
                item.SetSync();
            }

            return await http.PostAsJsonAsync("Chat/Insert", new { LstChat });
        }
    }
}