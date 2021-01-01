using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using VerusDate.Shared.Model.Support;
using VerusDate.Web.Core;

namespace VerusDate.Web.Api
{
    public static class SupportApi
    {
        public async static Task<List<Ticket>> Ticket_GetList(this HttpClient http)
        {
            return await http.GetList<Ticket>("Ticket/GetList");
        }

        public async static Task<List<TicketVote>> Ticket_GetMyVotes(this HttpClient http)
        {
            return await http.GetList<TicketVote>("Ticket/GetMyVotes");
        }

        public async static Task<Ticket> Ticket_Insert(this HttpClient http, Ticket obj)
        {
            return await http.Post("Ticket/Insert", obj);
        }

        public async static Task<TicketVote> Ticket_Vote(this HttpClient http, TicketVote obj)
        {
            return await http.Post("Ticket/Vote", obj);
        }
    }
}