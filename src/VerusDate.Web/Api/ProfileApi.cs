using Blazored.SessionStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using VerusDate.Shared;
using VerusDate.Shared.Enum;
using VerusDate.Shared.Helper;
using VerusDate.Shared.Model;
using VerusDate.Shared.ModelQuery;
using VerusDate.Web.Core;

namespace VerusDate.Web.Api
{
    public static class ProfileApi
    {
        public async static Task<ProfileModel> Profile_Get(this HttpClient http, ISyncSessionStorageService storage)
        {
            return await http.Get<ProfileModel>("Profile/Get", storage);
        }

        public async static Task<ProfileView> Profile_GetView(this HttpClient http, ISyncSessionStorageService storage, string IdUserView)
        {
            return await http.Get<ProfileView>($"Profile/GetView?id={IdUserView}", storage);
        }

        public static List<AffinityVM> GetAffinity(ProfileModel profUser, ProfileView profView)
        {
            if (profUser == null) throw new NotificationException("Não foi possível identificar seu perfil");
            if (profView == null) throw new NotificationException("Não foi possível identificar o perfil deste usuário");
            if (profUser.Looking == null) throw new NotificationException("Não foi possível identificar seu perfil de busca");
            if (profView.Looking == null) throw new NotificationException("Não foi possível identificar o perfil de busca deste usuário");

            var obj = new List<AffinityVM>
            {
                //BASIC
                new AffinityVM(nameof(profView.Basic.BiologicalSex), CheckEnum((int)profView.Basic.BiologicalSex, (int?)profUser.Looking.BiologicalSex)),
                new AffinityVM(nameof(profView.Basic.MaritalStatus), CheckEnum((int)profView.Basic.MaritalStatus, (int?)profUser.Looking.MaritalStatus)),
                new AffinityVM(nameof(profView.Basic.Intent), CheckIntent(profView.Basic.Intent, profUser.Looking.Intent), profView.Basic.Intent.Intersect(profUser.Looking.Intent)),
                new AffinityVM(nameof(profView.Basic.GenderIdentity), CheckEnum((int)profView.Basic.GenderIdentity, (int?)profUser.Looking.GenderIdentity)),
                new AffinityVM(nameof(profView.Basic.SexualOrientation), CheckEnum((int)profView.Basic.SexualOrientation, (int?)profUser.Looking.SexualOrientation)),
                new AffinityVM(nameof(profView.Distance), profView.Distance <= profUser.Looking.Distance),
                //BIO
                new AffinityVM(nameof(profView.Age), CheckAge(profView.Age, profUser.Looking.MinimalAge, profUser.Looking.MaxAge)),
                new AffinityVM(nameof(profView.Bio.RaceCategory), CheckEnum((int)profView.Bio.RaceCategory, (int?)profUser.Looking.RaceCategory)),
                new AffinityVM(nameof(profView.Bio.Height), CheckHeight(profView.Bio.Height, profUser.Looking.MinimalHeight, profUser.Looking.MaxHeight)),
                new AffinityVM(nameof(profView.Bio.BodyMass), CheckEnum((int)profView.Bio.BodyMass, (int?)profUser.Looking.BodyMass))
            };

            if (profView.Basic.Intent.IsLongTerm())
            {
                //LIFESTYLE (compatibilidade independe das definições de busca)
                obj.Add(new AffinityVM(nameof(profView.Lifestyle.Smoke), CheckEnum((int)profView.Lifestyle.Smoke, (int?)profUser.Lifestyle.Smoke)));
                obj.Add(new AffinityVM(nameof(profView.Lifestyle.Drink), CheckEnum((int)profView.Lifestyle.Drink, (int?)profUser.Lifestyle.Drink)));
                obj.Add(new AffinityVM(nameof(profView.Lifestyle.Diet), CheckEnum((int)profView.Lifestyle.Diet, (int?)profUser.Lifestyle.Diet)));
                obj.Add(new AffinityVM(nameof(profView.Lifestyle.HaveChildren), CheckEnum((int)profView.Lifestyle.HaveChildren.Value, (int?)profUser.Lifestyle.HaveChildren)));
                obj.Add(new AffinityVM(nameof(profView.Lifestyle.WantChildren), CheckEnum((int)profView.Lifestyle.WantChildren.Value, (int?)profUser.Lifestyle.WantChildren)));
                obj.Add(new AffinityVM(nameof(profView.Lifestyle.Religion), CheckEnum((int)profView.Lifestyle.Religion.Value, (int?)profUser.Lifestyle.Religion)));
                obj.Add(new AffinityVM(nameof(profView.Lifestyle.EducationLevel), CheckEnum((int)profView.Lifestyle.EducationLevel.Value, (int?)profUser.Lifestyle.EducationLevel)));
                obj.Add(new AffinityVM(nameof(profView.Lifestyle.CareerCluster), CheckEnum((int)profView.Lifestyle.CareerCluster.Value, (int?)profUser.Lifestyle.CareerCluster)));
                obj.Add(new AffinityVM(nameof(profView.Lifestyle.MoneyPersonality), CheckEnum((int)profView.Lifestyle.MoneyPersonality.Value, (int?)profUser.Lifestyle.MoneyPersonality)));
                if (profView.Lifestyle.MyersBriggsTypeIndicator.HasValue)
                    obj.Add(new AffinityVM(nameof(profView.Lifestyle.MyersBriggsTypeIndicator), CheckEnumMBTI(profView.Lifestyle.MyersBriggsTypeIndicator.Value, profUser.Lifestyle.MyersBriggsTypeIndicator)));
                obj.Add(new AffinityVM(nameof(profView.Lifestyle.RelationshipPersonality), CheckEnumRelationshipPersonality(profView.Lifestyle.RelationshipPersonality.Value, profUser.Lifestyle.RelationshipPersonality)));
            }

            return obj;
        }

