using Blazored.LocalStorage;
using Blazored.SessionStorage;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using VerusDate.Shared.Helper;

namespace VerusDate.Web.Core
{
    public static class ApiCore
    {
        /// <summary>
        /// Retorna o valor do local storage (caso não exista, busca da api e armazena)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="http"></param>
        /// <param name="local"></param>
        /// <param name="StorageKey"></param>
        /// <param name="requestUri"></param>
        /// <returns></returns>
        public async static Task<T> GetCustomLocal<T>(this HttpClient http, ILocalStorageService local, string StorageKey, string requestUri) where T : class
        {
            if (!await local.ContainKeyAsync(StorageKey))
            {
                var response = await http.GetAsync(ComponenteUtils.BaseApi + requestUri);

                if (response.IsSuccessStatusCode)
                {
                    await local.SetItemAsync(StorageKey, await response.Content.ReadFromJsonAsync<T>());
                }
                else
                {
                    throw new NotificationException(response);
                }
            }

            return await local.GetItemAsync<T>(StorageKey);
        }

        /// <summary>
        /// Retorna o valor da sessão do usuário (caso não exista, busca da api e armazena)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="http"></param>
        /// <param name="session"></param>
        /// <param name="StorageKey"></param>
        /// <param name="requestUri"></param>
        /// <returns></returns>
        public async static Task<T> GetCustomSession<T>(this HttpClient http, ISessionStorageService session, string StorageKey, string requestUri) where T : class
        {
            var result = await session.GetItemAsync<T>(StorageKey);

            if (result == null)
            {
                var response = await http.GetAsync(ComponenteUtils.BaseApi + requestUri);

                if (response.IsSuccessStatusCode)
                {
                    await session.SetItemAsync(StorageKey, await response.Content.ReadFromJsonAsync<T>());
                }
                else
                {
                    throw new NotificationException(response);
                }
            }

            return result;
        }
    }
}