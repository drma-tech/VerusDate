using Blazored.LocalStorage;
using System.Net.Http;
using System.Threading.Tasks;
using VerusDate.Shared.ModelQuery;
using VerusDate.Web.Core;

namespace VerusDate.Web.Api
{
    public static class GlobalInteractionsApi
    {
        public static string StorageKey => ComponenteUtils.GetStorageKey("GlobalInteractions");

        public async static Task ClearCache(ILocalStorageService storage)
        {
            await storage.RemoveItemAsync(StorageKey);
        }

        public async static Task<GlobalInteractions> GlobalInteractions_Get(this HttpClient http, ILocalStorageService storage)
        {
            if (string.IsNullOrEmpty(StorageKey)) return null;

            //if (!await storage.ContainKeyAsync(StorageKey))
            //{
            //    await storage.SetItemAsync(StorageKey, await http.GetCustom<GlobalInteractions>("GlobalInteractions/Get"));
            //}

            return await storage.GetItemAsync<GlobalInteractions>(StorageKey);
        }
    }
}