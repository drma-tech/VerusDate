using Blazored.SessionStorage;
using VerusDate.Shared.Model;
using VerusDate.Shared.ModelQuery;

namespace VerusDate.Web.Api
{
    public static class ProfileSession
    {
        public static void Session_Update_Profile(this ISyncSessionStorageService storage, ProfileModel profile)
        {
            storage.SetItem(ProfileEndpoint.Get, profile);
        }

        public static void Session_Update_ListMatch(this ISyncSessionStorageService storage, List<ProfileSearch> list)
        {
            storage.SetItem(ProfileEndpoint.ListMatch, list);
        }
    }
}