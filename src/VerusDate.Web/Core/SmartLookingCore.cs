using VerusDate.Shared.Enum;
using VerusDate.Shared.Helper;
using VerusDate.Shared.Model;

namespace VerusDate.Web.Core
{
    public static class SmartLookingCore
    {
        public static void PopulateFields(ProfileModel profile, ProfilePreferenceModel preference)
        {
            if (profile == null) throw new NotificationException("Preenchimento de cadastro do perfil não encontrado");
            if (preference == null) preference = new ProfilePreferenceModel();

            //BASIC
            preference.Region = Region.City;
            preference.Languages = profile.Languages;
            preference.CurrentSituation = GetCurrentSituation(profile);
            //looking.Intent = profile.Basic.Intent; //selecionado ao carregar a tela
            preference.BiologicalSex = GetBiologicalSex(profile);
            //looking.GenderIdentity = null;
            preference.SexualOrientation = GetSexualOrientation(profile);

            //BIO
            preference.MinimalAge = GetMinAge(profile);
            preference.MaxAge = GetMaxAge(profile);
            preference.MinimalHeight = GetMinHeight(profile);
            preference.MaxHeight = GetMaxHeight(profile);
            //looking.RaceCategory = null;
            //looking.BodyMass = null;

            //LIFESTYLE
            //preference.Drink = GetDrink(profile);
            //preference.Smoke = GetSmoke(profile);
            //preference.Diet = GetDiet(profile);
            //preference.Religion = GetReligion(profile);

            //preference.HaveChildren = GetHaveChildren(profile);
            //preference.WantChildren = GetWantChildren(profile);
            //preference.EducationLevel = GetEducationLevel(profile);
            //preference.CareerCluster = GetCareerCluster(profile);
            //preference.TravelFrequency = GetTravelFrequency(profile);
        }

        private static int GetAgeDifference(int CurrentAge)
        {
            if (CurrentAge <= 25)
                return 3;
            if (CurrentAge <= 30)
                return 4;
            if (CurrentAge <= 35)
                return 5;
            else if (CurrentAge <= 40)
                return 7;
            else if (CurrentAge <= 50)
                return 10;
            else
                return 15;
        }

        private static int GetMinAge(ProfileModel profile)
        {
            var minAge = profile.BirthDate.GetAge() - GetAgeDifference(profile.BirthDate.GetAge());
            if (minAge < 18) minAge = 18;
            return minAge;
        }

        private static int GetMaxAge(ProfileModel profile)
        {
            var maxAge = profile.BirthDate.GetAge() + GetAgeDifference(profile.BirthDate.GetAge());
            if (maxAge > 120) maxAge = 120;
            return maxAge;
        }

        private static IReadOnlyList<CurrentSituation> GetCurrentSituation(ProfileModel profile)
        {
            return profile.CurrentSituation switch
            {
                CurrentSituation.Single => new CurrentSituation[] { CurrentSituation.Single },
                _ => Array.Empty<CurrentSituation>()
            };
        }

        private static IReadOnlyList<BiologicalSex> GetBiologicalSex(ProfileModel profile)
        {
            if (profile.GenderIdentity == GenderIdentity.Cisgender) //BINARY
            {
                if (profile.SexualOrientation == SexualOrientation.Heterosexual)
                {
                    if (profile.BiologicalSex == BiologicalSex.Female) return new BiologicalSex[] { BiologicalSex.Male };
                    else if (profile.BiologicalSex == BiologicalSex.Male) return new BiologicalSex[] { BiologicalSex.Female };
                    else return Array.Empty<BiologicalSex>();
                }
                else if (profile.SexualOrientation == SexualOrientation.Homosexual)
                {
                    if (profile.BiologicalSex == BiologicalSex.Female) return new BiologicalSex[] { BiologicalSex.Female };
                    else if (profile.BiologicalSex == BiologicalSex.Male) return new BiologicalSex[] { BiologicalSex.Male };
                    else return Array.Empty<BiologicalSex>();
                }
                else
                {
                    return Array.Empty<BiologicalSex>();
                }
            }
            else //NON-BINARY
            {
                return Array.Empty<BiologicalSex>();
            }
        }

        private static IReadOnlyList<SexualOrientation> GetSexualOrientation(ProfileModel profile)
        {
            return profile.SexualOrientation switch
            {
                SexualOrientation.Heterosexual => new SexualOrientation[] { SexualOrientation.Heterosexual },
                SexualOrientation.Homosexual => new SexualOrientation[] { SexualOrientation.Homosexual },
                _ => Array.Empty<SexualOrientation>()
            };
        }

        private static Height GetMinHeight(ProfileModel profile)
        {
            var list = EnumHelper.GetList<Height>();

            var minHeight = (int)profile.Height.Value - 15;
            if (!list.Any(a => a.Value == minHeight)) minHeight = (int)profile.Height.Value - 16;
            if (!list.Any(a => a.Value == minHeight)) minHeight = (int)profile.Height.Value - 17;
            if ((Height)minHeight < Height._150) minHeight = (int)Height._150;
            return (Height)minHeight;
        }

