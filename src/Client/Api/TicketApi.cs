using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using VerusDate.Client.Core;
using VerusDate.Shared.ViewModel;

namespace VerusDate.Client.Api
{
    public static class TicketApi
    {
        public async static Task<List<TicketVM>> Ticket_GetList(this HttpClient http)
        {
            return await http.ListCustom<TicketVM>("Ticket/GetList");
        }

        public async static Task<List<TicketVoteVM>> Ticket_GetMyVotes(this HttpClient http)
        {
            return await http.ListCustom<TicketVoteVM>("Ticket/GetMyVotes");
        }

        public async static Task<HttpResponseMessage> Ticket_Insert(this HttpClient http, TicketVM obj)
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