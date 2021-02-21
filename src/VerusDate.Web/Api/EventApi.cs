using Blazored.SessionStorage;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
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