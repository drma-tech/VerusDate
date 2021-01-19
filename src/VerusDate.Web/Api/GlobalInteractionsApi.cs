using Blazored.SessionStorage;
using System.Net.Http;
using System.Threading.Tasks;
using VerusDate.Shared.ModelQuery;
using VerusDate.Web.Core;

namespace VerusDate.Web.Api
{
    public static class GlobalInteractionsApi
    {
        public async static Task<GlobalInteractions> GlobalInteractions_Get(this HttpClient http, ISyncSessionStorageService storage)
        {
            return await http.Get<GlobalInteractions>("GlobalInteractions/Get", storage);
        }
    }
}