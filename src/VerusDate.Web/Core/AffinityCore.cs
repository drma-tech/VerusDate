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

            var obj = new List<AffinityVM>();

            //BASIC - DEFINIÇÕES DE BUSCA
            obj.Add(new AffinityVM(AffinityCategory.Basic, nameof(profView.BiologicalSex), CheckEnumArray(profView.BiologicalSex, profUser.Preference.BiologicalSex)));
            obj.Add(new AffinityVM(AffinityCategory.Basic, nameof(profView.CurrentSituation), CheckEnumArray(profView.CurrentSituation, profUser.Preference.CurrentSituation)));
            obj.Add(new AffinityVM(AffinityCategory.Basic, nameof(profView.Intentions), CheckEnumArrays(profView.Intentions, profUser.Intentions), profView.Intentions.Intersect(profUser.Intentions).Select(s => (int)s)));
            obj.Add(new AffinityVM(AffinityCategory.Basic, nameof(profView.GenderIdentity), CheckEnumArray(profView.GenderIdentity, profUser.Preference.GenderIdentity)));
            obj.Add(new AffinityVM(AffinityCategory.Basic, nameof(profView.SexualOrientation), CheckEnumArray(profView.SexualOrientation, profUser.Preference.SexualOrientation)));
            //obj.Add(new AffinityVM(AffinityCategory.Basic, nameof(profView.Distance), profView.Distance <= (double)profUser.Preference.Distance));
            obj.Add(new AffinityVM(AffinityCategory.Basic, nameof(profView.Languages), CheckEnumArrays(profView.Languages, profUser.Preference.Languages), profView.Languages.Intersect(profUser.Preference.Languages).Select(s => (int)s)));

            //BIO - DEFINIÇÕES DE BUSCA
            obj.Add(new AffinityVM(AffinityCategory.Bio, nameof(profView.Age), CheckAge(profView.Age, profUser.Preference.MinimalAge, profUser.Preference.MaxAge)));
            obj.Add(new AffinityVM(AffinityCategory.Bio, nameof(profView.Zodiac), CheckEnumZodiac(profView.Zodiac, profUser.Zodiac)));
            obj.Add(new AffinityVM(AffinityCategory.Bio, nameof(profView.RaceCategory), CheckEnumArray(profView.RaceCategory, profUser.Preference.RaceCategory)));
            obj.Add(new AffinityVM(AffinityCategory.Bio, nameof(profView.Height), CheckHeight(profView.Height, profUser.Preference.MinimalHeight, profUser.Preference.MaxHeight)));
            obj.Add(new AffinityVM(AffinityCategory.Bio, nameof(profView.BodyMass), CheckEnumArray(profView.BodyMass, profUser.Preference.BodyMass)));

            //LIFESTYLE - COMPATIBILIDADE DE PERFIL
            obj.Add(new AffinityVM(AffinityCategory.Lifestyle, nameof(profView.Smoke), CheckSmoke(profView.Smoke, profUser.Smoke)));
            obj.Add(new AffinityVM(AffinityCategory.Lifestyle, nameof(profView.Drink), CheckDrink(profView.Drink, profUser.Drink)));
            obj.Add(new AffinityVM(AffinityCategory.Lifestyle, nameof(profView.Diet), CheckDiet(profView.Diet, profUser.Diet)));
            obj.Add(new AffinityVM(AffinityCategory.Lifestyle, nameof(profView.HaveChildren), CheckHaveChildren(profView.HaveChildren, profUser.HaveChildren)));
            obj.Add(new AffinityVM(AffinityCategory.Lifestyle, nameof(profView.WantChildren), CheckWantChildren(profView.WantChildren, profUser.WantChildren)));
            obj.Add(new AffinityVM(AffinityCategory.Lifestyle, nameof(profView.Religion), CheckEnum((int?)profView.Religion, (int?)profUser.Religion)));
            obj.Add(new AffinityVM(AffinityCategory.Lifestyle, nameof(profView.EducationLevel), CheckEnum((int?)profView.EducationLevel, (int?)profUser.EducationLevel)));
            obj.Add(new AffinityVM(AffinityCategory.Lifestyle, nameof(profView.CareerCluster), CheckEnum((int?)profView.CareerCluster, (int?)profUser.CareerCluster)));

            //PERSONALITY
            obj.Add(new AffinityVM(AffinityCategory.Personality, nameof(profView.MoneyPersonality), CheckEnum((int?)profView.MoneyPersonality, (int?)profUser.MoneyPersonality, true)));
            obj.Add(new AffinityVM(AffinityCategory.Personality, nameof(profView.SplitTheBill), CheckSplitTheBill(profView.SplitTheBill, profUser.SplitTheBill)));
            obj.Add(new AffinityVM(AffinityCategory.Personality, nameof(profView.RelationshipPersonality), CheckEnumRelationshipPersonality(profView.RelationshipPersonality, profUser.RelationshipPersonality)));
            obj.Add(new AffinityVM(AffinityCategory.Personality, nameof(profView.LoveLanguage), CheckEnum((int?)profView.LoveLanguage, (int?)profUser.LoveLanguage, true)));
            obj.Add(new AffinityVM(AffinityCategory.Personality, nameof(profView.MyersBriggsTypeIndicator), CheckEnumMBTI(profView.MyersBriggsTypeIndicator, profUser.MyersBriggsTypeIndicator)));
            obj.Add(new AffinityVM(AffinityCategory.Personality, nameof(profView.SexPersonality), CheckEnumArray(profView.SexPersonality, profUser.Preference.SexPersonality, true)));

            //INTEREST - COMPATIBILIDADE DE PERFIL / UMA OPÇAO IGUAL JÁ INDICA COMPATIBILIDADE
            obj.Add(new AffinityVM(AffinityCategory.Interest, nameof(profView.Food), CheckEnumArrays(profView.Food, profUser.Food), profView.Food.Intersect(profUser.Food).Select(s => (int)s)));
            obj.Add(new AffinityVM(AffinityCategory.Interest, nameof(profView.Vacation), CheckEnumArrays(profView.Vacation, profUser.Vacation), profView.Vacation.Intersect(profUser.Vacation).Select(s => (int)s)));
            obj.Add(new AffinityVM(AffinityCategory.Interest, nameof(profView.Sports), CheckEnumArrays(profView.Sports, profUser.Sports), profView.Sports.Intersect(profUser.Sports).Select(s => (int)s)));
            obj.Add(new AffinityVM(AffinityCategory.Interest, nameof(profView.LeisureActivities), CheckEnumArrays(profView.LeisureActivities, profUser.LeisureActivities), profView.LeisureActivities.Intersect(profUser.LeisureActivities).Select(s => (int)s)));
            obj.Add(new AffinityVM(AffinityCategory.Interest, nameof(profView.MusicGenre), CheckEnumArrays(profView.MusicGenre, profUser.MusicGenre), profView.MusicGenre.Intersect(profUser.MusicGenre).Select(s => (int)s)));
            obj.Add(new AffinityVM(AffinityCategory.Interest, nameof(profView.MovieGenre), CheckEnumArrays(profView.MovieGenre, profUser.MovieGenre), profView.MovieGenre.Intersect(profUser.MovieGenre).Select(s => (int)s)));
            obj.Add(new AffinityVM(AffinityCategory.Interest, nameof(profView.TVGenre), CheckEnumArrays(profView.TVGenre, profUser.TVGenre), profView.TVGenre.Intersect(profUser.TVGenre).Select(s => (int)s)));
            obj.Add(new AffinityVM(AffinityCategory.Interest, nameof(profView.ReadingGenre), CheckEnumArrays(profView.ReadingGenre, profUser.ReadingGenre), profView.ReadingGenre.Intersect(profUser.ReadingGenre).Select(s => (int)s)));

            return obj;
        }

        private static bool CheckEnum(int? view, int? looking, bool force = false)
        {
            if (force)
            {
                if (!looking.HasValue) return false;
            }
            else
            {
                if (!looking.HasValue) return true; //If the user has not defined, then it is an affinity
            }

            return view == looking;
        }

        private static bool CheckEnumArray<T>(T? view, IEnumerable<T> looking, bool force = false) where T : struct, Enum
        {
            if (force)
            {
                if (!looking.Any()) return false;
            }
            else
            {
                if (!looking.Any()) return true; //If the user has not defined, then it is an affinity
            }

            if (view.HasValue)
                return new T[] { view.Value }.Intersect(looking).Any();
            else
                return true;
        }

        private static bool CheckEnumArrays<T>(IEnumerable<T> view, IEnumerable<T> looking) where T : System.Enum
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

        private static bool CheckHeight(Height? Height, Height? Looking_MinimalHeight, Height? Looking_MaxHeight)
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

        private static bool CheckSmoke(Smoke? view, Smoke? user)
        {
            //se um dos dois usuário não responderem, persumi-se que não tem afinidade
            if (!user.HasValue) return false;
            if (!view.HasValue) return false;

            return user switch
            {
                Smoke.No => view == Smoke.No,
                Smoke.YesOccasionally => view == Smoke.YesOccasionally || view == Smoke.YesOften,
                Smoke.YesOften => view == Smoke.YesOccasionally || view == Smoke.YesOften,
                _ => throw new System.NotImplementedException()
            };
        }

        private static bool CheckDrink(Drink? view, Drink? user)
        {
            //se um dos dois usuário não responderem, persumi-se que não tem afinidade
            if (!user.HasValue) return false;
            if (!view.HasValue) return false;

            return user switch
            {
                Drink.No => view == Drink.No || view == Drink.YesLight,
                Drink.YesLight => view == Drink.No || view == Drink.YesLight,
                Drink.YesModerate => view == Drink.YesModerate || view == Drink.YesHeavy,
                Drink.YesHeavy => view == Drink.YesModerate || view == Drink.YesHeavy,
                _ => throw new System.NotImplementedException()
            };
        }

        private static bool CheckDiet(Diet? view, Diet? user)
        {
            //se um dos dois usuário não responderem, persumi-se que não tem afinidade
            if (!user.HasValue) return false;
            if (!view.HasValue) return false;

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

        private static bool CheckHaveChildren(HaveChildren? view, HaveChildren? user)
        {
            //se um dos dois usuário não responderem, persumi-se que não tem afinidade
            if (!user.HasValue) return false;
            if (!view.HasValue) return false;

            return user switch
            {
                HaveChildren.No => view == HaveChildren.No || view == HaveChildren.YesNo,
                HaveChildren.YesNo => view == HaveChildren.No || view == HaveChildren.YesNo,
                HaveChildren.Yes => view == HaveChildren.Yes,
                _ => throw new System.NotImplementedException()
            };
        }

        private static bool CheckWantChildren(WantChildren? view, WantChildren? user)
        {
            //se um dos dois usuário não responderem, persumi-se que não tem afinidade
            if (!user.HasValue) return false;
            if (!view.HasValue) return false;

            return user switch
            {
                WantChildren.No => view == WantChildren.No,
                WantChildren.Maybe => view == WantChildren.Maybe || view == WantChildren.Yes,
                WantChildren.Yes => view == WantChildren.Maybe || view == WantChildren.Yes,
                _ => throw new System.NotImplementedException()
            };
        }

        private static bool CheckSplitTheBill(SplitTheBill? view, SplitTheBill? user)
        {
            //invented by me (dhiogo)

            //se um dos dois usuário não responderem, persumi-se que não tem afinidade
            if (!user.HasValue) return false;
            if (!view.HasValue) return false;

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

        private static bool CheckEnumRelationshipPersonality(RelationshipPersonality? view, RelationshipPersonality? user)
        {
            //https://helenfisher.com/downloads/articles/Article_%20We%20Have%20Chemistry.pdf

            //se um dos dois usuário não responderem, persumi-se que não tem afinidade
            if (!user.HasValue) return false;
            if (!view.HasValue) return false;

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