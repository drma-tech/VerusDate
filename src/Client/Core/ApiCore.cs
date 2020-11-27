using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using VerusDate.Shared.Core;
using VerusDate.Shared.Helper;

namespace VerusDate.Client.Core
{
    public static class ApiCore
    {
        public static async Task<T> GetCustom<T>(this HttpClient http, string requestUri) where T : ViewModelType
        {
            var response = await http.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<T>();
            }
            else
            {
                throw new NotificationException(response);
            }
        }

        public static async Task<List<T>> ListCustom<T>(this HttpClient http, string requestUri) where T : ViewModelType
        {
            var response = await http.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<T>>();
            }
            else
            {
                throw new NotificationException(response);
            }
        }
    }
}