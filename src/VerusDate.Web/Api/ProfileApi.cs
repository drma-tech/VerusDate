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
                new AffinityVM(nameof(profView.Age), CheckAge(profView.Age, profUser.Looking.MinimalAge, profUser.Looking.MaxAge)),
                new AffinityVM(nameof(profView.Basic.BiologicalSex), CheckEnum((int)profView.Basic.BiologicalSex, (int?)profUser.Looking.BiologicalSex)),
                new AffinityVM(nameof(profView.Basic.MaritalStatus), CheckEnum((int)profView.Basic.MaritalStatus, (int?)profUser.Looking.MaritalStatus)),
                new AffinityVM(nameof(profView.Basic.Intent), CheckMultiple(profView.Basic.Intent, profUser.Looking.Intent), profView.Basic.Intent.Intersect(profUser.Looking.Intent)),
                new AffinityVM(nameof(profView.Basic.GenderIdentity), CheckEnum((int)profView.Basic.GenderIdentity, (int?)profUser.Looking.GenderIdentity)),
                new AffinityVM(nameof(profView.Basic.SexualOrientation), CheckEnum((int)profView.Basic.SexualOrientation, (int?)profUser.Looking.SexualOrientation)),
                new AffinityVM(nameof(profView.Distance), profView.Distance <= profUser.Looking.Distance),
                new AffinityVM(nameof(profView.Lifestyle.Smoke), CheckEnum((int)profView.Lifestyle.Smoke, (int?)profUser.Looking.Smoke)),
                new AffinityVM(nameof(profView.Lifestyle.Drink), CheckEnum((int)profView.Lifestyle.Drink, (int?)profUser.Looking.Drink)),
                new AffinityVM(nameof(profView.Lifestyle.Diet), CheckEnum((int)profView.Lifestyle.Diet, (int?)profUser.Looking.Diet)),
                new AffinityVM(nameof(profView.Bio.Height), CheckHeight(profView.Bio.Height, profUser.Looking.MinimalHeight, profUser.Looking.MaxHeight)),
                new AffinityVM(nameof(profView.Bio.BodyMass), CheckEnum((int)profView.Bio.BodyMass, (int?)profUser.Looking.BodyMass)),
                new AffinityVM(nameof(profView.Bio.RaceCategory), CheckEnum((int)profView.Bio.RaceCategory, (int?)profUser.Looking.RaceCategory))
            };

            if (profView.Basic.Intent.IsLongTerm())
            {
                obj.Add(new AffinityVM(nameof(profView.Lifestyle.HaveChildren), CheckEnum((int)profView.Lifestyle.HaveChildren.Value, (int?)profUser.Looking.HaveChildren)));
                obj.Add(new AffinityVM(nameof(profView.Lifestyle.WantChildren), CheckEnum((int)profView.Lifestyle.WantChildren.Value, (int?)profUser.Looking.WantChildren)));
                obj.Add(new AffinityVM(nameof(profView.Lifestyle.Religion), CheckEnum((int)profView.Lifestyle.Religion.Value, (int?)profUser.Looking.Religion)));
                obj.Add(new AffinityVM(nameof(profView.Lifestyle.EducationLevel), CheckEnum((int)profView.Lifestyle.EducationLevel.Value, (int?)profUser.Looking.EducationLevel)));
                obj.Add(new AffinityVM(nameof(profView.Lifestyle.CareerCluster), CheckEnum((int)profView.Lifestyle.CareerCluster.Value, (int?)profUser.Looking.CareerCluster)));
                //daqui em diante: não é oq ele procura, é o que ele é
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

            return EnumUser switch
            {
                RelationshipPersonality.Explorers => EnumLooking.Value == RelationshipPersonality.Explorers,
                RelationshipPersonality.Directors => EnumLooking.Value == RelationshipPersonality.Negotiator,
                RelationshipPersonality.Builders => EnumLooking.Value == RelationshipPersonality.Builders,
                RelationshipPersonality.Negotiator => EnumLooking.Value == RelationshipPersonality.Directors,
                _ => false,
            };
        }

        private static bool CheckEnumMBTI(MyersBriggsTypeIndicator EnumUser, MyersBriggsTypeIndicator? EnumLooking)
        {
            //http://www.personalityrelationships.net/
            if (!EnumLooking.HasValue) return true; //If the user has not defined, then it is an affinity

            return EnumUser switch
            {
                MyersBriggsTypeIndicator.INTJ => EnumLooking.Value == MyersBriggsTypeIndicator.ENTP || EnumLooking.Value == MyersBriggsTypeIndicator.ENFP,
                MyersBriggsTypeIndicator.INTP => EnumLooking.Value == MyersBriggsTypeIndicator.ENTJ || EnumLooking.Value == MyersBriggsTypeIndicator.ENFJ,
                MyersBriggsTypeIndicator.ENTJ => EnumLooking.Value == MyersBriggsTypeIndicator.INTP || EnumLooking.Value == MyersBriggsTypeIndicator.INFP,
                MyersBriggsTypeIndicator.ENTP => EnumLooking.Value == MyersBriggsTypeIndicator.INTJ || EnumLooking.Value == MyersBriggsTypeIndicator.INFJ,
                
                MyersBriggsTypeIndicator.INFJ => EnumLooking.Value == MyersBriggsTypeIndicator.ENFP || EnumLooking.Value == MyersBriggsTypeIndicator.ENTP || EnumLooking.Value == MyersBriggsTypeIndicator.INTJ || EnumLooking.Value == MyersBriggsTypeIndicator.INFJ,
                MyersBriggsTypeIndicator.INFP => EnumLooking.Value == MyersBriggsTypeIndicator.ENFJ || EnumLooking.Value == MyersBriggsTypeIndicator.ENTJ,
                MyersBriggsTypeIndicator.ENFJ => EnumLooking.Value == MyersBriggsTypeIndicator.INFP || EnumLooking.Value == MyersBriggsTypeIndicator.INTP,
                MyersBriggsTypeIndicator.ENFP => EnumLooking.Value == MyersBriggsTypeIndicator.INFJ || EnumLooking.Value == MyersBriggsTypeIndicator.INTJ,
                
                MyersBriggsTypeIndicator.ISTJ => EnumLooking.Value == MyersBriggsTypeIndicator.ESTP || EnumLooking.Value == MyersBriggsTypeIndicator.ESFP,
                MyersBriggsTypeIndicator.ISFJ => EnumLooking.Value == MyersBriggsTypeIndicator.ESFP || EnumLooking.Value == MyersBriggsTypeIndicator.ESTP,
                MyersBriggsTypeIndicator.ESTJ => EnumLooking.Value == MyersBriggsTypeIndicator.ISTP || EnumLooking.Value == MyersBriggsTypeIndicator.ISFP,
                MyersBriggsTypeIndicator.ESFJ => EnumLooking.Value == MyersBriggsTypeIndicator.ISFP || EnumLooking.Value == MyersBriggsTypeIndicator.ISTP,
                
                MyersBriggsTypeIndicator.ISTP => EnumLooking.Value == MyersBriggsTypeIndicator.ESFJ || EnumLooking.Value == MyersBriggsTypeIndicator.ESTJ,
                MyersBriggsTypeIndicator.ISFP => EnumLooking.Value == MyersBriggsTypeIndicator.ESTJ || EnumLooking.Value == MyersBriggsTypeIndicator.ESFJ,
                MyersBriggsTypeIndicator.ESTP => EnumLooking.Value == MyersBriggsTypeIndicator.ISTJ || EnumLooking.Value == MyersBriggsTypeIndicator.ISFJ,
                MyersBriggsTypeIndicator.ESFP => EnumLooking.Value == MyersBriggsTypeIndicator.ISTJ || EnumLooking.Value == MyersBriggsTypeIndicator.ISFJ,
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