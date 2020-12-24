using Blazored.LocalStorage;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http;
using System.Threading.Tasks;
using VerusDate.Shared.Model;
using VerusDate.Web.Core;

namespace VerusDate.Web.Api
{
    public static class ProfileApi
    {
        public static string StorageKey => ComponenteUtils.GetStorageKey("Profile");

        public async static Task ClearCache(ILocalStorageService storage)
        {
            await storage.RemoveItemAsync(StorageKey);
        }

        public async static Task<Profile> Profile_Get(this HttpClient http, ILocalStorageService local)
        {
            return await http.GetCustomLocal<Profile>(local, StorageKey, $"profile/get?id={ComponenteUtils.IdUser}");
        }

        public async static Task<Profile> Profile_GetView(this HttpClient http, ISessionStorageService session, string IdUserView)
        {
            if (string.IsNullOrEmpty(IdUserView)) return null;

            return await http.GetCustomSession<Profile>(session, StorageKey + IdUserView, $"profile/get?id={IdUserView}");
        }

        //public List<AffinityVM> GetAffinity(ProfileLooking profUser, Profile profView)
        //{
        //    if (profUser == null) throw new ArgumentNullException(nameof(profUser));
        //    if (profView == null) throw new ArgumentNullException(nameof(profView));

        //    var obj = new List<AffinityVM>
        //    {
        //        new AffinityVM(nameof(profView.BirthDate), CheckAge(profView.BirthDate, profUser.MinimalAge, profUser.MaxAge)),
        //        new AffinityVM(nameof(profView.BiologicalSex), CheckEnum((int)profView.BiologicalSex, (int?)profUser.BiologicalSex)),
        //        new AffinityVM(nameof(profView.MaritalStatus), CheckEnum((int)profView.MaritalStatus, (int?)profUser.MaritalStatus)),
        //        new AffinityVM(nameof(profView.Intent), CheckMultiple(profView.Intent, profUser.Intent)),
        //        new AffinityVM(nameof(profView.GenderIdentity), CheckEnum((int)profView.GenderIdentity, (int?)profUser.GenderIdentity)),
        //        new AffinityVM(nameof(profView.SexualOrientation), CheckEnum((int)profView.SexualOrientation, (int?)profUser.SexualOrientation)),
        //        //distancia
        //        new AffinityVM(nameof(profView.Smoke), CheckEnum((int)profView.Smoke, (int?)profUser.Smoke)),
        //        new AffinityVM(nameof(profView.Drink), CheckEnum((int)profView.Drink, (int?)profUser.Drink)),
        //        new AffinityVM(nameof(profView.Diet), CheckEnum((int)profView.Diet, (int?)profUser.Diet)),
        //        new AffinityVM(nameof(profView.Height), CheckHeight(profView.Height, profUser.MinimalHeight, profUser.MaxHeight)),
        //        new AffinityVM(nameof(profView.BodyMass), CheckEnum((int)profView.BodyMass, (int?)profUser.BodyMass)),
        //        new AffinityVM(nameof(profView.RaceCategory), CheckEnum((int)profView.RaceCategory, (int?)profUser.RaceCategory))
        //    };

        //    if (profView.Intent.IsLongTerm())
        //    {
        //        obj.Add(new AffinityVM(nameof(profView.HaveChildren), CheckEnum((int)profView.HaveChildren.Value, (int?)profUser.HaveChildren)));
        //        obj.Add(new AffinityVM(nameof(profView.WantChildren), CheckEnum((int)profView.WantChildren.Value, (int?)profUser.WantChildren)));
        //        obj.Add(new AffinityVM(nameof(profView.Religion), CheckEnum((int)profView.Religion.Value, (int?)profUser.Religion)));
        //        obj.Add(new AffinityVM(nameof(profView.EducationLevel), CheckEnum((int)profView.EducationLevel.Value, (int?)profUser.EducationLevel)));
        //        obj.Add(new AffinityVM(nameof(profView.CareerCluster), CheckEnum((int)profView.CareerCluster.Value, (int?)profUser.CareerCluster)));
        //        //TODO: não é oq ele procura, é o ele é
        //        //obj.Add(new AffinityVM(nameof(profView.MoneyPersonality), CheckEnum((int)profView.MoneyPersonality.Value, (int?)profUser.MoneyPersonality)));
        //        //obj.Add(new AffinityVM(nameof(profView.MyersBriggsTypeIndicator), CheckEnum((int)profView.MyersBriggsTypeIndicator.Value, (int?)profUser.MyersBriggsTypeIndicator)));
        //        //obj.Add(new AffinityVM(nameof(profView.RelationshipPersonality), CheckEnumRelationshipPersonality(profView.RelationshipPersonality.Value, profUser.RelationshipPersonality)));
        //    }