        private static Height GetMaxHeight(ProfileModel profile)
        {
            var list = EnumHelper.GetList<Height>();

            var maxHeight = (int)profile.Height.Value + 15;
            if (!list.Any(a => a.Value == maxHeight)) maxHeight = (int)profile.Height.Value + 16;
            if (!list.Any(a => a.Value == maxHeight)) maxHeight = (int)profile.Height.Value + 17;
            if ((Height)maxHeight > Height._192) maxHeight = (int)Height._192;
            return (Height)maxHeight;
        }

        private static IReadOnlyList<Drink> GetDrink(ProfileModel profile)
        {
            return profile.Drink switch
            {
                Drink.No => new Drink[] { Drink.No, Drink.YesLight },
                Drink.YesLight => new Drink[] { Drink.No, Drink.YesLight },
                Drink.YesModerate => new Drink[] { Drink.YesModerate, Drink.YesHeavy },
                Drink.YesHeavy => new Drink[] { Drink.YesModerate, Drink.YesHeavy },
                _ => Array.Empty<Drink>()
            };
        }

        private static IReadOnlyList<Smoke> GetSmoke(ProfileModel profile)
        {
            return profile.Smoke switch
            {
                Smoke.No => new Smoke[] { Smoke.No },
                Smoke.YesOccasionally => new Smoke[] { Smoke.YesOccasionally, Smoke.YesOften },
                Smoke.YesOften => new Smoke[] { Smoke.YesOccasionally, Smoke.YesOften },
                _ => Array.Empty<Smoke>()
            };
        }

        private static IReadOnlyList<Diet> GetDiet(ProfileModel profile)
        {
            var group01 = new Diet[] { Diet.Omnivore, Diet.Flexitarian, Diet.GlutenFree };
            var group02 = new Diet[] { Diet.Vegetarian, Diet.Vegan };
            var group03 = new Diet[] { Diet.RawFood, Diet.OrganicAllnaturalLocal };

            return profile.Diet switch
            {
                Diet.Omnivore => group01,
                Diet.Flexitarian => group01,
                Diet.Vegetarian => group02,
                Diet.Vegan => group02,
                Diet.RawFood => group03,
                Diet.GlutenFree => group01,
                Diet.OrganicAllnaturalLocal => group03,
                Diet.DetoxWeightLoss => new Diet[] { Diet.DetoxWeightLoss },
                _ => Array.Empty<Diet>()
            };
        }

        private static IReadOnlyList<Religion> GetReligion(ProfileModel profile)
        {
            return new Religion[] { profile.Religion.Value };
        }

        private static IReadOnlyList<HaveChildren> GetHaveChildren(ProfileModel profile)
        {
            return profile.HaveChildren switch
            {
                HaveChildren.No => new HaveChildren[] { HaveChildren.No, HaveChildren.YesNo },
                HaveChildren.YesNo => new HaveChildren[] { HaveChildren.No, HaveChildren.YesNo },
                HaveChildren.Yes => new HaveChildren[] { HaveChildren.Yes },
                _ => Array.Empty<HaveChildren>()
            };
        }

        private static IReadOnlyList<WantChildren> GetWantChildren(ProfileModel profile)
        {
            return profile.WantChildren switch
            {
                WantChildren.No => new WantChildren[] { WantChildren.No },
                WantChildren.Maybe => new WantChildren[] { WantChildren.Maybe, WantChildren.Yes },
                WantChildren.Yes => new WantChildren[] { WantChildren.Maybe, WantChildren.Yes },
                _ => Array.Empty<WantChildren>()
            };
        }

        private static IReadOnlyList<EducationLevel> GetEducationLevel(ProfileModel profile)
        {
            return new EducationLevel[] { profile.EducationLevel.Value };
        }

        private static IReadOnlyList<CareerCluster> GetCareerCluster(ProfileModel profile)
        {
            return new CareerCluster[] { profile.CareerCluster.Value };
        }

        private static IReadOnlyList<TravelFrequency> GetTravelFrequency(ProfileModel profile)
        {
            return profile.TravelFrequency switch
            {
                TravelFrequency.NeverRarely => new TravelFrequency[] { TravelFrequency.NeverRarely, TravelFrequency.SometimesFrequently },
                TravelFrequency.SometimesFrequently => new TravelFrequency[] { TravelFrequency.NeverRarely, TravelFrequency.SometimesFrequently, TravelFrequency.UsuallyAlwaysNomad },
                TravelFrequency.UsuallyAlwaysNomad => new TravelFrequency[] { TravelFrequency.SometimesFrequently, TravelFrequency.UsuallyAlwaysNomad },
                _ => Array.Empty<TravelFrequency>()
            };
        }

        //private static MoneyPersonality? GetMoneyPersonality(ProfileModel profile)
        //{
        //    return null;
        //}

        //private static MyersBriggsTypeIndicator? GetMyersBriggsTypeIndicator(ProfileModel profile)
        //{
        //    return null;
        //}

        //private static RelationshipPersonality? GetRelationshipPersonality(ProfileModel profile)
        //{
        //    if (profile.RelationshipPersonality == RelationshipPersonality.Explorers)
        //        return RelationshipPersonality.Explorers;
        //    else if (profile.RelationshipPersonality == RelationshipPersonality.Directors)
        //        return RelationshipPersonality.Negotiator;
        //    else if (profile.RelationshipPersonality == RelationshipPersonality.Negotiator)
        //        return RelationshipPersonality.Directors;
        //    else
        //        return RelationshipPersonality.Builders;
        //}
    }
}