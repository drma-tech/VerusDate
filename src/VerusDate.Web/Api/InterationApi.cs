using Blazored.SessionStorage;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using VerusDate.Shared.Model;
using VerusDate.Shared.ModelQuery;
using VerusDate.Web.Core;

namespace VerusDate.Web.Api
{
    public static class InterationApi
    {
        public async static Task<InteractionModel> Interation_Get(this HttpClient http, ISyncSessionStorageService storage, string IdUserInteraction)
        {
            if (string.IsNullOrEmpty(IdUserInteraction)) throw new ArgumentNullException(nameof(IdUserInteraction));

            return await http.Get<InteractionModel>($"Interaction/Get/{IdUserInteraction}", storage);
        }

        public async static Task<List<InteractionModel>> Interation_GetList(this HttpClient http, ISyncSessionStorageService storage)
        {
            return await http.GetList<InteractionModel>("Interaction/GetList", storage);
        }

        public async static Task<List<ProfileSearch>> Interation_GetLikes(this HttpClient http, ISyncSessionStorageService storage)
        {
            return await http.GetList<ProfileSearch>("Interaction/GetLikes", storage);
        }

        public async static Task<List<ProfileSearch>> Interation_GetBlinks(this HttpClient http, ISyncSessionStorageService storage)
        {
            return await http.GetList<ProfileSearch>("Interaction/GetBlinks", storage);
        }

        public async static Task<List<ProfileSearch>> Interation_GetNewMatches(this HttpClient http, ISyncSessionStorageService storage)
        {
            return await http.GetList<ProfileSearch>("Interaction/GetNewMatches", storage);
        }

        public async static Task<List<ProfileChatListModel>> Interation_GetChatList(this HttpClient http, ISyncSessionStorageService storage)
        {
            return await http.GetList<ProfileChatListModel>("Interaction/GetChatList", storage);
        }

        public async static Task<HttpResponseMessage> Interation_Blink(this HttpClient http, string IdUserInteraction, ISyncSessionStorageService storage)
        {
            if (string.IsNullOrEmpty(IdUserInteraction)) throw new ArgumentNullException(nameof(IdUserInteraction));

            //await GamificationApi.ClearCache(storage);
            return await http.Put<InteractionModel>("Interaction/Blink", new { IdUserInteraction }, storage, $"Interaction/Get/{IdUserInteraction}");
        }

        public async static Task<HttpResponseMessage> Interation_Block(this HttpClient http, string IdUserInteraction, ISyncSessionStorageService storage)
        {
            if (string.IsNullOrEmpty(IdUserInteraction)) throw new ArgumentNullException(nameof(IdUserInteraction));

            return await http.Put<InteractionModel>("Interaction/Block", new { IdUserInteraction }, storage, $"Interaction/Get/{IdUserInteraction}");
        }

        public async static Task<HttpResponseMessage> Interation_Deslike(this HttpClient http, string IdUserInteraction, ISyncSessionStorageService storage)
        {
            if (string.IsNullOrEmpty(IdUserInteraction)) throw new ArgumentNullException(nameof(IdUserInteraction));

            return await http.Put<InteractionModel>("Interaction/Deslike", new { IdUserInteraction }, storage, $"Interaction/Get/{IdUserInteraction}");
        }

        public async static Task<HttpResponseMessage> Interation_Like(this HttpClient http, string IdUserInteraction, ISyncSessionStorageService storage)
        {
            if (string.IsNullOrEmpty(IdUserInteraction)) throw new ArgumentNullException(nameof(IdUserInteraction));

            //await GamificationApi.ClearCache(storage);
            return await http.Put<InteractionModel>("Interaction/Like", new { IdUserInteraction }, storage, $"Interaction/Get/{IdUserInteraction}");
        }

        public async static Task<HttpResponseMessage> Interation_GenerateChat(this HttpClient http, string IdUser, string IdUserInteraction, ISyncSessionStorageService storage)
        {
            if (string.IsNullOrEmpty(IdUser)) throw new ArgumentNullException(nameof(IdUser));
            if (string.IsNullOrEmpty(IdUserInteraction)) throw new ArgumentNullException(nameof(IdUserInteraction));

            return await http.Put<ChatModel>("Interaction/GenerateChat", new { IdUser, IdUserInteraction }, storage, $"Interaction/Get/{IdUserInteraction}");
        }
    }
}