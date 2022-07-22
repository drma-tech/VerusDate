using VerusDate.Shared;
using VerusDate.Shared.Enum;
using VerusDate.Shared.Helper;
using VerusDate.Shared.Model;

namespace VerusDate.Web.Core
{
    public static class AffinityCore
    {
        public static List<AffinityVM> GetAffinity(ProfileModel profUser, ProfileView profView)
        {
            if (profUser == null) throw new NotificationException("Não foi possível identificar seu perfil");
            if (profView == null) throw new NotificationException("Não foi possível identificar o perfil deste usuário");
            if (profUser.Preference == null) throw new NotificationException("Não foi possível identificar suas preferências");
            if (profView.Preference == null) throw new NotificationException("Não foi possível identificar as preferências deste usuário");

            var obj = new List<AffinityVM>();

            //BASIC - DEFINIÇÕES DE BUSCA
            obj.Add(new AffinityVM(AffinityCategory.Basic, nameof(profView.Basic.BiologicalSex), CheckEnumArray(profView.Basic.BiologicalSex, profUser.Preference.BiologicalSex)));
            obj.Add(new AffinityVM(AffinityCategory.Basic, nameof(profView.Basic.CurrentSituation), CheckEnumArray(profView.Basic.CurrentSituation, profUser.Preference.CurrentSituation)));
            obj.Add(new AffinityVM(AffinityCategory.Basic, nameof(profView.Basic.Intentions), CheckEnumArray(profView.Basic.Intentions, profUser.Preference.Intentions), profView.Basic.Intentions.Intersect(profUser.Preference.Intentions).Select(s => (int)s)));
            obj.Add(new AffinityVM(AffinityCategory.Basic, nameof(profView.Basic.GenderIdentity), CheckEnumArray(profView.Basic.GenderIdentity, profUser.Preference.GenderIdentity)));
            obj.Add(new AffinityVM(AffinityCategory.Basic, nameof(profView.Basic.SexualOrientation), CheckEnumArray(profView.Basic.SexualOrientation, profUser.Preference.SexualOrientation)));
            obj.Add(new AffinityVM(AffinityCategory.Basic, nameof(profView.Distance), profView.Distance <= (double)profUser.Preference.Distance));
            obj.Add(new AffinityVM(AffinityCategory.Basic, nameof(profView.Basic.Languages), CheckEnumArray(profView.Basic.Languages, profUser.Preference.Languages), profView.Basic.Languages.Intersect(profUser.Preference.Languages).Select(s => (int)s)));

            //BIO - DEFINIÇÕES DE BUSCA
            obj.Add(new AffinityVM(AffinityCategory.Bio, nameof(profView.Age), CheckAge(profView.Age, profUser.Preference.MinimalAge, profUser.Preference.MaxAge)));
            obj.Add(new AffinityVM(AffinityCategory.Bio, nameof(profView.Bio.Zodiac), CheckEnumZodiac(profView.Bio.Zodiac, profUser.Bio.Zodiac)));
            obj.Add(new AffinityVM(AffinityCategory.Bio, nameof(profView.Bio.RaceCategory), CheckEnumArray(profView.Bio.RaceCategory, profUser.Preference.RaceCategory)));
            obj.Add(new AffinityVM(AffinityCategory.Bio, nameof(profView.Bio.Height), CheckHeight(profView.Bio.Height, profUser.Preference.MinimalHeight, profUser.Preference.MaxHeight)));
            obj.Add(new AffinityVM(AffinityCategory.Bio, nameof(profView.Bio.BodyMass), CheckEnumArray(profView.Bio.BodyMass, profUser.Preference.BodyMass)));

            if (profView.Basic.Intentions.IsLongTerm())
            {
                //LIFESTYLE - COMPATIBILIDADE DE PERFIL
                obj.Add(new AffinityVM(AffinityCategory.Lifestyle, nameof(profView.Lifestyle.Smoke), CheckSmoke(profView.Lifestyle.Smoke.Value, profUser.Lifestyle.Smoke.Value)));
                obj.Add(new AffinityVM(AffinityCategory.Lifestyle, nameof(profView.Lifestyle.Drink), CheckDrink(profView.Lifestyle.Drink.Value, profUser.Lifestyle.Drink.Value)));
                obj.Add(new AffinityVM(AffinityCategory.Lifestyle, nameof(profView.Lifestyle.Diet), CheckDiet(profView.Lifestyle.Diet.Value, profUser.Lifestyle.Diet.Value)));
                obj.Add(new AffinityVM(AffinityCategory.Lifestyle, nameof(profView.Lifestyle.HaveChildren), CheckHaveChildren(profView.Lifestyle.HaveChildren.Value, profUser.Lifestyle.HaveChildren.Value)));
                obj.Add(new AffinityVM(AffinityCategory.Lifestyle, nameof(profView.Lifestyle.WantChildren), CheckWantChildren(profView.Lifestyle.WantChildren.Value, profUser.Lifestyle.WantChildren.Value)));
                obj.Add(new AffinityVM(AffinityCategory.Lifestyle, nameof(profView.Lifestyle.Religion), CheckEnum((int)profView.Lifestyle.Religion.Value, (int?)profUser.Lifestyle.Religion)));
                obj.Add(new AffinityVM(AffinityCategory.Lifestyle, nameof(profView.Lifestyle.EducationLevel), CheckEnum((int)profView.Lifestyle.EducationLevel.Value, (int?)profUser.Lifestyle.EducationLevel)));
                obj.Add(new AffinityVM(AffinityCategory.Lifestyle, nameof(profView.Lifestyle.CareerCluster), CheckEnum((int)profView.Lifestyle.CareerCluster.Value, (int)profUser.Lifestyle.CareerCluster.Value)));
                obj.Add(new AffinityVM(AffinityCategory.Lifestyle, nameof(profView.Lifestyle.MoneyPersonality), CheckEnum((int)profView.Lifestyle.MoneyPersonality.Value, (int)profUser.Lifestyle.MoneyPersonality.Value)));
                obj.Add(new AffinityVM(AffinityCategory.Lifestyle, nameof(profView.Lifestyle.SplitTheBill), CheckSplitTheBill(profView.Lifestyle.SplitTheBill.Value, profUser.Lifestyle.SplitTheBill.Value)));
                obj.Add(new AffinityVM(AffinityCategory.Lifestyle, nameof(profView.Lifestyle.RelationshipPersonality), CheckEnumRelationshipPersonality(profView.Lifestyle.RelationshipPersonality.Value, profUser.Lifestyle.RelationshipPersonality.Value)));
                obj.Add(new AffinityVM(AffinityCategory.Lifestyle, nameof(profView.Lifestyle.LoveLanguage), CheckEnum((int)profView.Lifestyle.LoveLanguage.Value, (int?)profUser.Lifestyle.LoveLanguage)));
                obj.Add(new AffinityVM(AffinityCategory.Lifestyle, nameof(profView.Lifestyle.MyersBriggsTypeIndicator), CheckEnumMBTI(profView.Lifestyle.MyersBriggsTypeIndicator, profUser.Lifestyle.MyersBriggsTypeIndicator)));
                obj.Add(new AffinityVM(AffinityCategory.Lifestyle, nameof(profView.Lifestyle.SexPersonality), CheckEnumArray(profView.Lifestyle.SexPersonality.Value, profUser.Lifestyle.SexPersonalityPreferences)));

                //INTEREST - COMPATIBILIDADE DE PERFIL / UMA OPÇAO IGUAL JÁ INDICA COMPATIBILIDADE
                obj.Add(new AffinityVM(AffinityCategory.Interest, nameof(profView.Interest.Food), CheckEnumArray(profView.Interest.Food, profUser.Interest.Food), profView.Interest.Food.Intersect(profUser.Interest.Food).Select(s => (int)s)));
                obj.Add(new AffinityVM(AffinityCategory.Interest, nameof(profView.Interest.Vacation), CheckEnumArray(profView.Interest.Vacation, profUser.Interest.Vacation), profView.Interest.Vacation.Intersect(profUser.Interest.Vacation).Select(s => (int)s)));
                obj.Add(new AffinityVM(AffinityCategory.Interest, nameof(profView.Interest.Sports), CheckEnumArray(profView.Interest.Sports, profUser.Interest.Sports), profView.Interest.Sports.Intersect(profUser.Interest.Sports).Select(s => (int)s)));
                obj.Add(new AffinityVM(AffinityCategory.Interest, nameof(profView.Interest.LeisureActivities), CheckEnumArray(profView.Interest.LeisureActivities, profUser.Interest.LeisureActivities), profView.Interest.LeisureActivities.Intersect(profUser.Interest.LeisureActivities).Select(s => (int)s)));
                obj.Add(new AffinityVM(AffinityCategory.Interest, nameof(profView.Interest.MusicGenre), CheckEnumArray(profView.Interest.MusicGenre, profUser.Interest.MusicGenre), profView.Interest.MusicGenre.Intersect(profUser.Interest.MusicGenre).Select(s => (int)s)));
                obj.Add(new AffinityVM(AffinityCategory.Interest, nameof(profView.Interest.MovieGenre), CheckEnumArray(profView.Interest.MovieGenre, profUser.Interest.MovieGenre), profView.Interest.MovieGenre.Intersect(profUser.Interest.MovieGenre).Select(s => (int)s)));
                obj.Add(new AffinityVM(AffinityCategory.Interest, nameof(profView.Interest.TVGenre), CheckEnumArray(profView.Interest.TVGenre, profUser.Interest.TVGenre), profView.Interest.TVGenre.Intersect(profUser.Interest.TVGenre).Select(s => (int)s)));
                obj.Add(new AffinityVM(AffinityCategory.Interest, nameof(profView.Interest.ReadingGenre), CheckEnumArray(profView.Interest.ReadingGenre, profUser.Interest.ReadingGenre), profView.Interest.ReadingGenre.Intersect(profUser.Interest.ReadingGenre).Select(s => (int)s)));
            }

            return obj;
        }

