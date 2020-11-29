using Blazored.LocalStorage;
using System.Net.Http;
using System.Threading.Tasks;
using VerusDate.Client.Core;
using VerusDate.Shared.ViewModel.Command;

namespace VerusDate.Client.Api
{
    public static class BadgeApi
    {
        public static string StorageKey => ComponenteUtils.GetStorageKey("Badge");

        public async static Task ClearCache(ILocalStorageService storage)
        {
            await storage.RemoveItemAsync(StorageKey);
        }

        public async static Task<BadgeVM> Badge_Get(this HttpClient http, ILocalStorageService storage)
        {
            if (string.IsNullOrEmpty(StorageKey)) return null;

            if (!await storage.ContainKeyAsync(StorageKey))
            {
                await storage.SetItemAsync(StorageKey, await http.GetCustom<BadgeVM>("Badge/Get"));
            }

            return await storage.GetItemAsync<BadgeVM>(StorageKey);
        }

        public async static Task<BadgeVM> Badge_GetView(this HttpClient http, string IdUser)
        {
            return await http.GetCustom<BadgeVM>($"Badge/GetView/{IdUser}");
        }
    }
}