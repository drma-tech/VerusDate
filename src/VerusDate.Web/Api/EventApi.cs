using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using VerusDate.Shared.Model;
using VerusDate.Web.Core;

namespace VerusDate.Web.Api
{
    public static class EventApi
    {
        public static async Task<List<EventModel>> Event_GetAll(this HttpClient http)
        {
            return await http.GetList<EventModel>("Event/GetAll");
        }
    }
}