        private static bool CheckEnum(int view, int? looking)
        {
            if (!looking.HasValue) return true; //If the user has not defined, then it is an affinity

            return view == looking;
        }

        private static bool CheckEnumArray<T>(T view, IEnumerable<T> looking) where T : System.Enum
        {
            if (!looking.Any()) return true; //If the user has not defined, then it is an affinity

            return new T[] { view }.Intersect(looking).Any();
        }

        private static bool CheckEnumArray<T>(IEnumerable<T> view, IEnumerable<T> looking) where T : System.Enum
        {
            if (!looking.Any()) return true; //if the user did not choose any, then all are an affinity

            return view.Intersect(looking).Any();
        }

        #region BIO

        private static bool CheckAge(int age, int? Looking_MinAge, int? Looking_MaxAge)
        {
            if (Looking_MinAge.HasValue && Looking_MaxAge.HasValue)
            {
                return Looking_MinAge <= age && Looking_MaxAge >= age;
            }
            else if (Looking_MinAge.HasValue)
            {
                return Looking_MinAge <= age;
            }
            else if (Looking_MaxAge.HasValue)
            {
                return Looking_MaxAge >= age;
            }
            else
            {
                return true;
            }
        }

        private static bool CheckEnumZodiac(Zodiac view, Zodiac user)
        {
            return user switch
            {
                Zodiac.Aries => view == Zodiac.Leo || view == Zodiac.Sagittarius,
                Zodiac.Taurus => view == Zodiac.Virgo || view == Zodiac.Capricorn,
                Zodiac.Gemini => view == Zodiac.Libra || view == Zodiac.Aquarius,
                Zodiac.Cancer => view == Zodiac.Scorpio || view == Zodiac.Pisces,
                Zodiac.Leo => view == Zodiac.Aries || view == Zodiac.Sagittarius,
                Zodiac.Virgo => view == Zodiac.Taurus || view == Zodiac.Capricorn,
                Zodiac.Libra => view == Zodiac.Gemini || view == Zodiac.Aquarius,
                Zodiac.Scorpio => view == Zodiac.Cancer || view == Zodiac.Scorpio || view == Zodiac.Pisces,
                Zodiac.Sagittarius => view == Zodiac.Aries || view == Zodiac.Leo,
                Zodiac.Capricorn => view == Zodiac.Taurus || view == Zodiac.Virgo,
                Zodiac.Aquarius => view == Zodiac.Gemini || view == Zodiac.Libra,
                Zodiac.Pisces => view == Zodiac.Cancer || view == Zodiac.Scorpio,
                _ => throw new System.NotImplementedException()
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

        #endregion BIO

        #region LIFESTYLE

        private static bool CheckSmoke(Smoke view, Smoke user)
        {
            return user switch
            {
                Smoke.No => view == Smoke.No,
                Smoke.YesOccasionally => view == Smoke.YesOccasionally || view == Smoke.YesOften,
                Smoke.YesOften => view == Smoke.YesOccasionally || view == Smoke.YesOften,
                _ => throw new System.NotImplementedException()
            };
        }

        private static bool CheckDrink(Drink view, Drink user)
        {
            return user switch
            {
                Drink.No => view == Drink.No || view == Drink.YesLight,
                Drink.YesLight => view == Drink.No || view == Drink.YesLight,
                Drink.YesModerate => view == Drink.YesModerate || view == Drink.YesHeavy,
                Drink.YesHeavy => view == Drink.YesModerate || view == Drink.YesHeavy,
                _ => throw new System.NotImplementedException()
            };
        }

        private static bool CheckDiet(Diet view, Diet user)
        {
            var group01 = view == Diet.Omnivore || view == Diet.Flexitarian || view == Diet.GlutenFree;
            var group02 = view == Diet.Vegetarian || view == Diet.Vegan;
            var group03 = view == Diet.RawFood || view == Diet.OrganicAllnaturalLocal;

            return user switch
            {
                Diet.Omnivore => group01,
                Diet.Flexitarian => group01,
                Diet.Vegetarian => group02,
                Diet.Vegan => group02,
                Diet.RawFood => group03,
                Diet.GlutenFree => group01,
                Diet.OrganicAllnaturalLocal => group03,
                Diet.DetoxWeightLoss => view == Diet.DetoxWeightLoss,
                _ => throw new System.NotImplementedException()
            };
        }

        private static bool CheckHaveChildren(HaveChildren view, HaveChildren user)
        {
            return user switch
            {
                HaveChildren.No => view == HaveChildren.No || view == HaveChildren.YesNo,
                HaveChildren.YesNo => view == HaveChildren.No || view == HaveChildren.YesNo,
                HaveChildren.Yes => view == HaveChildren.Yes,
                _ => throw new System.NotImplementedException()
            };
        }

        private static bool CheckWantChildren(WantChildren view, WantChildren user)
        {
            return user switch
            {
                WantChildren.No => view == WantChildren.No,
                WantChildren.Maybe => view == WantChildren.Maybe || view == WantChildren.Yes,
                WantChildren.Yes => view == WantChildren.Maybe || view == WantChildren.Yes,
                _ => throw new System.NotImplementedException()
            };
        }

        private static bool CheckSplitTheBill(SplitTheBill view, SplitTheBill user)
        {
            //invented by me (dhiogo)

            return user switch
            {
                SplitTheBill.Dependent => view == SplitTheBill.Provider,
                SplitTheBill.GetGifts => view == SplitTheBill.SendGifts,
                SplitTheBill.Balanced => view == SplitTheBill.Balanced,
                SplitTheBill.SendGifts => view == SplitTheBill.GetGifts,
                SplitTheBill.Provider => view == SplitTheBill.Dependent,
                _ => throw new System.NotImplementedException()
            };
        }

        private static bool CheckEnumMBTI(MyersBriggsTypeIndicator? view, MyersBriggsTypeIndicator? user)
        {
            //http://www.personalityrelationships.net/
            //https://web.archive.org/web/20220322143220/http://www.personalityrelationships.net/

            //se um dos dois usuário não responderem, persumi-se que não tem afinidade
            if (!user.HasValue) return false;
            if (!view.HasValue) return false;

            return user switch
            {
                MyersBriggsTypeIndicator.INTJ => view.Value == MyersBriggsTypeIndicator.ENTP || view.Value == MyersBriggsTypeIndicator.ENFP,
                MyersBriggsTypeIndicator.INTP => view.Value == MyersBriggsTypeIndicator.ENTJ || view.Value == MyersBriggsTypeIndicator.ENFJ,
                MyersBriggsTypeIndicator.ENTJ => view.Value == MyersBriggsTypeIndicator.INTP || view.Value == MyersBriggsTypeIndicator.INFP,
                MyersBriggsTypeIndicator.ENTP => view.Value == MyersBriggsTypeIndicator.INTJ || view.Value == MyersBriggsTypeIndicator.INFJ,

                MyersBriggsTypeIndicator.INFJ => view.Value == MyersBriggsTypeIndicator.ENFP || view.Value == MyersBriggsTypeIndicator.ENTP || view.Value == MyersBriggsTypeIndicator.INTJ || view.Value == MyersBriggsTypeIndicator.INFJ,
                MyersBriggsTypeIndicator.INFP => view.Value == MyersBriggsTypeIndicator.ENFJ || view.Value == MyersBriggsTypeIndicator.ENTJ,
                MyersBriggsTypeIndicator.ENFJ => view.Value == MyersBriggsTypeIndicator.INFP || view.Value == MyersBriggsTypeIndicator.INTP,
                MyersBriggsTypeIndicator.ENFP => view.Value == MyersBriggsTypeIndicator.INFJ || view.Value == MyersBriggsTypeIndicator.INTJ,

                MyersBriggsTypeIndicator.ISTJ => view.Value == MyersBriggsTypeIndicator.ESTP || view.Value == MyersBriggsTypeIndicator.ESFP,
                MyersBriggsTypeIndicator.ISFJ => view.Value == MyersBriggsTypeIndicator.ESFP || view.Value == MyersBriggsTypeIndicator.ESTP,
                MyersBriggsTypeIndicator.ESTJ => view.Value == MyersBriggsTypeIndicator.ISTP || view.Value == MyersBriggsTypeIndicator.ISFP,
                MyersBriggsTypeIndicator.ESFJ => view.Value == MyersBriggsTypeIndicator.ISFP || view.Value == MyersBriggsTypeIndicator.ISTP,

                MyersBriggsTypeIndicator.ISTP => view.Value == MyersBriggsTypeIndicator.ESFJ || view.Value == MyersBriggsTypeIndicator.ESTJ,
                MyersBriggsTypeIndicator.ISFP => view.Value == MyersBriggsTypeIndicator.ESTJ || view.Value == MyersBriggsTypeIndicator.ESFJ,
                MyersBriggsTypeIndicator.ESTP => view.Value == MyersBriggsTypeIndicator.ISTJ || view.Value == MyersBriggsTypeIndicator.ISFJ,
                MyersBriggsTypeIndicator.ESFP => view.Value == MyersBriggsTypeIndicator.ISTJ || view.Value == MyersBriggsTypeIndicator.ISFJ,
                _ => throw new System.NotImplementedException()
            };
        }

        private static bool CheckEnumRelationshipPersonality(RelationshipPersonality view, RelationshipPersonality user)
        {
            //https://helenfisher.com/downloads/articles/Article_%20We%20Have%20Chemistry.pdf

            return user switch
            {
                RelationshipPersonality.Explorers => view == RelationshipPersonality.Explorers,
                RelationshipPersonality.Directors => view == RelationshipPersonality.Negotiator,
                RelationshipPersonality.Builders => view == RelationshipPersonality.Builders,
                RelationshipPersonality.Negotiator => view == RelationshipPersonality.Directors,
                _ => throw new System.NotImplementedException()
            };
        }

        #endregion LIFESTYLE
    }
}