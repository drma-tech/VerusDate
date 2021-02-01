using Blazored.SessionStorage;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using VerusDate.Shared.Model;
using VerusDate.Web.Core;

namespace VerusDate.Web.Api
{
    public static class GamificationApi
    {
        public static int GetMaxFood(ProfileGamificationModel obj) => obj == null ? 20 : obj.MaxFood;

        public async static Task<HttpResponseMessage> Gamification_AddDiamond(this HttpClient http, int qtd, ISyncSessionStorageService storage)
        {
            if (qtd <= 0) throw new ArgumentNullException(nameof(qtd));

            var response = await http.Post("Gamification/AddDiamond", new { qtd }, storage, "Profile/Get");

            if (response.IsSuccessStatusCode)
            {
                //var obj = await storage.GetItemAsync<ProfileGamificationModel>(StorageKey);
                //obj.AddDiamond(qtd);
                //await storage.SetItemAsync(StorageKey, obj);
            }

            return response;
        }

        public async static Task<HttpResponseMessage> Gamification_ExchangeFood(this HttpClient http, int QtdDiamond, ISyncSessionStorageService storage)
        {
            if (QtdDiamond <= 0) throw new ArgumentNullException(nameof(QtdDiamond));

            var response = await http.Post("Gamification/ExchangeFood", new { QtdDiamond }, storage, "Profile/Get");

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