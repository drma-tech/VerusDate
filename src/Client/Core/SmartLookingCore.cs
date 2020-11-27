using System.Linq;
using VerusDate.Shared.Enum;
using VerusDate.Shared.Helper;
using VerusDate.Shared.ViewModel;

namespace VerusDate.Client.Core
{
    public static class SmartLookingCore
    {
        public static void PopulateFields(ProfileVM profile, ProfileLookingVM looking)
        {
            if (profile == null) throw new NotificationException("Preenchimento de cadastro do perfil não encontrado");
            if (looking == null) looking = new ProfileLookingVM();

            looking.Distance = 20;
            looking.MaritalStatus = GetMaritalStatus(profile);
            looking.Intent = profile.Intent;
            looking.BiologicalSex = GetBiologicalSex(profile);
            //looking.GenderIdentity = null;
            looking.SexualOrientation = GetSexualOrientation(profile);
            looking.MinimalAge = GetMinAge(profile);
            looking.MaxAge = GetMaxAge(profile);
            looking.MinimalHeight = GetMinHeight(profile);
            looking.MaxHeight = GetMaxHeight(profile);
            //looking.BodyMass = null;
            //looking.HairColor = null;
            //looking.EyeColor = null;
            //looking.RaceCategory = null;
            //looking.EducationLevel = null;
            //looking.HaveChildren = null;
            looking.WantChildren = GetWantChildren(profile);
            //looking.Drink = null;
            //looking.Smoke = null;
            //looking.CareerCluster = null;
            //looking.Religion = null;
            //looking.MoneyPersonality = GetMoneyPersonality(profile);
            //looking.MyersBriggsTypeIndicator = GetMyersBriggsTypeIndicator(profile);
            //looking.RelationshipPersonality = GetRelationshipPersonality(profile);
        }

        private static int GetAgeDifference(int CurrentAge)
        {
            if (CurrentAge <= 25)
                return 3;
            if (CurrentAge <= 30)
                return 5;
            else if (CurrentAge <= 40)
                return 7;
            else if (CurrentAge <= 50)
                return 10;
            else
                return 15;
        }

        private static int GetMinAge(ProfileVM profile)
        {
            var minAge = profile.BirthDate.GetAge() - GetAgeDifference(profile.BirthDate.GetAge());
            if (minAge < 18) minAge = 18;
            return minAge;
        }

        private static int GetMaxAge(ProfileVM profile)
        {
            var maxAge = profile.BirthDate.GetAge() + GetAgeDifference(profile.BirthDate.GetAge());
            if (maxAge > 120) maxAge = 120;
            return maxAge;
        }

        private static MaritalStatus? GetMaritalStatus(ProfileVM profile)
        {
            if (!profile.IsLongTerm()) //short-term
            {
                return null;
            }
            else //long-term
            {
                if (profile.MaritalStatus == MaritalStatus.Polyamorous) return null;
                else if (profile.MaritalStatus == MaritalStatus.Monogamous) return null;
                else return MaritalStatus.Single;
            }
        }

        private static BiologicalSex? GetBiologicalSex(ProfileVM profile)
        {
            if (profile.GenderIdentity == GenderIdentity.Cisgender) //binary
            {
                if (profile.SexualOrientation == SexualOrientation.Heteressexual)
                {
                    if (profile.BiologicalSex == BiologicalSex.Female) return BiologicalSex.Male;
                    else if (profile.BiologicalSex == BiologicalSex.Male) return BiologicalSex.Female;
                    else return null;
                }
                else if (profile.SexualOrientation == SexualOrientation.Homossexual)
                {
                    if (profile.BiologicalSex == BiologicalSex.Female) return BiologicalSex.Female;
                    else if (profile.BiologicalSex == BiologicalSex.Male) return BiologicalSex.Male;
                    else return null;
                }
                else
                {
                    return null;
                }
            }
            else //non-binary
            {
                return null;
            }
        }

        private static SexualOrientation? GetSexualOrientation(ProfileVM profile)
        {
            if (profile.SexualOrientation == SexualOrientation.Heteressexual) return SexualOrientation.Heteressexual;
            else if (profile.SexualOrientation == SexualOrientation.Homossexual) return SexualOrientation.Homossexual;
            else return null;
        }

        private static Height GetMinHeight(ProfileVM profile)
        {
            var list = EnumHelper.GetList(typeof(Height));

            var minHeight = (int)profile.Height - 15;
            if (!list.Any(a => a.Value == minHeight)) minHeight = (int)profile.Height - 16;
            if (!list.Any(a => a.Value == minHeight)) minHeight = (int)profile.Height - 17;
            if ((Height)minHeight < Height._150) minHeight = (int)Height._150;
            return (Height)minHeight;
        }

        private static Height GetMaxHeight(ProfileVM profile)
        {
            var list = EnumHelper.GetList(typeof(Height));

            var maxHeight = (int)profile.Height + 15;
            if (!list.Any(a => a.Value == maxHeight)) maxHeight = (int)profile.Height + 16;
            if (!list.Any(a => a.Value == maxHeight)) maxHeight = (int)profile.Height + 17;
            if ((Height)maxHeight > Height._192) maxHeight = (int)Height._192;
            return (Height)maxHeight;
        }

        private static WantChildren? GetWantChildren(ProfileVM profile)
        {
            if (profile.WantChildren == WantChildren.No)
                return WantChildren.No;
            else
                return null;
        }

        private static MoneyPersonality? GetMoneyPersonality(ProfileVM profile)
        {
            return null;
        }

        private static MyersBriggsTypeIndicator? GetMyersBriggsTypeIndicator(ProfileVM profile)
        {
            return null;
        }

        private static RelationshipPersonality? GetRelationshipPersonality(ProfileVM profile)
        {
            if (profile.RelationshipPersonality == RelationshipPersonality.Explorers)
                return RelationshipPersonality.Explorers;
            else if (profile.RelationshipPersonality == RelationshipPersonality.Directors)
                return RelationshipPersonality.Negotiator;
            else if (profile.RelationshipPersonality == RelationshipPersonality.Negotiator)
                return RelationshipPersonality.Directors;
            else
                return RelationshipPersonality.Builders;
        }
    }
}