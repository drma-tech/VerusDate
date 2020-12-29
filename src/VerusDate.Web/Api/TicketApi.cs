using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using VerusDate.Shared.Model.Ticket;
using VerusDate.Web.Core;

namespace VerusDate.Web.Api
{
    public static class TicketApi
    {
        public async static Task<List<Ticket>> Ticket_GetList(this HttpClient http)
        {
            //return await http.ListCustom<Ticket>("Ticket/GetList");
            return null;
        }

        public async static Task<List<TicketVote>> Ticket_GetMyVotes(this HttpClient http)
        {
            //return await http.ListCustom<TicketVote>("Ticket/GetMyVotes");
            return null;
        }

        public async static Task<HttpResponseMessage> Ticket_Insert(this HttpClient http, Ticket obj)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));

            return await http.PostAsJsonAsync("Ticket/Insert", obj);
        }

        public async static Task<HttpResponseMessage> Ticket_Vote(this HttpClient http, string IdTicket)
        {
            if (string.IsNullOrEmpty(IdTicket)) throw new ArgumentNullException(nameof(IdTicket));

            return await http.PostAsJsonAsync("Ticket/Vote", new { IdTicket });
        }
    }
}