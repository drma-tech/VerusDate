using Blazored.SessionStorage;
using Blazored.Toast.Services;
using VerusDate.Shared.Model;
using VerusDate.Shared.ModelQuery;
using VerusDate.Web.Core;

namespace VerusDate.Web.Api
{
    public struct ProfileEndpoint
    {
        public const string Get = "Profile/Get";
        public const string Add = "Profile/Add";
        public const string Update = "Profile/Update";
        public const string UpdateLooking = "Profile/UpdateLooking";

        public const string ListMatch = "Profile/ListMatch";
        public const string ListSearch = "Profile/ListSearch";

        public static string GetView(string IdUserView) => $"Profile/GetView?id={IdUserView}";
    }

    public static class ProfileApi
    {
        public static async Task<ProfileModel> Profile_Get(this HttpClient http, ISyncSessionStorageService storage)
        {
            return await http.Get<ProfileModel>(ProfileEndpoint.Get, storage);
        }

        public static async Task<ProfileView?> Profile_GetView(this HttpClient http, ISyncSessionStorageService storage, string? IdUserView)
        {
            if (IdUserView == null) return default;

            return await http.Get<ProfileView>(ProfileEndpoint.GetView(IdUserView), storage);
        }

        public static async Task<List<ProfileSearch>> Profile_ListSearch(this HttpClient http, ISyncSessionStorageService storage)
        {
            return await http.GetList<ProfileSearch>(ProfileEndpoint.ListSearch, storage);
        }

        public static async Task Profile_Add(this HttpClient http, ProfileModel obj, ISyncSessionStorageService storage, IToastService toast)
        {
            var response = await http.Post(ProfileEndpoint.Add, obj, storage, ProfileEndpoint.Get);

            //await http.Session_AddXP(storage, 30);
            //toast.ShowSuccess("", "Ganhou 30 XP");

            await response.ProcessResponse(toast, "Perfil criado com sucesso");
        }

        public static async Task Profile_Update(this HttpClient http, ProfileModel obj, ISyncSessionStorageService storage, IToastService? toast)
        {
            var response = await http.Put(ProfileEndpoint.Update, obj);

            if (response.IsSuccessStatusCode)
            {
                //if (obj.DtUpdate != null) //terceira vez que atualiza
                //{
                //    await http.Session_RemoveXP(storage, 100);
                //    toast.ShowWarning("", "Perdeu 100 XP");
                //}

                obj.UpdateData(obj);

                storage.Session_Update_Profile(obj);
            }

            await response.ProcessResponse(toast, "Perfil atualizado com sucesso");
        }

        public static async Task Profile_UpdateLooking(this HttpClient http, ProfileModel obj, ProfilePreferenceModel preference, ISyncSessionStorageService storage, IToastService toast)
        {
            //var fistUpdate = obj.Preference == null;

            obj.Preference = preference;

            var response = await http.Put(ProfileEndpoint.UpdateLooking, obj);

            if (response.IsSuccessStatusCode)
            {
                //if (fistUpdate)
                //{
                //    await http.Session_AddXP(storage, 30);
                //    toast.ShowSuccess("", "Ganhou 30 XP");
                //}
                //else
                //{
                //    await http.Session_RemoveXP(storage, 100);
                //    toast.ShowWarning("", "Perdeu 100 XP");
                //}

                storage.RemoveItem(ProfileEndpoint.ListMatch);
                storage.RemoveItem(ProfileEndpoint.ListSearch);
                storage.Session_Update_Profile(obj);
            }

            await response.ProcessResponse(toast, "Preferências atualizadas com sucesso");
        }
    }
}