using Blazored.LocalStorage;
using Blazored.SessionStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VerusDate.Shared;
using VerusDate.Shared.Enum;
using VerusDate.Shared.Model;
using VerusDate.Shared.ModelQuery;
using VerusDate.Web.Core;

namespace VerusDate.Web.Api
{
    public static class ProfileApi
    {
        public async static Task<ProfileModel> Profile_Get(this HttpClient http, ISyncLocalStorageService storage)
        {
            return await http.Get<ProfileModel>("Profile/Get", storage);
        }

        public async static Task<ProfileModel> Profile_GetView(this HttpClient http, ISyncSessionStorageService storage, string IdUserView)
        {
            return await http.Get<ProfileModel>($"Profile/GetView?id={IdUserView}", storage);
        }

        public static List<AffinityVM> GetAffinity(ProfileLookingModel profUser, ProfileModel profView)
        {
            if (profUser == null) throw new ArgumentNullException(nameof(profUser));
            if (profView == null) throw new ArgumentNullException(nameof(profView));

            var obj = new List<AffinityVM>
            {
                new AffinityVM(nameof(profView.Bio.BirthDate), CheckAge(profView.Bio.BirthDate, profUser.MinimalAge, profUser.MaxAge)),
                new AffinityVM(nameof(profView.Basic.BiologicalSex), CheckEnum((int)profView.Basic.BiologicalSex, (int?)profUser.BiologicalSex)),
                new AffinityVM(nameof(profView.Basic.MaritalStatus), CheckEnum((int)profView.Basic.MaritalStatus, (int?)profUser.MaritalStatus)),
                new AffinityVM(nameof(profView.Basic.Intent), CheckMultiple(profView.Basic.Intent, profUser.Intent)),
                new AffinityVM(nameof(profView.Basic.GenderIdentity), CheckEnum((int)profView.Basic.GenderIdentity, (int?)profUser.GenderIdentity)),
                new AffinityVM(nameof(profView.Basic.SexualOrientation), CheckEnum((int)profView.Basic.SexualOrientation, (int?)profUser.SexualOrientation)),
                //distancia
                new AffinityVM(nameof(profView.Lifestyle.Smoke), CheckEnum((int)profView.Lifestyle.Smoke, (int?)profUser.Smoke)),
                new AffinityVM(nameof(profView.Lifestyle.Drink), CheckEnum((int)profView.Lifestyle.Drink, (int?)profUser.Drink)),
                new AffinityVM(nameof(profView.Lifestyle.Diet), CheckEnum((int)profView.Lifestyle.Diet, (int?)profUser.Diet)),
                new AffinityVM(nameof(profView.Bio.Height), CheckHeight(profView.Bio.Height, profUser.MinimalHeight, profUser.MaxHeight)),
                new AffinityVM(nameof(profView.Bio.BodyMass), CheckEnum((int)profView.Bio.BodyMass, (int?)profUser.BodyMass)),
                new AffinityVM(nameof(profView.Bio.RaceCategory), CheckEnum((int)profView.Bio.RaceCategory, (int?)profUser.RaceCategory))
            };

            if (profView.Basic.Intent.IsLongTerm())
            {
                obj.Add(new AffinityVM(nameof(profView.Lifestyle.HaveChildren), CheckEnum((int)profView.Lifestyle.HaveChildren.Value, (int?)profUser.HaveChildren)));
                obj.Add(new AffinityVM(nameof(profView.Lifestyle.WantChildren), CheckEnum((int)profView.Lifestyle.WantChildren.Value, (int?)profUser.WantChildren)));
                obj.Add(new AffinityVM(nameof(profView.Lifestyle.Religion), CheckEnum((int)profView.Lifestyle.Religion.Value, (int?)profUser.Religion)));
                obj.Add(new AffinityVM(nameof(profView.Lifestyle.EducationLevel), CheckEnum((int)profView.Lifestyle.EducationLevel.Value, (int?)profUser.EducationLevel)));
                obj.Add(new AffinityVM(nameof(profView.Lifestyle.CareerCluster), CheckEnum((int)profView.Lifestyle.CareerCluster.Value, (int?)profUser.CareerCluster)));
                //TODO: não é oq ele procura, é o ele é
                //obj.Add(new AffinityVM(nameof(profView.MoneyPersonality), CheckEnum((int)profView.MoneyPersonality.Value, (int?)profUser.MoneyPersonality)));
                //obj.Add(new AffinityVM(nameof(profView.MyersBriggsTypeIndicator), CheckEnum((int)profView.MyersBriggsTypeIndicator.Value, (int?)profUser.MyersBriggsTypeIndicator)));
                //obj.Add(new AffinityVM(nameof(profView.RelationshipPersonality), CheckEnumRelationshipPersonality(profView.RelationshipPersonality.Value, profUser.RelationshipPersonality)));
            }

            return obj;
        }

