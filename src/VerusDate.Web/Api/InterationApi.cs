using Blazored.LocalStorage;
using Blazored.SessionStorage;
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
        public static string StorageKey => ComponenteUtils.GetStorageKey("Interation");

        public async static Task<InteractionModel> Interation_Get(this HttpClient http, ISessionStorageService session, string IdUserInteraction)
        {
            if (string.IsNullOrEmpty(IdUserInteraction)) throw new ArgumentNullException(nameof(IdUserInteraction));

            return await http.Get<InteractionModel>($"Interaction/Get/{IdUserInteraction}");
        }

        public async static Task<List<InteractionModel>> Interation_GetList(this HttpClient http, ISessionStorageService session)
        {
            return await http.GetList<InteractionModel>("Interaction/GetList");
        }

        public async static Task<List<ProfileSearch>> Interation_GetLikes(this HttpClient http, ISessionStorageService session)
        {
            return await http.GetList<ProfileSearch>("Interaction/GetLikes");
        }

        public async static Task<List<ProfileSearch>> Interation_GetBlinks(this HttpClient http, ISessionStorageService session)
        {
            return await http.GetList<ProfileSearch>("Interaction/GetBlinks");
        }

        public async static Task<List<ProfileSearch>> Interation_GetNewMatches(this HttpClient http, ISessionStorageService session)
        {
            return await http.GetList<ProfileSearch>("Interaction/GetNewMatches");
        }

        public async static Task<List<ProfileChatListModel>> Interation_GetChatList(this HttpClient http, ISessionStorageService session)
        {
            return await http.GetList<ProfileChatListModel>("Interaction/GetChatList");
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