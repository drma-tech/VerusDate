using Blazored.LocalStorage;
using Blazored.SessionStorage;
using System.Net.Http;
using System.Threading.Tasks;
using VerusDate.Web.Core;

namespace VerusDate.Web.Api
{
    public static class BadgeApi
    {
        public static string StorageKey => ComponenteUtils.GetStorageKey("Badge");

        public async static Task ClearCache(ILocalStorageService storage)
        {
            await storage.RemoveItemAsync(StorageKey);
        }

        public async static Task<Badge> Badge_Get(this HttpClient http, ILocalStorageService local)
        {
            return await http.GetCustomLocal<Badge>(local, StorageKey, $"Badge/Get?id={ComponenteUtils.IdUser}");
        }

        public async static Task<Badge> Badge_GetView(this HttpClient http, ISessionStorageService session, string IdUser)
        {
            return await http.GetCustomSession<Badge>(session, StorageKey, $"Badge/GetView?id={IdUser}");
        }
    }
}