using System.Collections.Generic;
using System.Linq;
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
            if (profUser.Looking == null) throw new NotificationException("Não foi possível identificar seu perfil de busca");
            if (profView.Looking == null) throw new NotificationException("Não foi possível identificar o perfil de busca deste usuário");

            var obj = new List<AffinityVM>();

            //BASIC
            obj.Add(new AffinityVM(AffinityCategory.Basic, nameof(profView.Basic.BiologicalSex), CheckEnum((int)profView.Basic.BiologicalSex, (int?)profUser.Looking.BiologicalSex)));
            obj.Add(new AffinityVM(AffinityCategory.Basic, nameof(profView.Basic.MaritalStatus), CheckEnum((int)profView.Basic.MaritalStatus, (int?)profUser.Looking.MaritalStatus)));
            obj.Add(new AffinityVM(AffinityCategory.Basic, nameof(profView.Basic.Intent), CheckEnumArray(profView.Basic.Intent, profUser.Looking.Intent), profView.Basic.Intent.Intersect(profUser.Looking.Intent).Select(s => (int)s)));
            obj.Add(new AffinityVM(AffinityCategory.Basic, nameof(profView.Basic.GenderIdentity), CheckEnum((int)profView.Basic.GenderIdentity, (int?)profUser.Looking.GenderIdentity)));
            obj.Add(new AffinityVM(AffinityCategory.Basic, nameof(profView.Basic.SexualOrientation), CheckEnum((int)profView.Basic.SexualOrientation, (int?)profUser.Looking.SexualOrientation)));
            obj.Add(new AffinityVM(AffinityCategory.Basic, nameof(profView.Distance), profView.Distance <= profUser.Looking.Distance));
            obj.Add(new AffinityVM(AffinityCategory.Basic, nameof(profView.Basic.Languages), CheckEnumArray(profView.Basic.Languages, profUser.Looking.Languages), profView.Basic.Languages.Intersect(profUser.Looking.Languages).Select(s => (int)s)));

            //BIO
            obj.Add(new AffinityVM(AffinityCategory.Bio, nameof(profView.Age), CheckAge(profView.Age, profUser.Looking.MinimalAge, profUser.Looking.MaxAge)));
            obj.Add(new AffinityVM(AffinityCategory.Bio, nameof(profView.Bio.Zodiac), CheckEnumZodiac(profView.Bio.Zodiac, profUser.Bio.Zodiac)));
            obj.Add(new AffinityVM(AffinityCategory.Bio, nameof(profView.Bio.RaceCategory), CheckEnum((int)profView.Bio.RaceCategory, (int?)profUser.Looking.RaceCategory)));
            obj.Add(new AffinityVM(AffinityCategory.Bio, nameof(profView.Bio.Height), CheckHeight(profView.Bio.Height, profUser.Looking.MinimalHeight, profUser.Looking.MaxHeight)));
            obj.Add(new AffinityVM(AffinityCategory.Bio, nameof(profView.Bio.BodyMass), CheckEnum((int)profView.Bio.BodyMass, (int?)profUser.Looking.BodyMass)));

            if (profView.Basic.Intent.IsLongTerm())
            {
                //LIFESTYLE (compatibilidade independe das definições de busca)
                obj.Add(new AffinityVM(AffinityCategory.Lifestyle, nameof(profView.Lifestyle.Smoke), CheckEnum((int)profView.Lifestyle.Smoke, (int?)profUser.Lifestyle.Smoke)));
                obj.Add(new AffinityVM(AffinityCategory.Lifestyle, nameof(profView.Lifestyle.Drink), CheckEnum((int)profView.Lifestyle.Drink, (int?)profUser.Lifestyle.Drink)));
                obj.Add(new AffinityVM(AffinityCategory.Lifestyle, nameof(profView.Lifestyle.Diet), CheckEnum((int)profView.Lifestyle.Diet, (int?)profUser.Lifestyle.Diet)));
                obj.Add(new AffinityVM(AffinityCategory.Lifestyle, nameof(profView.Lifestyle.HaveChildren), CheckEnum((int)profView.Lifestyle.HaveChildren.Value, (int?)profUser.Lifestyle.HaveChildren)));
                obj.Add(new AffinityVM(AffinityCategory.Lifestyle, nameof(profView.Lifestyle.WantChildren), CheckEnum((int)profView.Lifestyle.WantChildren.Value, (int?)profUser.Lifestyle.WantChildren)));
                obj.Add(new AffinityVM(AffinityCategory.Lifestyle, nameof(profView.Lifestyle.Religion), CheckEnum((int)profView.Lifestyle.Religion.Value, (int?)profUser.Lifestyle.Religion)));
                obj.Add(new AffinityVM(AffinityCategory.Lifestyle, nameof(profView.Lifestyle.EducationLevel), CheckEnum((int)profView.Lifestyle.EducationLevel.Value, (int?)profUser.Lifestyle.EducationLevel)));
                obj.Add(new AffinityVM(AffinityCategory.Lifestyle, nameof(profView.Lifestyle.CareerCluster), CheckEnumCareer(profView.Lifestyle.CareerCluster.Value, profUser.Lifestyle.CareerCluster.Value)));
                obj.Add(new AffinityVM(AffinityCategory.Lifestyle, nameof(profView.Lifestyle.MoneyPersonality), CheckMoneyPersonality(profView.Lifestyle.MoneyPersonality.Value, profUser.Lifestyle.MoneyPersonality.Value)));
                obj.Add(new AffinityVM(AffinityCategory.Lifestyle, nameof(profView.Lifestyle.MyersBriggsTypeIndicator), CheckEnumMBTI(profView.Lifestyle.MyersBriggsTypeIndicator, profUser.Lifestyle.MyersBriggsTypeIndicator)));
                obj.Add(new AffinityVM(AffinityCategory.Lifestyle, nameof(profView.Lifestyle.RelationshipPersonality), CheckEnumRelationshipPersonality(profView.Lifestyle.RelationshipPersonality.Value, profUser.Lifestyle.RelationshipPersonality.Value)));

                //INTEREST (com uma opção de cada categoria já indica compatibilidade)
                obj.Add(new AffinityVM(AffinityCategory.Interest, nameof(profView.Interest.Food), CheckEnumArray(profView.Interest.Food, profUser.Interest.Food), profView.Interest.Food.Intersect(profUser.Interest.Food).Select(s => (int)s)));
                obj.Add(new AffinityVM(AffinityCategory.Interest, nameof(profView.Interest.Holidays), CheckEnumArray(profView.Interest.Holidays, profUser.Interest.Holidays), profView.Interest.Holidays.Intersect(profUser.Interest.Holidays).Select(s => (int)s)));
                obj.Add(new AffinityVM(AffinityCategory.Interest, nameof(profView.Interest.Sports), CheckEnumArray(profView.Interest.Sports, profUser.Interest.Sports), profView.Interest.Sports.Intersect(profUser.Interest.Sports).Select(s => (int)s)));
                obj.Add(new AffinityVM(AffinityCategory.Interest, nameof(profView.Interest.LeisureActivities), CheckEnumArray(profView.Interest.LeisureActivities, profUser.Interest.LeisureActivities), profView.Interest.LeisureActivities.Intersect(profUser.Interest.LeisureActivities).Select(s => (int)s)));
                obj.Add(new AffinityVM(AffinityCategory.Interest, nameof(profView.Interest.MusicGenre), CheckEnumArray(profView.Interest.MusicGenre, profUser.Interest.MusicGenre), profView.Interest.MusicGenre.Intersect(profUser.Interest.MusicGenre).Select(s => (int)s)));
                obj.Add(new AffinityVM(AffinityCategory.Interest, nameof(profView.Interest.MovieGenre), CheckEnumArray(profView.Interest.MovieGenre, profUser.Interest.MovieGenre), profView.Interest.MovieGenre.Intersect(profUser.Interest.MovieGenre).Select(s => (int)s)));
                obj.Add(new AffinityVM(AffinityCategory.Interest, nameof(profView.Interest.TVGenre), CheckEnumArray(profView.Interest.TVGenre, profUser.Interest.TVGenre), profView.Interest.TVGenre.Intersect(profUser.Interest.TVGenre).Select(s => (int)s)));
                obj.Add(new AffinityVM(AffinityCategory.Interest, nameof(profView.Interest.ReadingGenre), CheckEnumArray(profView.Interest.ReadingGenre, profUser.Interest.ReadingGenre), profView.Interest.ReadingGenre.Intersect(profUser.Interest.ReadingGenre).Select(s => (int)s)));
            }

            return obj;
        }

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
                _ => false,
            };
        }

        private static bool CheckMoneyPersonality(MoneyPersonality view, MoneyPersonality user)
        {
            return user switch
            {
                MoneyPersonality.BigSpender => view == MoneyPersonality.BigSpender,
                MoneyPersonality.Avoider => view == MoneyPersonality.Avoider,
                MoneyPersonality.Saver => view == MoneyPersonality.Saver || view == MoneyPersonality.Investor,
                MoneyPersonality.Investor => view == MoneyPersonality.Saver || view == MoneyPersonality.Investor,
                _ => false,
            };
        }

        private static bool CheckEnumCareer(CareerCluster view, CareerCluster user)
        {
            return view.GetGroup() == user.GetGroup();
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

        private static bool CheckEnum(int view, int? looking)
        {
            if (!looking.HasValue) return true; //If the user has not defined, then it is an affinity

            return view == looking;
        }

        private static bool CheckEnumArray<T>(IEnumerable<T> view, IEnumerable<T> looking) where T : System.Enum
        {
            if (!looking.Any()) return true; //If the user has not defined, then it is an affinity

            return view.Intersect(looking).Any();
        }

        private static bool CheckEnumRelationshipPersonality(RelationshipPersonality view, RelationshipPersonality user)
        {
            return user switch
            {
                RelationshipPersonality.Explorers => view == RelationshipPersonality.Explorers,
                RelationshipPersonality.Directors => view == RelationshipPersonality.Negotiator,
                RelationshipPersonality.Builders => view == RelationshipPersonality.Builders,
                RelationshipPersonality.Negotiator => view == RelationshipPersonality.Directors,
                _ => false,
            };
        }

        private static bool CheckEnumMBTI(MyersBriggsTypeIndicator? view, MyersBriggsTypeIndicator? user)
        {
            //http://www.personalityrelationships.net/

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
                _ => false,
            };
        }
    }
}