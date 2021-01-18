using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using VerusDate.Shared.Model;
using VerusDate.Web.Core;

namespace VerusDate.Web.Api
{
    public static class SupportApi
    {
        public async static Task<List<TicketModel>> Ticket_GetList(this HttpClient http)
        {
            return await http.GetList<TicketModel>("Ticket/GetList");
        }

        public async static Task<List<TicketVoteModel>> Ticket_GetMyVotes(this HttpClient http)
        {
            return await http.GetList<TicketVoteModel>("Ticket/GetMyVotes");
        }

        public async static Task<HttpResponseMessage> Ticket_Insert(this HttpClient http, TicketModel obj)
        {
            return await http.Post("Ticket/Insert", obj);
        }

        public async static Task<HttpResponseMessage> Ticket_Vote(this HttpClient http, TicketVoteModel obj)
        {
            return await http.Post("Ticket/Vote", obj);
        }
    }
}