﻿using System.Linq;
using VerusDate.Shared.Enum;
using VerusDate.Shared.Helper;
using VerusDate.Shared.Model;
using VerusDate.Shared.Model.Profile;

namespace VerusDate.Web.Core
{
    public static class SmartLookingCore
    {
        public static void PopulateFields(Profile profile, ProfileLooking looking)
        {
            if (profile == null) throw new NotificationException("Preenchimento de cadastro do perfil não encontrado");
            if (looking == null) looking = new ProfileLooking();

            looking.Distance = 20;
            looking.MaritalStatus = GetMaritalStatus(profile);
            looking.Intent = profile.Basic.Intent;
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

        private static int GetMinAge(Profile profile)
        {
            var minAge = profile.Bio.BirthDate.GetAge() - GetAgeDifference(profile.Bio.BirthDate.GetAge());
            if (minAge < 18) minAge = 18;
            return minAge;
        }

        private static int GetMaxAge(Profile profile)
        {
            var maxAge = profile.Bio.BirthDate.GetAge() + GetAgeDifference(profile.Bio.BirthDate.GetAge());
            if (maxAge > 120) maxAge = 120;
            return maxAge;
        }

        private static MaritalStatus? GetMaritalStatus(Profile profile)
        {
            if (profile.Basic.Intent.IsLongTerm())
            {
                if (profile.Basic.MaritalStatus == MaritalStatus.Polyamorous) return null;
                else if (profile.Basic.MaritalStatus == MaritalStatus.Monogamous) return null;
                else return MaritalStatus.Single;
            }
            else
            {
                return null;
            }
        }

        private static BiologicalSex? GetBiologicalSex(Profile profile)
        {
            if (profile.Basic.GenderIdentity == GenderIdentity.Cisgender) //binary
            {
                if (profile.Basic.SexualOrientation == SexualOrientation.Heteressexual)
                {
                    if (profile.Basic.BiologicalSex == BiologicalSex.Female) return BiologicalSex.Male;
                    else if (profile.Basic.BiologicalSex == BiologicalSex.Male) return BiologicalSex.Female;
                    else return null;
                }
                else if (profile.Basic.SexualOrientation == SexualOrientation.Homossexual)
                {
                    if (profile.Basic.BiologicalSex == BiologicalSex.Female) return BiologicalSex.Female;
                    else if (profile.Basic.BiologicalSex == BiologicalSex.Male) return BiologicalSex.Male;
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

        private static SexualOrientation? GetSexualOrientation(Profile profile)
        {
            if (profile.Basic.SexualOrientation == SexualOrientation.Heteressexual) return SexualOrientation.Heteressexual;
            else if (profile.Basic.SexualOrientation == SexualOrientation.Homossexual) return SexualOrientation.Homossexual;
            else return null;
        }

        private static Height GetMinHeight(Profile profile)
        {
            var list = EnumHelper.GetList(typeof(Height));

            var minHeight = (int)profile.Bio.Height - 15;
            if (!list.Any(a => a.Value == minHeight)) minHeight = (int)profile.Bio.Height - 16;
            if (!list.Any(a => a.Value == minHeight)) minHeight = (int)profile.Bio.Height - 17;
            if ((Height)minHeight < Height._150) minHeight = (int)Height._150;
            return (Height)minHeight;
        }

        private static Height GetMaxHeight(Profile profile)
        {
            var list = EnumHelper.GetList(typeof(Height));

            var maxHeight = (int)profile.Bio.Height + 15;
            if (!list.Any(a => a.Value == maxHeight)) maxHeight = (int)profile.Bio.Height + 16;
            if (!list.Any(a => a.Value == maxHeight)) maxHeight = (int)profile.Bio.Height + 17;
            if ((Height)maxHeight > Height._192) maxHeight = (int)Height._192;
            return (Height)maxHeight;
        }

        private static WantChildren? GetWantChildren(Profile profile)
        {
            if (profile.Lifestyle.WantChildren == WantChildren.No)
                return WantChildren.No;
            else
                return null;
        }

        private static MoneyPersonality? GetMoneyPersonality(Profile profile)
        {
            return null;
        }

        private static MyersBriggsTypeIndicator? GetMyersBriggsTypeIndicator(Profile profile)
        {
            return null;
        }

        private static RelationshipPersonality? GetRelationshipPersonality(Profile profile)
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