using Blazorise;
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
        public static async Task<List<TicketModel>> Ticket_GetList(this HttpClient http)
        {
            return await http.GetList<TicketModel>(SupportEndpoint.GetList);
        }

        public static async Task<List<TicketVoteModel>> Ticket_GetMyVotes(this HttpClient http)
        {
            return await http.GetList<TicketVoteModel>(SupportEndpoint.GetMyVotes);
        }

        public static async Task Ticket_Insert(this HttpClient http, TicketModel obj, INotificationService toast)
        {
            var response = await http.Post(SupportEndpoint.Insert, obj);

            await response.ProcessResponse(toast, "Salvo com sucesso");
        }

        public static async Task Ticket_Vote(this HttpClient http, TicketVoteModel obj, INotificationService toast)
        {
            var response = await http.Post(SupportEndpoint.Vote, obj);

            await response.ProcessResponse(toast, "Voto registrado com sucesso");
        }
    }
}