using Blazored.LocalStorage;
using Blazored.SessionStorage;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using VerusDate.Shared.Helper;

namespace VerusDate.Web.Core
{
    public static class ApiCore
    {
        public async static Task<T> ReturnResponse<T>(this HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<T>();
            }
            else
            {
                throw new NotificationException(response);
            }
        }

        private static JsonSerializerOptions GetOptions()
        {
            return new JsonSerializerOptions();
        }

        public async static Task<T> Get<T>(this HttpClient http, string requestUri, ISyncLocalStorageService storage) where T : class
        {
            if (!storage.ContainKey(requestUri))
            {
                var response = await http.GetAsync(http.BaseApi() + requestUri);

                storage.SetItem(requestUri, await response.ReturnResponse<T>());
            }

            return storage.GetItem<T>(requestUri);
        }

        public async static Task<T> Get<T>(this HttpClient http, string requestUri, ISyncSessionStorageService storage) where T : class
        {
            if (!storage.ContainKey(requestUri))
            {
                var response = await http.GetAsync(http.BaseApi() + requestUri);

                storage.SetItem(requestUri, await response.ReturnResponse<T>());
            }

            return storage.GetItem<T>(requestUri);
        }

        public async static Task<List<T>> GetList<T>(this HttpClient http, string requestUri, ISyncLocalStorageService storage) where T : class
        {
            if (!storage.ContainKey(requestUri))
            {
                var response = await http.GetAsync(http.BaseApi() + requestUri);

                storage.SetItem(requestUri, await response.ReturnResponse<List<T>>());
            }

            return storage.GetItem<List<T>>(requestUri);
        }

        public async static Task<List<T>> GetList<T>(this HttpClient http, string requestUri, ISyncSessionStorageService storage) where T : class
        {
            if (!storage.ContainKey(requestUri))
            {
                var response = await http.GetAsync(http.BaseApi() + requestUri);

                storage.SetItem(requestUri, await response.ReturnResponse<List<T>>());
            }

            return storage.GetItem<List<T>>(requestUri);
        }

        public async static Task<HttpResponseMessage> Post<T>(this HttpClient http, string requestUri, T obj, ISyncLocalStorageService storage, string urlGet) where T : class
        {
            var response = await http.PostAsJsonAsync(http.BaseApi() + requestUri, obj, GetOptions());

            if (storage != null && response.IsSuccessStatusCode)
            {
                storage.SetItem(urlGet, await response.ReturnResponse<T>());
            }

            return response;
        }

        public async static Task<HttpResponseMessage> Put<T>(this HttpClient http, string requestUri, object obj, ISyncLocalStorageService storage, string urlGet) where T : class
        {
            var response = await http.PutAsJsonAsync(http.BaseApi() + requestUri, obj, GetOptions());

            if (storage != null && response.IsSuccessStatusCode)
            {
                storage.SetItem(urlGet, await response.ReturnResponse<T>());
            }

            return response;
        }
    }
}