        #region AFFINITY

        private static bool CheckAge(int age, int? MinAge, int? MaxAge)
        {
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="EnumUser"></param>
        /// <param name="EnumView">Definido em Looking (se for lifestyle, é o que ta no perfil)</param>
        /// <returns></returns>
        private static bool CheckEnum(int EnumUser, int? EnumLooking)
        {
            if (!EnumLooking.HasValue) return true; //If the user has not defined, then it is an affinity

            return EnumUser == EnumLooking;
        }

        private static bool CheckIntent(IReadOnlyList<Intent> user, IReadOnlyList<Intent> looking)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            if (looking == null) throw new ArgumentNullException(nameof(looking));

            return user.Intersect(looking).Any();
        }

        private static bool CheckEnumRelationshipPersonality(RelationshipPersonality user, RelationshipPersonality? looking)
        {
            if (!looking.HasValue) return true; //If the user has not defined, then it is an affinity

            return user switch
            {
                RelationshipPersonality.Explorers => looking.Value == RelationshipPersonality.Explorers,
                RelationshipPersonality.Directors => looking.Value == RelationshipPersonality.Negotiator,
                RelationshipPersonality.Builders => looking.Value == RelationshipPersonality.Builders,
                RelationshipPersonality.Negotiator => looking.Value == RelationshipPersonality.Directors,
                _ => false,
            };
        }

