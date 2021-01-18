using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using VerusDate.Shared.Model;

namespace VerusDate.Web.Api
{
    public static class GamificationApi
    {
        public static int GetMaxFood(ProfileGamificationModel obj) => obj == null ? 20 : obj.MaxFood;

        public async static Task<HttpResponseMessage> Gamification_AddDiamond(this HttpClient http, int qtd)
        {
            if (qtd <= 0) throw new ArgumentNullException(nameof(qtd));

            var response = await http.PostAsJsonAsync("Gamification/AddDiamond", new { qtd });

            if (response.IsSuccessStatusCode)
            {
                //var obj = await storage.GetItemAsync<ProfileGamificationModel>(StorageKey);
                //obj.AddDiamond(qtd);
                //await storage.SetItemAsync(StorageKey, obj);
            }

            return response;
        }

        public async static Task<HttpResponseMessage> Gamification_ExchangeFood(this HttpClient http, int QtdDiamond)
        {
            if (QtdDiamond <= 0) throw new ArgumentNullException(nameof(QtdDiamond));

            var response = await http.PostAsJsonAsync("Gamification/ExchangeFood", new { QtdDiamond });

            if (response.IsSuccessStatusCode)
            {
                //var obj = await storage.GetItemAsync<ProfileGamificationModel>(StorageKey);
                //obj.ExchangeFood(QtdDiamond);
                //await storage.SetItemAsync(StorageKey, obj);
            }

            return response;
        }
    }
}