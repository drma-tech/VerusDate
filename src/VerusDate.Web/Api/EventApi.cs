using Blazored.SessionStorage;
using VerusDate.Shared.Model;
using VerusDate.Web.Core;

namespace VerusDate.Web.Api
{
    public struct EventEndpoint
    {
        public const string GetAll = "Event/GetAll";
    }

    public static class EventApi
    {
        public static async Task<List<EventModel>> Event_GetAll(this HttpClient http, ISyncSessionStorageService storage)
        {
            return await http.GetList<EventModel>(EventEndpoint.GetAll, storage);
        }
    }
}