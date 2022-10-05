using VerusDate.Shared.Enum;
using VerusDate.Shared.Helper;
using VerusDate.Shared.Model;

namespace VerusDate.Web.Core
{
    public static class SmartLookingCore
    {
        public static void PopulateFields(ProfileModel? profile, ProfilePreferenceModel? preference)
        {
            if (profile == null) throw new NotificationException("Preenchimento de cadastro do perfil não encontrado");
            preference ??= new ProfilePreferenceModel();

            //BASIC
            preference.Region = Region.City;
            preference.Languages = profile.Languages;
            preference.CurrentSituation = AffinityCore.GetCurrentSituation(profile);
            //looking.Intent = profile.Basic.Intent; //selecionado ao carregar a tela
            preference.BiologicalSex = AffinityCore.GetBiologicalSex(profile);
            //looking.GenderIdentity = null;
            preference.SexualOrientation = AffinityCore.GetSexualOrientation(profile);

            //BIO
            var ages = AffinityCore.GetAge(profile, preference, true);
            preference.MinimalAge = ages[0];
            preference.MaxAge = ages[1];
            var heights = AffinityCore.GetHeight(profile, preference, true);
            preference.MinimalHeight = heights[0];
            preference.MaxHeight = heights[1];
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
            //preference.TravelFrequency = AffinityCore.GetTravelFrequency(profile, preference);
        }
    }
}