using Blazored.LocalStorage;
using System.Net.Http;
using System.Threading.Tasks;
using VerusDate.Client.Core;
using VerusDate.Shared.ViewModel.Query;

namespace VerusDate.Client.Api
{
    public static class GlobalInteractionsApi
    {
        public static string StorageKey => ComponenteUtils.GetStorageKey("GlobalInteractions");

        public async static Task ClearCache(ILocalStorageService storage)
        {
            await storage.RemoveItemAsync(StorageKey);
        }

        public async static Task<GlobalInteractionsVM> GlobalInteractions_Get(this HttpClient http, ILocalStorageService storage)
        {
            if (string.IsNullOrEmpty(StorageKey)) return null;

            if (!await storage.ContainKeyAsync(StorageKey))
            {
                await storage.SetItemAsync(StorageKey, await http.GetCustom<GlobalInteractionsVM>("GlobalInteractions/Get"));
            }

            return await storage.GetItemAsync<GlobalInteractionsVM>(StorageKey);
        }
    }
}