        //    return obj;
        //}

        //#region AFFINITY

        //private static bool CheckAge(DateTime BirthDate, int? MinAge, int? MaxAge)
        //{
        //    var age = DateTime.Now.Year - BirthDate.Year;

        //    if (MinAge.HasValue && MaxAge.HasValue)
        //    {
        //        return MinAge <= age && MaxAge >= age;
        //    }
        //    else if (MinAge.HasValue)
        //    {
        //        return MinAge <= age;
        //    }
        //    else if (MaxAge.HasValue)
        //    {
        //        return MaxAge >= age;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        //private static bool CheckEnum(int EnumUser, int? EnumLooking)
        //{
        //    if (!EnumLooking.HasValue) return true; //If the user has not defined, then it is an affinity

        //    return EnumUser == EnumLooking;
        //}

        //private static bool CheckMultiple(IReadOnlyList<Intent> user, IReadOnlyList<Intent> looking)
        //{
        //    if (user == null) throw new ArgumentNullException(nameof(user));
        //    if (looking == null) throw new ArgumentNullException(nameof(looking));

        //    return user.Intersect(looking).Any();
        //}

        //private static bool CheckEnumRelationshipPersonality(RelationshipPersonality EnumUser, RelationshipPersonality? EnumLooking)
        //{
        //    if (!EnumLooking.HasValue) return true; //If the user has not defined, then it is an affinity

        //    if (EnumUser == RelationshipPersonality.Explorers && EnumLooking.Value == RelationshipPersonality.Explorers) return true;
        //    if (EnumUser == RelationshipPersonality.Builders && EnumLooking.Value == RelationshipPersonality.Builders) return true;
        //    if (EnumUser == RelationshipPersonality.Directors && EnumLooking.Value == RelationshipPersonality.Negotiator) return true;
        //    if (EnumUser == RelationshipPersonality.Negotiator && EnumLooking.Value == RelationshipPersonality.Directors) return true;
        //    else return false;
        //}

        //private static bool CheckHeight(Height Height, Height? Looking_MinimalHeight, Height? Looking_MaxHeight)
        //{
        //    if (Looking_MinimalHeight.HasValue && Looking_MaxHeight.HasValue)
        //    {
        //        return Looking_MinimalHeight <= Height && Looking_MaxHeight >= Height;
        //    }
        //    else if (Looking_MinimalHeight.HasValue)
        //    {
        //        return Looking_MinimalHeight <= Height;
        //    }
        //    else if (Looking_MaxHeight.HasValue)
        //    {
        //        return Looking_MaxHeight >= Height;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        //#endregion AFFINITY

        //public async Task<List<Profile>> Profile_ListMatch(this HttpClient http)
        //{
        //    return await http.ListCustom<Profile>("Profile/ListMatch");
        //}

        //public async Task<List<Profile>> Profile_ListSearch(this HttpClient http)
        //{
        //    return await http.ListCustom<Profile>("Profile/ListSearch");
        //}

        //public async static Task<HttpResponseMessage> Profile_Add(this HttpClient http, ILocalStorageService storage, Profile obj, string id)
        //{
        //    var response = await http.PostAsJsonAsync("profile/post", obj);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        obj.Id = id; //TODO: descobrir outra maneira de saber se é insert ou update, pq depende desse campo
        //        await storage.SetItemAsync(StorageKey, obj);
        //        //await ProfileValidationApi.ClearCache(storage);
        //        await GamificationApi.ClearCache(storage);
        //    }

        //    return response;
        //}

        //public async Task<HttpResponseMessage> Profile_Update(this HttpClient http, ILocalStorageService storage, Profile obj)
        //{
        //    var response = await http.PostAsJsonAsync("Profile/Update", obj);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        await storage.SetItemAsync(StorageKey, obj);
        //        //await ProfileValidationApi.ClearCache(storage);
        //        await GamificationApi.ClearCache(storage);
        //    }

        //    return response;
        //}
    }
}