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
        public const string UpdatePartner = "Profile/UpdatePatner";

        public const string ListMatch = "Profile/ListMatch";
        public const string ListSearch = "Profile/ListSearch";

        public static string GetView(string IdUserView) => $"Profile/GetView?id={IdUserView}";
    }

    public static class ProfileApi
    {
        public static async Task<ProfileModel?> Profile_Get(this HttpClient http, ISyncSessionStorageService? storage)
        {
            return await http.Get<ProfileModel>(ProfileEndpoint.Get, storage);
        }

        public static async Task<ProfileView?> Profile_GetView(this HttpClient http, ISyncSessionStorageService? storage, string? IdUserView, bool forceUpdate = false)
        {
            if (IdUserView == null) return default;

            return await http.Get<ProfileView>(ProfileEndpoint.GetView(IdUserView), storage, forceUpdate);
        }

        public static async Task<List<ProfileSearch>> Profile_ListSearch(this HttpClient http, ISyncSessionStorageService? storage)
        {
            return await http.GetList<ProfileSearch>(ProfileEndpoint.ListSearch, storage);
        }

        public static async Task Profile_Add(this HttpClient http, ProfileModel obj, ISyncSessionStorageService? storage, IToastService? toast)
        {
            var response = await http.Post(ProfileEndpoint.Add, obj, storage, ProfileEndpoint.Get);

            await response.ProcessResponse(toast, "Perfil criado com sucesso");
        }

        public static async Task Profile_Update(this HttpClient http, ProfileModel obj, ISyncSessionStorageService? storage, IToastService? toast = null)
        {
            var response = await http.Put(ProfileEndpoint.Update, obj, storage, ProfileEndpoint.Get);

            await response.ProcessResponse(toast, "Perfil atualizado com sucesso");
        }

        public static async Task Profile_UpdateLooking(this HttpClient http, ProfileModel? obj, ProfilePreferenceModel? preference, ISyncSessionStorageService? storage, IToastService? toast)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            if (preference == null) throw new ArgumentNullException(nameof(preference));

            obj.Preference = preference;

            var response = await http.Put(ProfileEndpoint.UpdateLooking, obj, storage, ProfileEndpoint.Get);

            if (storage != null && response.IsSuccessStatusCode)
            {
                storage.RemoveItem(ProfileEndpoint.ListMatch);
                storage.RemoveItem(ProfileEndpoint.ListSearch);
            }

            await response.ProcessResponse(toast, "Preferências atualizadas com sucesso");
        }

        public static async Task Profile_UpdatePartner(this HttpClient http, string id, string? email)
        {
            if (string.IsNullOrEmpty(email)) throw new ArgumentNullException(nameof(email));

            var response = await http.Put(ProfileEndpoint.UpdatePartner, new { id, email }, null, null);

            await response.ProcessResponse(null, "Preferências atualizadas com sucesso");
        }
    }
}