using Blazored.SessionStorage;
using System.Net.Http.Json;
using System.Text.Json;
using VerusDate.Shared.Helper;

namespace VerusDate.Web.Core
{
    public static class ApiCore
    {
        private static async Task<T> ReturnResponse<T>(this HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                return await response?.Content?.ReadFromJsonAsync<T>();
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

        public static async Task<T> Get<T>(this HttpClient http, string requestUri, ISyncSessionStorageService? storage = null, bool forceUpdate = false) where T : class
        {
            if (storage == null)
            {
                var response = await http.GetAsync(http.BaseApi() + requestUri);

                return await response.ReturnResponse<T>();
            }
            else
            {
                if (forceUpdate || !storage.ContainKey(requestUri))
                {
                    var response = await http.GetAsync(http.BaseApi() + requestUri);

                    storage.SetItem(requestUri, await response.ReturnResponse<T>());
                }

                return storage.GetItem<T>(requestUri);
            }
        }

        public static async Task<List<T>> GetList<T>(this HttpClient http, string requestUri, ISyncSessionStorageService storage, bool forceUpdate = false) where T : class
        {
            if (forceUpdate || !storage.ContainKey(requestUri))
            {
                var response = await http.GetAsync(http.BaseApi() + requestUri);

                storage.SetItem(requestUri, await response.ReturnResponse<List<T>>());
            }

            return storage.GetItem<List<T>>(requestUri);
        }

        public static async Task<HttpResponseMessage> Post<T>(this HttpClient http, string requestUri, T obj, ISyncSessionStorageService? storage = null, string? urlGet = null) where T : class
        {
            var response = await http.PostAsJsonAsync(http.BaseApi() + requestUri, obj, GetOptions());

            if (storage != null && !string.IsNullOrWhiteSpace(urlGet) && response.IsSuccessStatusCode)
            {
                storage.SetItem(urlGet, await response.ReturnResponse<T>());
            }

            return response;
        }

        public static async Task<HttpResponseMessage> Put<T>(this HttpClient http, string requestUri, T obj, ISyncSessionStorageService? storage = null, string? urlGet = null) where T : class
        {
            var response = await http.PutAsJsonAsync(http.BaseApi() + requestUri, obj, GetOptions());

            if (storage != null && !string.IsNullOrWhiteSpace(urlGet) && response.IsSuccessStatusCode)
            {
                storage.SetItem(urlGet, obj);
            }

            return response;
        }

        public static async Task<HttpResponseMessage> Delete(this HttpClient http, string requestUri)
        {
            return await http.DeleteAsync(http.BaseApi() + requestUri);
        }
    }
}