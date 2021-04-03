using System;
using System.Collections.Generic;
using System.Linq;
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

            preference.Distance = Distance._20;
            preference.Languages = profile.Basic.Languages;
            preference.CurrentSituation = GetCurrentSituation(profile);
            //looking.Intent = profile.Basic.Intent; //selecionado ao carregar a tela
            preference.BiologicalSex = GetBiologicalSex(profile);
            //looking.GenderIdentity = null;
            preference.SexualOrientation = GetSexualOrientation(profile);
            preference.MinimalAge = GetMinAge(profile);
            preference.MaxAge = GetMaxAge(profile);
            preference.MinimalHeight = GetMinHeight(profile);
            preference.MaxHeight = GetMaxHeight(profile);
            //looking.RaceCategory = null;
            //looking.BodyMass = null;
        }

        private static int GetAgeDifference(int CurrentAge)
        {
            if (CurrentAge <= 25)
                return 5;
            if (CurrentAge <= 30)
                return 7;
            else if (CurrentAge <= 40)
                return 10;
            else if (CurrentAge <= 50)
                return 15;
            else
                return 25;
        }

        private static int GetMinAge(ProfileModel profile)
        {
            var minAge = profile.Bio.BirthDate.GetAge() - GetAgeDifference(profile.Bio.BirthDate.GetAge());
            if (minAge < 18) minAge = 18;
            return minAge;
        }

        private static int GetMaxAge(ProfileModel profile)
        {
            var maxAge = profile.Bio.BirthDate.GetAge() + GetAgeDifference(profile.Bio.BirthDate.GetAge());
            if (maxAge > 120) maxAge = 120;
            return maxAge;
        }

        private static IReadOnlyList<CurrentSituation> GetCurrentSituation(ProfileModel profile)
        {
            if (profile.Basic.Intent.IsLongTerm())
            {
                return profile.Basic.CurrentSituation switch
                {
                    CurrentSituation.Single => new CurrentSituation[] { CurrentSituation.Single },
                    CurrentSituation.Monogamous => new CurrentSituation[] { CurrentSituation.Monogamous },
                    _ => Array.Empty<CurrentSituation>(),
                };
            }
            else
            {
                return Array.Empty<CurrentSituation>();
            }
        }

        private static IReadOnlyList<BiologicalSex> GetBiologicalSex(ProfileModel profile)
        {
            if (profile.Basic.GenderIdentity == GenderIdentity.Cisgender) //BINARY
            {
                if (profile.Basic.SexualOrientation == SexualOrientation.Heteressexual)
                {
                    if (profile.Basic.BiologicalSex == BiologicalSex.Female) return new BiologicalSex[] { BiologicalSex.Male };
                    else if (profile.Basic.BiologicalSex == BiologicalSex.Male) return new BiologicalSex[] { BiologicalSex.Female };
                    else return Array.Empty<BiologicalSex>();
                }
                else if (profile.Basic.SexualOrientation == SexualOrientation.Homossexual)
                {
                    if (profile.Basic.BiologicalSex == BiologicalSex.Female) return new BiologicalSex[] { BiologicalSex.Female };
                    else if (profile.Basic.BiologicalSex == BiologicalSex.Male) return new BiologicalSex[] { BiologicalSex.Male };
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
            return profile.Basic.SexualOrientation switch
            {
                SexualOrientation.Heteressexual => new SexualOrientation[] { SexualOrientation.Heteressexual },
                SexualOrientation.Homossexual => new SexualOrientation[] { SexualOrientation.Homossexual },
                _ => Array.Empty<SexualOrientation>(),
            };
        }

        private static Height GetMinHeight(ProfileModel profile)
        {
            var list = EnumHelper.GetList(typeof(Height));

            var minHeight = (int)profile.Bio.Height - 15;
            if (!list.Any(a => a.Value == minHeight)) minHeight = (int)profile.Bio.Height - 16;
            if (!list.Any(a => a.Value == minHeight)) minHeight = (int)profile.Bio.Height - 17;
            if ((Height)minHeight < Height._150) minHeight = (int)Height._150;
            return (Height)minHeight;
        }

        private static Height GetMaxHeight(ProfileModel profile)
        {
            var list = EnumHelper.GetList(typeof(Height));

            var maxHeight = (int)profile.Bio.Height + 15;
            if (!list.Any(a => a.Value == maxHeight)) maxHeight = (int)profile.Bio.Height + 16;
            if (!list.Any(a => a.Value == maxHeight)) maxHeight = (int)profile.Bio.Height + 17;
            if ((Height)maxHeight > Height._192) maxHeight = (int)Height._192;
            return (Height)maxHeight;
        }

        private static WantChildren? GetWantChildren(ProfileModel profile)
        {
            if (profile.Lifestyle.WantChildren == WantChildren.No)
                return WantChildren.No;
            else
                return null;
        }

        private static MoneyPersonality? GetMoneyPersonality(ProfileModel profile)
        {
            return null;
        }

        private static MyersBriggsTypeIndicator? GetMyersBriggsTypeIndicator(ProfileModel profile)
        {
            return null;
        }

        private static RelationshipPersonality? GetRelationshipPersonality(ProfileModel profile)
        {
            if (profile.Lifestyle.RelationshipPersonality == RelationshipPersonality.Explorers)
                return RelationshipPersonality.Explorers;
            else if (profile.Lifestyle.RelationshipPersonality == RelationshipPersonality.Directors)
                return RelationshipPersonality.Negotiator;
            else if (profile.Lifestyle.RelationshipPersonality == RelationshipPersonality.Negotiator)
                return RelationshipPersonality.Directors;
            else
                return RelationshipPersonality.Builders;
        }
    }
}