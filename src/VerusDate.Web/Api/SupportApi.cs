using Blazored.LocalStorage;
using Blazored.SessionStorage;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using VerusDate.Shared.Model;
using VerusDate.Web.Core;

namespace VerusDate.Web.Api
{
    public static class SupportApi
    {
        public async static Task<List<TicketModel>> Ticket_GetList(this HttpClient http, ISyncSessionStorageService storage)
        {
            return await http.GetList<TicketModel>("Ticket/GetList", storage);
        }

        public async static Task<List<TicketVoteModel>> Ticket_GetMyVotes(this HttpClient http, ISyncLocalStorageService storage)
        {
            return await http.GetList<TicketVoteModel>("Ticket/GetMyVotes", storage);
        }

        public async static Task<HttpResponseMessage> Ticket_Insert(this HttpClient http, TicketModel obj)
        {
            return await http.Post("Ticket/Insert", obj, null, null);
        }

        public async static Task<HttpResponseMessage> Ticket_Vote(this HttpClient http, TicketVoteModel obj)
        {
            return await http.Post("Ticket/Vote", obj, null, null);
        }
    }
}