using Blazored.SessionStorage;
using Blazored.Toast.Services;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using VerusDate.Shared.Model;
using VerusDate.Web.Core;

namespace VerusDate.Web.Api
{
    public struct SupportEndpoint
    {
        public const string GetList = "Ticket/GetList";
        public const string GetMyVotes = "Ticket/GetMyVotes";

        public const string Insert = "Ticket/Insert";
        public const string Vote = "Ticket/Vote";
    }

    public static class SupportApi
    {
        public async static Task<List<TicketModel>> Ticket_GetList(this HttpClient http, ISyncSessionStorageService storage)
        {
            return await http.GetList<TicketModel>(SupportEndpoint.GetList, storage);
        }

        public async static Task<List<TicketVoteModel>> Ticket_GetMyVotes(this HttpClient http, ISyncSessionStorageService storage)
        {
            return await http.GetList<TicketVoteModel>(SupportEndpoint.GetMyVotes, storage);
        }

        public async static Task Ticket_Insert(this HttpClient http, TicketModel obj, ISyncSessionStorageService storage, IToastService toast)
        {
            storage.RemoveItem(SupportEndpoint.GetList);
            storage.RemoveItem(SupportEndpoint.GetMyVotes);

            var response = await http.Post(SupportEndpoint.Insert, obj, storage, null);

            if (response.IsSuccessStatusCode)
            {
                await http.Session_AddXP(storage, 5);
                toast.ShowSuccess("", "Ganhou 5 XP");
            }

            await response.ProcessResponse(toast, "Salvo com sucesso");
        }

        public async static Task Ticket_Vote(this HttpClient http, TicketVoteModel obj, ISyncSessionStorageService storage, IToastService toast)
        {
            var response = await http.Post(SupportEndpoint.Vote, obj, storage, null);

            if (response.IsSuccessStatusCode)
            {
                await http.Session_AddXP(storage, 1);
                toast.ShowSuccess("", "Ganhou 1 XP");
            }

            await response.ProcessResponse(toast, "Voto registrado com sucesso");
        }
    }
}