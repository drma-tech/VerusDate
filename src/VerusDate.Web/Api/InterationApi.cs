using Blazored.SessionStorage;
using Blazored.Toast.Services;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using VerusDate.Shared.Model;
using VerusDate.Web.Core;

namespace VerusDate.Web.Api
{
    public struct InterationEndpoint
    {
        public const string GetLikes = "Interaction/GetLikes";
        public const string GetBlinks = "Interaction/GetBlinks";
        public const string GetMyMatches = "Interaction/GetMyMatches";

        public const string Blink = "Interaction/Blink";
        public const string Block = "Interaction/Block";
        public const string Deslike = "Interaction/Deslike";
        public const string Like = "Interaction/Like";
        public const string AddChat = "Interaction/AddChat";

        public static string Get(string IdUserInteraction) => $"Interaction/Get?id={IdUserInteraction}";

        public static string GetChat(string IdChat) => $"Interaction/GetChat?id={IdChat}";
    }

    public static class InterationApi
    {
        public async static Task<InteractionModel> Interation_Get(this HttpClient http, ISyncSessionStorageService storage, string IdUserInteraction)
        {
            return await http.Get<InteractionModel>(InterationEndpoint.Get(IdUserInteraction), storage);
        }

        public async static Task<ChatModel> Interation_GetChat(this HttpClient http, string IdChat)
        {
            return await http.Get<ChatModel>(InterationEndpoint.GetChat(IdChat));
        }

        public async static Task<List<InteractionQuery>> Interation_GetLikes(this HttpClient http, ISyncSessionStorageService storage)
        {
            return await http.GetList<InteractionQuery>(InterationEndpoint.GetLikes, storage);
        }

        public async static Task<List<InteractionQuery>> Interation_GetBlinks(this HttpClient http, ISyncSessionStorageService storage)
        {
            return await http.GetList<InteractionQuery>(InterationEndpoint.GetBlinks, storage);
        }

        public async static Task<List<InteractionQuery>> Interation_GetMyMatches(this HttpClient http, ISyncSessionStorageService storage)
        {
            return await http.GetList<InteractionQuery>(InterationEndpoint.GetMyMatches, storage);
        }

        public async static Task Interation_Blink(this HttpClient http, string IdUserInteraction, ISyncSessionStorageService storage, IToastService toast)
        {
            await http.Session_RemoveDiamond(storage, 1);

            var response = await http.Put(InterationEndpoint.Blink, new { IdUserInteraction });

            await response.ProcessResponse(toast, msgInfo: "-1 Diamante");
        }

        public async static Task Interation_Block(this HttpClient http, string IdUserInteraction)
        {
            await http.Put(InterationEndpoint.Block, new { IdUserInteraction });
        }

        public async static Task Interation_Deslike(this HttpClient http, string IdUserInteraction)
        {
            await http.Put(InterationEndpoint.Deslike, new { IdUserInteraction });
        }

        public async static Task Interation_Like(this HttpClient http, string IdUserInteraction, ISyncSessionStorageService storage, IToastService toast)
        {
            await http.Session_RemoveFood(storage, 1);

            var response = await http.Put(InterationEndpoint.Like, new { IdUserInteraction });

            await response.ProcessResponse(toast, msgInfo: "-1 Maça");
        }

        public async static Task Interaction_AddChat(this HttpClient http, string IdChat, ChatItem Item, IToastService toast)
        {
            var response = await http.Put(InterationEndpoint.AddChat, new { IdChat, Item });

            await response.ProcessResponse(toast);
        }
    }
}