        private static bool CheckEnumMBTI(MyersBriggsTypeIndicator user, MyersBriggsTypeIndicator? looking)
        {
            //http://www.personalityrelationships.net/
            if (!looking.HasValue) return true; //If the user has not defined, then it is an affinity

            return user switch
            {
                MyersBriggsTypeIndicator.INTJ => looking.Value == MyersBriggsTypeIndicator.ENTP || looking.Value == MyersBriggsTypeIndicator.ENFP,
                MyersBriggsTypeIndicator.INTP => looking.Value == MyersBriggsTypeIndicator.ENTJ || looking.Value == MyersBriggsTypeIndicator.ENFJ,
                MyersBriggsTypeIndicator.ENTJ => looking.Value == MyersBriggsTypeIndicator.INTP || looking.Value == MyersBriggsTypeIndicator.INFP,
                MyersBriggsTypeIndicator.ENTP => looking.Value == MyersBriggsTypeIndicator.INTJ || looking.Value == MyersBriggsTypeIndicator.INFJ,

                MyersBriggsTypeIndicator.INFJ => looking.Value == MyersBriggsTypeIndicator.ENFP || looking.Value == MyersBriggsTypeIndicator.ENTP || looking.Value == MyersBriggsTypeIndicator.INTJ || looking.Value == MyersBriggsTypeIndicator.INFJ,
                MyersBriggsTypeIndicator.INFP => looking.Value == MyersBriggsTypeIndicator.ENFJ || looking.Value == MyersBriggsTypeIndicator.ENTJ,
                MyersBriggsTypeIndicator.ENFJ => looking.Value == MyersBriggsTypeIndicator.INFP || looking.Value == MyersBriggsTypeIndicator.INTP,
                MyersBriggsTypeIndicator.ENFP => looking.Value == MyersBriggsTypeIndicator.INFJ || looking.Value == MyersBriggsTypeIndicator.INTJ,

                MyersBriggsTypeIndicator.ISTJ => looking.Value == MyersBriggsTypeIndicator.ESTP || looking.Value == MyersBriggsTypeIndicator.ESFP,
                MyersBriggsTypeIndicator.ISFJ => looking.Value == MyersBriggsTypeIndicator.ESFP || looking.Value == MyersBriggsTypeIndicator.ESTP,
                MyersBriggsTypeIndicator.ESTJ => looking.Value == MyersBriggsTypeIndicator.ISTP || looking.Value == MyersBriggsTypeIndicator.ISFP,
                MyersBriggsTypeIndicator.ESFJ => looking.Value == MyersBriggsTypeIndicator.ISFP || looking.Value == MyersBriggsTypeIndicator.ISTP,

                MyersBriggsTypeIndicator.ISTP => looking.Value == MyersBriggsTypeIndicator.ESFJ || looking.Value == MyersBriggsTypeIndicator.ESTJ,
                MyersBriggsTypeIndicator.ISFP => looking.Value == MyersBriggsTypeIndicator.ESTJ || looking.Value == MyersBriggsTypeIndicator.ESFJ,
                MyersBriggsTypeIndicator.ESTP => looking.Value == MyersBriggsTypeIndicator.ISTJ || looking.Value == MyersBriggsTypeIndicator.ISFJ,
                MyersBriggsTypeIndicator.ESFP => looking.Value == MyersBriggsTypeIndicator.ISTJ || looking.Value == MyersBriggsTypeIndicator.ISFJ,
                _ => false,
            };
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

        public static void Update_Profile_ListMatch(this ISyncSessionStorageService storage, List<ProfileSearch> list)
        {
            storage.SetItem("Profile/ListMatch", list);
        }

        public static async Task<List<ProfileSearch>> Profile_ListMatch(this HttpClient http, ISyncSessionStorageService storage)
        {
            return await http.GetList<ProfileSearch>("Profile/ListMatch", storage);
        }

        public static async Task<List<ProfileSearch>> Profile_ListSearch(this HttpClient http, ISyncSessionStorageService storage)
        {
            return await http.GetList<ProfileSearch>("Profile/ListSearch", storage);
        }

        public async static Task<HttpResponseMessage> Profile_Add(this HttpClient http, ProfileModel obj, ISyncSessionStorageService storage)
        {
            return await http.Post("Profile/Add", obj, storage, "Profile/Get");
        }

        public async static Task<HttpResponseMessage> Profile_Update(this HttpClient http, ProfileModel obj, ISyncSessionStorageService storage)
        {
            return await http.Put<ProfileModel>("Profile/Update", obj, storage, "Profile/Get");
        }

        public async static Task<HttpResponseMessage> Profile_UpdateLooking(this HttpClient http, ProfileModel obj, ISyncSessionStorageService storage)
        {
            return await http.Put<ProfileModel>("Profile/UpdateLooking", obj, storage, "Profile/Get");
        }
    }
}