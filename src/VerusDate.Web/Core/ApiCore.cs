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

        public async static Task<string> GetString(this HttpClient http, string requestUri)
        {
            var response = await http.GetAsync(http.BaseApi() + requestUri);

            return await response.Content.ReadAsStringAsync();
        }

        public async static Task<T> Get<T>(this HttpClient http, string requestUri) where T : class
        {
            var response = await http.GetAsync(http.BaseApi() + requestUri);

            return await response.ReturnResponse<T>();
        }

        public async static Task<List<T>> GetList<T>(this HttpClient http, string requestUri) where T : class
        {
            var response = await http.GetAsync(http.BaseApi() + requestUri);

            return await response.ReturnResponse<List<T>>();
        }

        public async static Task<HttpResponseMessage> Post<T>(this HttpClient http, string requestUri, T obj) where T : class
        {
            return await http.PostAsJsonAsync(http.BaseApi() + requestUri, obj, GetOptions());

            //return await response.ReturnResponse<T>();
        }

        public async static Task<HttpResponseMessage> Put<T>(this HttpClient http, string requestUri, T obj) where T : class
        {
            return await http.PutAsJsonAsync(http.BaseApi() + requestUri, obj, GetOptions());

            //return await response.ReturnResponse<T>();
        }

        public async static Task<T> Delete<T>(this HttpClient http, string requestUri)
        {
            var response = await http.DeleteAsync(http.BaseApi() + requestUri);

            return await response.ReturnResponse<T>();
        }
    }
}