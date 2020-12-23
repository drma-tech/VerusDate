using Blazored.LocalStorage;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using VerusDate.Shared.Model;
using VerusDate.Web.Core;

namespace VerusDate.Web.Api
{
    public static class ProfileLookingApi
    {
        public static string StorageKey => ComponenteUtils.GetStorageKey("ProfileLooking");

        public async static Task ClearCache(ILocalStorageService storage)
        {
            await storage.RemoveItemAsync(StorageKey);
        }

        public async static Task<ProfileLooking> ProfileLooking_Get(this HttpClient http, ILocalStorageService storage)
        {
            if (string.IsNullOrEmpty(StorageKey)) return null;

            if (!await storage.ContainKeyAsync(StorageKey))
            {
                await storage.SetItemAsync(StorageKey, await http.GetCustom<ProfileLooking>("ProfileLooking/Get"));
            }

            return await storage.GetItemAsync<ProfileLooking>(StorageKey);
        }

        public async static Task<HttpResponseMessage> ProfileLooking_Add(this HttpClient http, ILocalStorageService storage, ProfileLooking obj, string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));

            var response = await http.PostAsJsonAsync("ProfileLooking/Add", obj);

            if (response.IsSuccessStatusCode)
            {
                obj.Id = id; //TODO: descobrir outra maneira de saber se é insert ou update, pq depende desse campo
                await storage.SetItemAsync(StorageKey, obj);
                //await ProfileValidationApi.ClearCache(storage);
                await GamificationApi.ClearCache(storage);
            }

            return response;
        }

        public async static Task<HttpResponseMessage> ProfileLooking_Update(this HttpClient http, ILocalStorageService storage, ProfileLooking obj)
        {
            var response = await http.PostAsJsonAsync("ProfileLooking/Update", obj);

            if (response.IsSuccessStatusCode)
            {
                await storage.SetItemAsync(StorageKey, obj);
            }

            return response;
        }
    }
}