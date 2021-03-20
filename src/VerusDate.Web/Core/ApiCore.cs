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
        private async static Task<T> ReturnResponse<T>(this HttpResponseMessage response)
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

        public async static Task<T> Get<T>(this HttpClient http, string requestUri, ISyncSessionStorageService storage = null) where T : class
        {
            if (storage == null)
            {
                var response = await http.GetAsync(http.BaseApi() + requestUri);

                return await response.ReturnResponse<T>();
            }
            else
            {
                if (!storage.ContainKey(requestUri))
                {
                    var response = await http.GetAsync(http.BaseApi() + requestUri);

                    storage.SetItem(requestUri, await response.ReturnResponse<T>());
                }

                return storage.GetItem<T>(requestUri);
            }
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

        public async static Task<HttpResponseMessage> Post<T>(this HttpClient http, string requestUri, T obj, ISyncSessionStorageService storage, string urlGet) where T : class
        {
            var response = await http.PostAsJsonAsync(http.BaseApi() + requestUri, obj, GetOptions());

            if (storage != null && !string.IsNullOrWhiteSpace(urlGet) && response.IsSuccessStatusCode)
            {
                storage.SetItem(urlGet, await response.ReturnResponse<T>());
            }

            return response;
        }

        public async static Task<HttpResponseMessage> Put(this HttpClient http, string requestUri, object obj)
        {
            return await http.PutAsJsonAsync(http.BaseApi() + requestUri, obj, GetOptions());
        }

        public async static Task<HttpResponseMessage> Delete(this HttpClient http, string requestUri)
        {
            return await http.DeleteAsync(http.BaseApi() + requestUri);
        }
    }
}