﻿using Blazored.LocalStorage;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using VerusDate.Client.Core;
using VerusDate.Shared.ViewModel.Command;

namespace VerusDate.Client.Api
{
    public static class GamificationApi
    {
        public static string StorageKey => ComponenteUtils.GetStorageKey("Gamification");

        public static int GetMaxFood(GamificationVM obj) => obj == null ? 20 : obj.MaxFood;

        public async static Task ClearCache(ILocalStorageService storage)
        {
            await storage.RemoveItemAsync(StorageKey);
        }

        public async static Task<GamificationVM> Gamification_Get(this HttpClient http, ILocalStorageService storage)
        {
            if (string.IsNullOrEmpty(StorageKey)) return null;

            if (!await storage.ContainKeyAsync(StorageKey))
            {
                await storage.SetItemAsync(StorageKey, await http.GetCustom<GamificationVM>("Gamification/Get"));
            }

            return await storage.GetItemAsync<GamificationVM>(StorageKey);
        }

        public async static Task<GamificationVM> Gamification_GetView(this HttpClient http, string IdUser)
        {
            if (string.IsNullOrEmpty(IdUser)) throw new ArgumentNullException(nameof(IdUser));

            return await http.GetCustom<GamificationVM>($"Gamification/GetView/{IdUser}");
        }

        public async static Task<HttpResponseMessage> Gamification_AddDiamond(this HttpClient http, ILocalStorageService storage, int qtd)
        {
            if (qtd <= 0) throw new ArgumentNullException(nameof(qtd));

            var response = await http.PostAsJsonAsync("Gamification/AddDiamond", new { qtd });

            if (response.IsSuccessStatusCode)
            {
                var obj = await storage.GetItemAsync<GamificationVM>(StorageKey);
                obj.AddDiamond(qtd);
                await storage.SetItemAsync(StorageKey, obj);
            }

            return response;
        }

        public async static Task<HttpResponseMessage> Gamification_ExchangeFood(this HttpClient http, ILocalStorageService storage, int QtdDiamond)
        {
            if (QtdDiamond <= 0) throw new ArgumentNullException(nameof(QtdDiamond));

            var response = await http.PostAsJsonAsync("Gamification/ExchangeFood", new { QtdDiamond });

            if (response.IsSuccessStatusCode)
            {
                var obj = await storage.GetItemAsync<GamificationVM>(StorageKey);
                obj.ExchangeFood(QtdDiamond);
                await storage.SetItemAsync(StorageKey, obj);
            }

            return response;
        }
    }
}