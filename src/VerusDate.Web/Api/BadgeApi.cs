using Blazored.LocalStorage;
using System.Net.Http;
using System.Threading.Tasks;
using VerusDate.Shared.Model;
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

        public async static Task<Badge> Badge_Get(this HttpClient http, ILocalStorageService storage)
        {
            if (string.IsNullOrEmpty(StorageKey)) return null;

            if (!await storage.ContainKeyAsync(StorageKey))
            {
                await storage.SetItemAsync(StorageKey, await http.GetCustom<Badge>("Badge/Get"));
            }

            return await storage.GetItemAsync<Badge>(StorageKey);
        }

        public async static Task<Badge> Badge_GetView(this HttpClient http, string IdUser)
        {
            return await http.GetCustom<Badge>($"Badge/GetView/{IdUser}");
        }
    }
}