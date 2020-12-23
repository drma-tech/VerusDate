using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using VerusDate.Shared.Model;
using VerusDate.Shared.ModelQuery;
using VerusDate.Web.Core;

namespace VerusDate.Web.Api
{
    public static class InterationApi
    {
        public async static Task<Interaction> Interation_Get(this HttpClient http, string IdUserInteraction)
        {
            if (string.IsNullOrEmpty(IdUserInteraction)) throw new ArgumentNullException(nameof(IdUserInteraction));

            return await http.GetCustom<Interaction>($"Interaction/Get/{IdUserInteraction}");
        }

        public async static Task<List<Interaction>> Interation_GetList(this HttpClient http)
        {
            return await http.ListCustom<Interaction>("Interaction/GetList");
        }

        public async static Task<List<ProfileBasic>> Interation_GetLikes(this HttpClient http)
        {
            return await http.ListCustom<ProfileBasic>("Interaction/GetLikes");
        }

        public async static Task<List<ProfileBasic>> Interation_GetBlinks(this HttpClient http)
        {
            return await http.ListCustom<ProfileBasic>("Interaction/GetBlinks");
        }

        public async static Task<List<ProfileBasic>> Interation_GetNewMatches(this HttpClient http)
        {
            return await http.ListCustom<ProfileBasic>("Interaction/GetNewMatches");
        }

        public async static Task<List<ProfileChatList>> Interation_GetChatList(this HttpClient http)
        {
            return await http.ListCustom<ProfileChatList>("Interaction/GetChatList");
        }

        public async static Task<HttpResponseMessage> Interation_Blink(this HttpClient http, ILocalStorageService storage, string IdUserInteraction)
        {
            if (string.IsNullOrEmpty(IdUserInteraction)) throw new ArgumentNullException(nameof(IdUserInteraction));

            await GamificationApi.ClearCache(storage);
            return await http.PostAsJsonAsync("Interaction/Blink", new { IdUserInteraction });
        }

        public async static Task<HttpResponseMessage> Interation_Block(this HttpClient http, string IdUserInteraction)
        {
            if (string.IsNullOrEmpty(IdUserInteraction)) throw new ArgumentNullException(nameof(IdUserInteraction));

            return await http.PostAsJsonAsync("Interaction/Block", new { IdUserInteraction });
        }

        public async static Task<HttpResponseMessage> Interation_Deslike(this HttpClient http, string IdUserInteraction)
        {
            if (string.IsNullOrEmpty(IdUserInteraction)) throw new ArgumentNullException(nameof(IdUserInteraction));

            return await http.PostAsJsonAsync("Interaction/Deslike", new { IdUserInteraction });
        }

        public async static Task<HttpResponseMessage> Interation_Like(this HttpClient http, ILocalStorageService storage, string IdUserInteraction)
        {
            if (string.IsNullOrEmpty(IdUserInteraction)) throw new ArgumentNullException(nameof(IdUserInteraction));

            await GamificationApi.ClearCache(storage);
            return await http.PostAsJsonAsync("Interaction/Like", new { IdUserInteraction });
        }

        public async static Task<HttpResponseMessage> Interation_GenerateChat(this HttpClient http, string IdUser, string IdUserInteraction)
        {
            if (string.IsNullOrEmpty(IdUser)) throw new ArgumentNullException(nameof(IdUser));
            if (string.IsNullOrEmpty(IdUserInteraction)) throw new ArgumentNullException(nameof(IdUserInteraction));

            return await http.PostAsJsonAsync("Interaction/GenerateChat", new { IdUser, IdUserInteraction });
        }
    }
}