        #region AFFINITY

        private static bool CheckAge(DateTime BirthDate, int? MinAge, int? MaxAge)
        {
            var age = DateTime.Now.Year - BirthDate.Year;

            if (MinAge.HasValue && MaxAge.HasValue)
            {
                return MinAge <= age && MaxAge >= age;
            }
            else if (MinAge.HasValue)
            {
                return MinAge <= age;
            }
            else if (MaxAge.HasValue)
            {
                return MaxAge >= age;
            }
            else
            {
                return true;
            }
        }

        private static bool CheckEnum(int EnumUser, int? EnumLooking)
        {
            if (!EnumLooking.HasValue) return true; //If the user has not defined, then it is an affinity

            return EnumUser == EnumLooking;
        }

        private static bool CheckMultiple(IReadOnlyList<Intent> user, IReadOnlyList<Intent> looking)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (looking == null) throw new ArgumentNullException(nameof(looking));

            return user.Intersect(looking).Any();
        }

        private static bool CheckEnumRelationshipPersonality(RelationshipPersonality EnumUser, RelationshipPersonality? EnumLooking)
        {
            if (!EnumLooking.HasValue) return true; //If the user has not defined, then it is an affinity

            if (EnumUser == RelationshipPersonality.Explorers && EnumLooking.Value == RelationshipPersonality.Explorers) return true;
            if (EnumUser == RelationshipPersonality.Builders && EnumLooking.Value == RelationshipPersonality.Builders) return true;
            if (EnumUser == RelationshipPersonality.Directors && EnumLooking.Value == RelationshipPersonality.Negotiator) return true;
            if (EnumUser == RelationshipPersonality.Negotiator && EnumLooking.Value == RelationshipPersonality.Directors) return true;
            else return false;
        }

        private static bool CheckHeight(Height Height, Height? Looking_MinimalHeight, Height? Looking_MaxHeight)
        {
            if (Looking_MinimalHeight.HasValue && Looking_MaxHeight.HasValue)
            {
                return Looking_MinimalHeight <= Height && Looking_MaxHeight >= Height;
            }
            else if (Looking_MinimalHeight.HasValue)
            {
                return Looking_MinimalHeight <= Height;
            }
            else if (Looking_MaxHeight.HasValue)
            {
                return Looking_MaxHeight >= Height;
            }
            else
            {
                return true;
            }
        }

        #endregion AFFINITY

        public static async Task<List<ProfileSearch>> Profile_ListMatch(this HttpClient http, ISyncSessionStorageService storage)
        {
            return await http.GetList<ProfileSearch>("Profile/ListMatch", storage);
        }

        public static async Task<List<ProfileSearch>> Profile_ListSearch(this HttpClient http, ISyncSessionStorageService storage)
        {
            return await http.GetList<ProfileSearch>("Profile/ListSearch", storage);
        }

        public async static Task<HttpResponseMessage> Profile_Add(this HttpClient http, ProfileModel obj, ISyncLocalStorageService storage)
        {
            return await http.Post("Profile/Add", obj, storage, "Profile/Get");
        }

        public async static Task<HttpResponseMessage> Profile_Update(this HttpClient http, ProfileModel obj, ISyncLocalStorageService storage)
        {
            return await http.Put("Profile/Update", obj, storage, "Profile/Get");
        }

        public async static Task<HttpResponseMessage> Profile_UpdateLooking(this HttpClient http, ProfileModel obj, ISyncLocalStorageService storage)
        {
            return await http.Put("Profile/UpdateLooking", obj, storage, "Profile/Get");
        }
    }
}