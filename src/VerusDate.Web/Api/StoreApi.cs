using Blazored.SessionStorage;
using Blazored.Toast.Services;
using VerusDate.Web.Core;

namespace VerusDate.Web.Api
{
    public struct StoreEndpoint
    {
        public const string AddDiamond = "Store/AddDiamond";
        public const string ExchangeFood = "Store/ExchangeFood";
    }

    public static class StoreApi
    {
        public static async Task Store_AddDiamond(this HttpClient http, int QtdDiamond, ISyncSessionStorageService storage, IToastService toast)
        {
            var response = await http.Put(StoreEndpoint.AddDiamond, new { QtdDiamond });

            if (response.IsSuccessStatusCode)
            {
                await http.Session_AddDiamond(storage, QtdDiamond);
            }

            await response.ProcessResponse(toast, "Compra realizada com sucesso!");
        }

        public static async Task Store_ExchangeFood(this HttpClient http, int QtdDiamond, ISyncSessionStorageService storage, IToastService toast)
        {
            var response = await http.Put(StoreEndpoint.ExchangeFood, new { QtdDiamond });

            if (response.IsSuccessStatusCode)
            {
                await http.Session_ExchangeFood(storage, QtdDiamond);
            }

            await response.ProcessResponse(toast, "Troca realizada com sucesso!");
        }
    }
}