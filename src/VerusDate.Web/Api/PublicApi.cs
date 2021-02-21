using Blazored.SessionStorage;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using VerusDate.Shared.ModelQuery;
using VerusDate.Web.Core;

namespace VerusDate.Web.Api
{
    public struct PublicEndpoint
    {
        public const string ListDestaques = "Profile/ListDestaques";
    }

    public static class PublicApi
    {
        public async static Task<List<ProfileSearch>> Public_ListDestaques(this HttpClient http, ISyncSessionStorageService storage)
        {
            return await http.GetList<ProfileSearch>(PublicEndpoint.ListDestaques, storage);
        }
    }
}