using Blazored.LocalStorage;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using VerusDate.Client.Core;
using VerusDate.Shared.ViewModel.Command;

namespace VerusDate.Client.Api
{
    public static class ProfileLookingApi
    {
        public static string StorageKey => ComponenteUtils.GetStorageKey("ProfileLooking");

        public async static Task ClearCache(ILocalStorageService storage)
        {
            await storage.RemoveItemAsync(StorageKey);
        }

        public async static Task<ProfileLookingVM> ProfileLooking_Get(this HttpClient http, ILocalStorageService storage)
        {
            if (string.IsNullOrEmpty(StorageKey)) return null;

            if (!await storage.ContainKeyAsync(StorageKey))
            {
                await storage.SetItemAsync(StorageKey, await http.GetCustom<ProfileLookingVM>("ProfileLooking/Get"));
            }

            return await storage.GetItemAsync<ProfileLookingVM>(StorageKey);
        }

        public async static Task<HttpResponseMessage> ProfileLooking_Add(this HttpClient http, ILocalStorageService storage, ProfileLookingVM obj, string id)
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

        public async static Task<HttpResponseMessage> ProfileLooking_Update(this HttpClient http, ILocalStorageService storage, ProfileLookingVM obj)
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