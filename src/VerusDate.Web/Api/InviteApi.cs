﻿using Blazored.SessionStorage;
using Blazored.Toast.Services;
using Blazorise;
using VerusDate.Shared.Model;
using VerusDate.Web.Core;

namespace VerusDate.Web.Api
{
    public struct InviteEndpoint
    {
        public static string Get(string email) => $"Invite/Get?email={email}";

        public const string Add = "Invite/Add";
        public const string Update = "Invite/Update";
    }

    public static class InviteApi
    {
        public static async Task<InviteModel> Invite_Get(this HttpClient http, ISyncSessionStorageService storage, string email)
        {
            return await http.Get<InviteModel>(InviteEndpoint.Get(email), storage);
        }

        public static async Task Invite_Add(this HttpClient http, InviteModel obj, IToastService toast, ISyncSessionStorageService storage)
        {
            var response = await http.Post(InviteEndpoint.Add, obj, storage, InviteEndpoint.Get(obj.Key));

            await response.ProcessResponse(toast, "Convite criado com sucesso");
        }

        public static async Task Invite_Update(this HttpClient http, InviteModel obj, IToastService? toast, ISyncSessionStorageService storage)
        {
            var response = await http.Put(InviteEndpoint.Update, obj, storage, InviteEndpoint.Get(obj.Key));

            await response.ProcessResponse(toast, "Convite criado com sucesso"); //para o usuário, esse é o primeiro convite, então é 'criado' mesmo
        }
    }
}