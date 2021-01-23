using Blazored.LocalStorage;
using System.Net.Http;
using System.Threading.Tasks;
using VerusDate.Shared.Model;
using VerusDate.Web.Core;

namespace VerusDate.Web.Api
{
    public static class PrincipalApi
    {
        public async static Task<ClientePrincipal> Principal_Get(this HttpClient http, ISyncLocalStorageService storage)
        {
            return await http.Get<ClientePrincipal>("Principal/Get", storage);
        }

        public async static Task<HttpResponseMessage> Principal_Add(this HttpClient http, ClientePrincipal obj, ISyncLocalStorageService storage)
        {
            return await http.Post("Principal/Add", obj, storage, "Principal/Get");
        }
    }
}