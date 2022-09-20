using VerusDate.Shared;
using VerusDate.Shared.Enum;
using VerusDate.Shared.Helper;
using VerusDate.Shared.Model;

namespace VerusDate.Web.Core
{
    public static class AffinityCore
    {
        public static List<AffinityVM> GetAffinity(ProfileModel user, ProfileView view)
        {
            if (user == null) throw new NotificationException("Não foi possível identificar seu perfil");
            if (view == null) throw new NotificationException("Não foi possível identificar o perfil deste usuário");
            if (user.Preference == null) throw new NotificationException("Não foi possível identificar suas preferências");

            var obj = new List<AffinityVM>
            {
                //BASIC - DEFINIÇÕES DE BUSCA
                //new AffinityVM(Section.Basic, CompatibilityItem.Location, GetLocation(user) == view.Location),
                new AffinityVM(Section.Basic, CompatibilityItem.Language, GetLanguages(user, user.Preference).IsMatch(view.Languages)),
                new AffinityVM(Section.Basic, CompatibilityItem.CurrentSituation, GetCurrentSituation(user, user.Preference).IsMatch(view.CurrentSituation.ToArray())),
                new AffinityVM(Section.Basic, CompatibilityItem.Intentions, GetIntentions(user).IsMatch(view.Intentions)),
                new AffinityVM(Section.Basic, CompatibilityItem.BiologicalSex, GetBiologicalSex(user, user.Preference).IsMatch(view.BiologicalSex.ToArray())),
                new AffinityVM(Section.Basic, CompatibilityItem.GenderIdentity, GetGenderIdentity(user, user.Preference).IsMatch(view.GenderIdentity.ToArray())),
                new AffinityVM(Section.Basic, CompatibilityItem.SexualOrientation, GetSexualOrientation(user, user.Preference).IsMatch(view.SexualOrientation.ToArray())),
                //new AffinityVM(Section.Basic, CompatibilityItem.Language, CheckEnumArrays(view.Languages, user.Preference.Languages), view.Languages.Intersect(user.Preference.Languages).Select(s => (int)s)),
                //new AffinityVM(Section.Basic, CompatibilityItem.CurrentSituation, CheckEnumArray(view.CurrentSituation, user.Preference.CurrentSituation)),
                //new AffinityVM(Section.Basic, CompatibilityItem.Intentions, CheckEnumArrays(view.Intentions, user.Intentions), view.Intentions.Intersect(user.Intentions).Select(s => (int)s)),
                //new AffinityVM(Section.Basic, CompatibilityItem.BiologicalSex, CheckEnumArray(view.BiologicalSex, user.Preference.BiologicalSex)),
                //new AffinityVM(Section.Basic, CompatibilityItem.GenderIdentity, CheckEnumArray(view.GenderIdentity, user.Preference.GenderIdentity)),
                //new AffinityVM(Section.Basic, CompatibilityItem.SexualOrientation, CheckEnumArray(view.SexualOrientation, user.Preference.SexualOrientation)),

                //BIO - DEFINIÇÕES DE BUSCA
                new AffinityVM(Section.Bio, CompatibilityItem.RaceCategory, GetRaceCategory(user.Preference).IsMatch(view.RaceCategory.ToArray())),
                new AffinityVM(Section.Bio, CompatibilityItem.BodyMass, GetBodyMass(user.Preference).IsMatch(view.BodyMass.ToArray())),
                new AffinityVM(Section.Bio, CompatibilityItem.Age, GetAge(user, user.Preference).IsRangeMatch(view.Age.ToArray())),
                new AffinityVM(Section.Bio, CompatibilityItem.Zodiac, GetZodiac(user).IsMatch(view.Zodiac.ToArray())),
                new AffinityVM(Section.Bio, CompatibilityItem.Height, GetHeight(user, user.Preference).Select(s => (int)s).ToArray().IsRangeMatch(((int?)view.Height).ToArray())),
                new AffinityVM(Section.Bio, CompatibilityItem.Neurodiversity, GetNeurodiversity(user.Preference).IsMatch(view.Neurodiversity.ToArray())),
                new AffinityVM(Section.Bio, CompatibilityItem.Disabilities, GetDisability(user.Preference).IsMatch(view.Disabilities)),
                //new AffinityVM(Section.Bio, CompatibilityItem.RaceCategory, CheckEnumArray(view.RaceCategory, user.Preference.RaceCategory)),
                //new AffinityVM(Section.Bio, CompatibilityItem.BodyMass, CheckEnumArray(view.BodyMass, user.Preference.BodyMass)),
                //new AffinityVM(Section.Bio, CompatibilityItem.Age, CheckAge(view.Age, user.Preference.MinimalAge, user.Preference.MaxAge)),
                //new AffinityVM(Section.Bio, CompatibilityItem.Zodiac, CheckEnumZodiac(view.Zodiac, user.Zodiac)),
                //new AffinityVM(Section.Bio, CompatibilityItem.Height, CheckHeight(view.Height, user.Preference.MinimalHeight, user.Preference.MaxHeight)),
                //new AffinityVM(Section.Bio, CompatibilityItem.Neurodiversity, CheckEnumArray(view.Neurodiversity, user.Preference.Neurodiversities)),
                //new AffinityVM(Section.Bio, CompatibilityItem.Disabilities, CheckEnumArrays(view.Disabilities, user.Preference.Disabilities)),

                //LIFESTYLE - COMPATIBILIDADE DE PERFIL OU DEFINIÇÕES DE BUSCA (SE PREENCHIDO)
                new AffinityVM(Section.Lifestyle, CompatibilityItem.Drink, GetDrink(user, user.Preference).IsMatch(view.Drink.ToArray())),
                new AffinityVM(Section.Lifestyle, CompatibilityItem.Smoke, GetSmoke(user, user.Preference).IsMatch(view.Smoke.ToArray())),
                new AffinityVM(Section.Lifestyle, CompatibilityItem.Diet, GetDiet(user, user.Preference).IsMatch(view.Diet.ToArray())),
                new AffinityVM(Section.Lifestyle, CompatibilityItem.Religion, GetReligion(user, user.Preference).IsMatch(view.Religion.ToArray())),
                new AffinityVM(Section.Lifestyle, CompatibilityItem.HaveChildren, GetHaveChildren(user, user.Preference).IsMatch(view.HaveChildren.ToArray())),
                new AffinityVM(Section.Lifestyle, CompatibilityItem.WantChildren, GetWantChildren(user, user.Preference).IsMatch(view.WantChildren.ToArray())),
                new AffinityVM(Section.Lifestyle, CompatibilityItem.EducationLevel, GetEducationLevel(user, user.Preference).IsMatch(view.EducationLevel.ToArray())),
                new AffinityVM(Section.Lifestyle, CompatibilityItem.CareerCluster, GetCareerCluster(user, user.Preference).IsMatch(view.CareerCluster.ToArray())),
                new AffinityVM(Section.Lifestyle, CompatibilityItem.TravelFrequency, GetTravelFrequency(user, user.Preference).IsMatch(view.TravelFrequency.ToArray())),
                //new AffinityVM(Section.Lifestyle, CompatibilityItem.Drink, CheckDrink(view.Drink, user.Drink)),
                //new AffinityVM(Section.Lifestyle, CompatibilityItem.Smoke, CheckSmoke(view.Smoke, user.Smoke)),
                //new AffinityVM(Section.Lifestyle, CompatibilityItem.Diet, CheckDiet(view.Diet, user.Diet)),
                //new AffinityVM(Section.Lifestyle, CompatibilityItem.Religion, CheckEnum((int?)view.Religion, (int?)user.Religion)),
                //new AffinityVM(Section.Lifestyle, CompatibilityItem.HaveChildren, CheckHaveChildren(view.HaveChildren, user.HaveChildren)),
                //new AffinityVM(Section.Lifestyle, CompatibilityItem.WantChildren, CheckWantChildren(view.WantChildren, user.WantChildren)),
                //new AffinityVM(Section.Lifestyle, CompatibilityItem.EducationLevel, CheckEnum((int?)view.EducationLevel, (int?)user.EducationLevel)),
                //new AffinityVM(Section.Lifestyle, CompatibilityItem.CareerCluster, CheckEnum((int?)view.CareerCluster, (int?)user.CareerCluster)),
                //new AffinityVM(Section.Lifestyle, CompatibilityItem.TravelFrequency, CheckEnum((int?)view.TravelFrequency, (int?)user.TravelFrequency)),

                //PERSONALITY - COMPATIBILIDADE DE PERFIL
                new AffinityVM(Section.Personality, CompatibilityItem.MoneyPersonality, GetMoneyPersonality(user).IsMatch(view.MoneyPersonality.ToArray())),
                new AffinityVM(Section.Personality, CompatibilityItem.SplitTheBill, GetSplitTheBill(user).IsMatch(view.SplitTheBill.ToArray())),
                new AffinityVM(Section.Personality, CompatibilityItem.RelationshipPersonality, GetRelationshipPersonality(user).IsMatch(view.RelationshipPersonality.ToArray())),
                new AffinityVM(Section.Personality, CompatibilityItem.MyersBriggsTypeIndicator, GetMyersBriggsTypeIndicator(user).IsMatch(view.MBTI.ToArray())),
                new AffinityVM(Section.Personality, CompatibilityItem.LoveLanguage, GetLoveLanguage(user).IsMatch(view.LoveLanguage.ToArray())),
                new AffinityVM(Section.Personality, CompatibilityItem.SexPersonality, GetSexPersonality(user, user.Preference).IsMatch(view.SexPersonality.ToArray())),
                //new AffinityVM(Section.Personality, CompatibilityItem.MoneyPersonality, CheckEnum((int?)view.MoneyPersonality, (int?)user.MoneyPersonality, true)),
                //new AffinityVM(Section.Personality, CompatibilityItem.SplitTheBill, CheckSplitTheBill(view.SplitTheBill, user.SplitTheBill)),
                //new AffinityVM(Section.Personality, CompatibilityItem.RelationshipPersonality, CheckEnumRelationshipPersonality(view.RelationshipPersonality, user.RelationshipPersonality)),
                //new AffinityVM(Section.Personality, CompatibilityItem.MyersBriggsTypeIndicator, CheckEnumMBTI(view.MyersBriggsTypeIndicator, user.MyersBriggsTypeIndicator)),
                //new AffinityVM(Section.Personality, CompatibilityItem.LoveLanguage, CheckEnum((int?)view.LoveLanguage, (int?)user.LoveLanguage, true)),
                //new AffinityVM(Section.Personality, CompatibilityItem.SexPersonality, CheckEnumArray(view.SexPersonality, user.Preference.SexPersonality, true)),

                //INTEREST - COMPATIBILIDADE DE PERFIL (UMA OPÇAO IGUAL JÁ INDICA COMPATIBILIDADE)
                new AffinityVM(Section.Interest, CompatibilityItem.Food, GetFood(user).IsMatch(view.Food)),
                new AffinityVM(Section.Interest, CompatibilityItem.Vacation, GetVacation(user).IsMatch(view.Vacation)),
                new AffinityVM(Section.Interest, CompatibilityItem.Sports, GetSports(user).IsMatch(view.Sports)),
                new AffinityVM(Section.Interest, CompatibilityItem.LeisureActivities, GetLeisureActivities(user).IsMatch(view.LeisureActivities)),
                new AffinityVM(Section.Interest, CompatibilityItem.MusicGenre, GetMusicGenre(user).IsMatch(view.MusicGenre)),
                new AffinityVM(Section.Interest, CompatibilityItem.MovieGenre, GetMovieGenre(user).IsMatch(view.MovieGenre)),
                new AffinityVM(Section.Interest, CompatibilityItem.TVGenre, GetTVGenre(user).IsMatch(view.TVGenre)),
                new AffinityVM(Section.Interest, CompatibilityItem.ReadingGenre, GetReadingGenre(user).IsMatch(view.ReadingGenre)),
                //new AffinityVM(Section.Interest, CompatibilityItem.Food, CheckEnumArrays(view.Food, user.Food), view.Food.Intersect(user.Food).Select(s => (int)s)),
                //new AffinityVM(Section.Interest, CompatibilityItem.Vacation, CheckEnumArrays(view.Vacation, user.Vacation), view.Vacation.Intersect(user.Vacation).Select(s => (int)s)),
                //new AffinityVM(Section.Interest, CompatibilityItem.Sports, CheckEnumArrays(view.Sports, user.Sports), view.Sports.Intersect(user.Sports).Select(s => (int)s)),
                //new AffinityVM(Section.Interest, CompatibilityItem.LeisureActivities, CheckEnumArrays(view.LeisureActivities, user.LeisureActivities), view.LeisureActivities.Intersect(user.LeisureActivities).Select(s => (int)s)),
                //new AffinityVM(Section.Interest, CompatibilityItem.MusicGenre, CheckEnumArrays(view.MusicGenre, user.MusicGenre), view.MusicGenre.Intersect(user.MusicGenre).Select(s => (int)s)),
                //new AffinityVM(Section.Interest, CompatibilityItem.MovieGenre, CheckEnumArrays(view.MovieGenre, user.MovieGenre), view.MovieGenre.Intersect(user.MovieGenre).Select(s => (int)s)),
                //new AffinityVM(Section.Interest, CompatibilityItem.TVGenre, CheckEnumArrays(view.TVGenre, user.TVGenre), view.TVGenre.Intersect(user.TVGenre).Select(s => (int)s)),
                //new AffinityVM(Section.Interest, CompatibilityItem.ReadingGenre, CheckEnumArrays(view.ReadingGenre, user.ReadingGenre), view.ReadingGenre.Intersect(user.ReadingGenre).Select(s => (int)s)),
            };

            return obj;
        }

        public static string[] ToArray(this string item)
        {
            return new string[] { item };
        }

        public static T[] ToArray<T>(this T item) where T : struct
        {
            return new T[] { item };
        }

        public static T[] ToArray<T>(this T? item) where T : struct
        {
            if (item.HasValue) return item.Value.ToArray();
            else return Array.Empty<T>();
        }

        private static bool IsMatch<T>(this IReadOnlyList<T> preferences, IReadOnlyList<T> view)
        {
            if (!preferences.Any()) return true; //if preferences are empty then accept all
            if (!view.Any()) return false; //if the preference is not empty and the view is empty then it does not accept anything

            return preferences.Intersect(view).Any();
        }

        private static bool IsRangeMatch(this IReadOnlyList<int> preferences, IReadOnlyList<int> view)
        {
            if (!preferences.Any()) return true; //if preferences are empty then accept all
            if (!view.Any()) return false; //if the preference is not empty and the view is empty then it does not accept anything
            if (preferences.Count != 2) throw new InvalidOperationException("preferences.Count != 2");

            return preferences[0] <= view[0] && view[0] <= preferences[1];
        }

        #region BASIC

        public static string GetLocation(ProfileModel user)
        {
            var parts = user.Location.Split(" - ");

            return user.Preference.Region switch
            {
                Region.City => user.Location, //level 3
                Region.State => $"{parts[0]} - {parts[1]}", //level 2
                Region.Country => $"{parts[0]}", //level 1
                Region.World => "",
                _ => "",
            };
        }

        public static IReadOnlyList<Language> GetLanguages(ProfileModel user, ProfilePreferenceModel? pref = null)
        {
            if (pref != null && pref.Languages.Any()) return pref.Languages;
            else if (user.Languages.Any()) return user.Languages;
            else return Array.Empty<Language>();
        }

        public static IReadOnlyList<CurrentSituation> GetCurrentSituation(ProfileModel user, ProfilePreferenceModel? pref = null)
        {
            CurrentSituation[] selected;
            if (pref != null && pref.CurrentSituation.Any()) selected = pref.CurrentSituation.ToArray();
            else if (user.CurrentSituation.HasValue) selected = user.CurrentSituation.ToArray();
            else selected = Array.Empty<CurrentSituation>();

            if (selected.Length == 1 && selected.First() == CurrentSituation.Single)
                return selected;
            else
                return Array.Empty<CurrentSituation>();
        }

        public static IReadOnlyList<Intentions> GetIntentions(ProfileModel user)
        {
            return user.Intentions;
        }

        public static IReadOnlyList<BiologicalSex> GetBiologicalSex(ProfileModel user, ProfilePreferenceModel? pref = null)
        {
            if (pref != null && pref.BiologicalSex.Any())
            {
                return pref.BiologicalSex;
            }
            else
            {
                if (user.GenderIdentity == GenderIdentity.Cisgender) //BINARY
                {
                    if (user.SexualOrientation == SexualOrientation.Heterosexual)
                    {
                        return user.BiologicalSex switch
                        {
                            BiologicalSex.Male => BiologicalSex.Female.ToArray(),
                            BiologicalSex.Female => BiologicalSex.Male.ToArray(),
                            _ => Array.Empty<BiologicalSex>()
                        };
                    }
                    else if (user.SexualOrientation == SexualOrientation.Homosexual)
                    {
                        return user.BiologicalSex switch
                        {
                            BiologicalSex.Male => BiologicalSex.Male.ToArray(),
                            BiologicalSex.Female => BiologicalSex.Female.ToArray(),
                            _ => Array.Empty<BiologicalSex>()
                        };
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
        }

        public static IReadOnlyList<GenderIdentity> GetGenderIdentity(ProfileModel user, ProfilePreferenceModel? pref = null)
        {
            if (pref != null && pref.GenderIdentity.Any())
            {
                return pref.GenderIdentity;
            }
            else
            {
                if (user.GenderIdentity == GenderIdentity.Cisgender) //BINARY
                {
                    return GenderIdentity.Cisgender.ToArray();
                }
                else //NON-BINARY
                {
                    return Array.Empty<GenderIdentity>();
                }
            }
        }

        public static IReadOnlyList<SexualOrientation> GetSexualOrientation(ProfileModel user, ProfilePreferenceModel? pref = null)
        {
            if (pref != null && pref.SexualOrientation.Any())
            {
                return pref.SexualOrientation;
            }
            else
            {
                return user.SexualOrientation switch
                {
                    SexualOrientation.Heterosexual => new SexualOrientation[] { SexualOrientation.Heterosexual },
                    SexualOrientation.Homosexual => new SexualOrientation[] { SexualOrientation.Homosexual },
                    _ => Array.Empty<SexualOrientation>()
                };
            }
        }

        #endregion BASIC

        #region BIO

        public static IReadOnlyList<RaceCategory> GetRaceCategory(ProfilePreferenceModel? pref = null)
        {
            if (pref != null && pref.RaceCategory.Any()) return pref.RaceCategory;
            else return Array.Empty<RaceCategory>();
        }

        public static IReadOnlyList<BodyMass> GetBodyMass(ProfilePreferenceModel? pref = null)
        {
            if (pref != null && pref.BodyMass.Any()) return pref.BodyMass;
            else return Array.Empty<BodyMass>();
        }

        public static IReadOnlyList<int> GetAge(ProfileModel user, ProfilePreferenceModel? pref = null, bool force = false)
        {
            int min;
            int max;

            if (pref != null && !force)
            {
                min = pref.MinimalAge;
                max = pref.MaxAge;
            }
            else
            {
                var age = user.BirthDate.GetAge();

                min = age / 2 + 7;
                if (min < 18) min = 18;

                max = (age - 7) * 2;
                if (max > 120) max = 120;
            }

            return new int[] { min, max };
        }

        public static IReadOnlyList<Zodiac> GetZodiac(ProfileModel user)
        {
            return user.Zodiac switch
            {
                Zodiac.Aries => new Zodiac[] { Zodiac.Leo, Zodiac.Sagittarius },
                Zodiac.Taurus => new Zodiac[] { Zodiac.Virgo, Zodiac.Capricorn },
                Zodiac.Gemini => new Zodiac[] { Zodiac.Libra, Zodiac.Aquarius },
                Zodiac.Cancer => new Zodiac[] { Zodiac.Scorpio, Zodiac.Pisces },
                Zodiac.Leo => new Zodiac[] { Zodiac.Aries, Zodiac.Sagittarius },
                Zodiac.Virgo => new Zodiac[] { Zodiac.Taurus, Zodiac.Capricorn },
                Zodiac.Libra => new Zodiac[] { Zodiac.Gemini, Zodiac.Aquarius },
                Zodiac.Scorpio => new Zodiac[] { Zodiac.Cancer, Zodiac.Scorpio, Zodiac.Pisces },
                Zodiac.Sagittarius => new Zodiac[] { Zodiac.Aries, Zodiac.Leo },
                Zodiac.Capricorn => new Zodiac[] { Zodiac.Taurus, Zodiac.Virgo },
                Zodiac.Aquarius => new Zodiac[] { Zodiac.Gemini, Zodiac.Libra },
                Zodiac.Pisces => new Zodiac[] { Zodiac.Cancer, Zodiac.Scorpio },
                _ => Array.Empty<Zodiac>()
            };
        }

        public static IReadOnlyList<Height> GetHeight(ProfileModel user, ProfilePreferenceModel? pref = null, bool force = false)
        {
            Height min;
            Height max;
            var ratio = 1.09;

            if (pref != null && pref.MinimalHeight.HasValue && !force)
            {
                min = pref.MinimalHeight.Value;
            }
            else
            {
                if (user.Height.HasValue)
                {
                    int minHeight;

                    if (pref != null && pref.BiologicalSex.Any() && pref.BiologicalSex.Count == 1)
                    {
                        if (user.BiologicalSex == BiologicalSex.Male && pref.BiologicalSex[0] == BiologicalSex.Female)
                        {
                            minHeight = (int)Math.Round((int)user.Height.Value / (ratio + 0.04));
                        }
                        else if (user.BiologicalSex == BiologicalSex.Female && pref.BiologicalSex[0] == BiologicalSex.Male)
                        {
                            minHeight = (int)Math.Round((int)user.Height.Value * (ratio - 0.04));
                        }
                        else
                        {
                            minHeight = (int)user.Height.Value - 10; //if you don't have opposite biological sex, you don't have a formula for height
                        }
                    }
                    else
                    {
                        minHeight = (int)user.Height.Value - 10; //if you don't have opposite biological sex, you don't have a formula for height
                    }

                    if (minHeight < (int)Height._140) minHeight = (int)Height._140;
                    min = (Height)minHeight;
                }
                else
                {
                    throw new InvalidOperationException("user.Height.HasValue");
                }
            }

            if (pref != null && pref.MaxHeight.HasValue && !force)
            {
                max = pref.MaxHeight.Value;
            }
            else
            {
                if (user.Height.HasValue)
                {
                    int maxHeight;

                    if (pref != null && pref.BiologicalSex.Any() && pref.BiologicalSex.Count == 1)
                    {
                        if (user.BiologicalSex == BiologicalSex.Male && pref.BiologicalSex[0] == BiologicalSex.Female)
                        {
                            maxHeight = (int)Math.Round((int)user.Height.Value / (ratio - 0.04));
                        }
                        else if (user.BiologicalSex == BiologicalSex.Female && pref.BiologicalSex[0] == BiologicalSex.Male)
                        {
                            maxHeight = (int)Math.Round((int)user.Height.Value * (ratio + 0.04));
                        }
                        else
                        {
                            maxHeight = (int)user.Height.Value + 10; //if you don't have opposite biological sex, you don't have a formula for height
                        }
                    }
                    else
                    {
                        maxHeight = (int)user.Height.Value + 10; //if you don't have opposite biological sex, you don't have a formula for height
                    }

                    if (maxHeight > (int)Height._192) maxHeight = (int)Height._192;
                    max = (Height)maxHeight;
                }
                else
                {
                    throw new InvalidOperationException("user.Height.HasValue");
                }
            }

            return new Height[] { min, max };
        }

        public static IReadOnlyList<Neurodiversity> GetNeurodiversity(ProfilePreferenceModel? pref = null)
        {
            if (pref != null)
                return pref.Neurodiversities;
            else
                return Array.Empty<Neurodiversity>();
        }

        public static IReadOnlyList<Disability> GetDisability(ProfilePreferenceModel? pref = null)
        {
            if (pref != null)
                return pref.Disabilities;
            else
                return Array.Empty<Disability>();
        }

        #endregion BIO

        #region LIFESTYLE

        public static IReadOnlyList<Drink> GetDrink(ProfileModel user, ProfilePreferenceModel? pref = null)
        {
            if (pref != null && pref.Drink.Any())
            {
                return pref.Drink;
            }
            else
            {
                return user.Drink switch
                {
                    Drink.No => new Drink[] { Drink.No, Drink.YesLight },
                    Drink.YesLight => new Drink[] { Drink.No, Drink.YesLight, Drink.YesModerate },
                    Drink.YesModerate => new Drink[] { Drink.YesLight, Drink.YesModerate, Drink.YesHeavy },
                    Drink.YesHeavy => new Drink[] { Drink.YesModerate, Drink.YesHeavy },
                    _ => Array.Empty<Drink>()
                };
            }
        }

        public static IReadOnlyList<Smoke> GetSmoke(ProfileModel user, ProfilePreferenceModel? pref = null)
        {
            if (pref != null && pref.Smoke.Any())
            {
                return pref.Smoke;
            }
            else
            {
                return user.Smoke switch
                {
                    Smoke.No => new Smoke[] { Smoke.No },
                    Smoke.YesOccasionally => new Smoke[] { Smoke.YesOccasionally, Smoke.YesOften },
                    Smoke.YesOften => new Smoke[] { Smoke.YesOccasionally, Smoke.YesOften },
                    _ => Array.Empty<Smoke>()
                };
            }
        }

        public static IReadOnlyList<Diet> GetDiet(ProfileModel user, ProfilePreferenceModel? pref = null)
        {
            if (pref != null && pref.Diet.Any())
            {
                return pref.Diet;
            }
            else
            {
                var group01 = new Diet[] { Diet.Omnivore, Diet.Flexitarian, Diet.GlutenFree };
                var group02 = new Diet[] { Diet.Vegetarian, Diet.Vegan };
                var group03 = new Diet[] { Diet.RawFood, Diet.OrganicAllnaturalLocal };

                return user.Diet switch
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
        }

        public static IReadOnlyList<Religion> GetReligion(ProfileModel user, ProfilePreferenceModel? pref = null)
        {
            if (pref != null && pref.Religion.Any())
            {
                return pref.Religion;
            }
            else
            {
                return new Religion[] { user.Religion.Value };
            }
        }

        public static IReadOnlyList<HaveChildren> GetHaveChildren(ProfileModel user, ProfilePreferenceModel? pref = null)
        {
            if (pref != null && pref.HaveChildren.Any())
            {
                return pref.HaveChildren;
            }
            else
            {
                return user.HaveChildren switch
                {
                    HaveChildren.No => new HaveChildren[] { HaveChildren.No, HaveChildren.YesNo },
                    HaveChildren.YesNo => new HaveChildren[] { HaveChildren.No, HaveChildren.YesNo },
                    HaveChildren.Yes => new HaveChildren[] { HaveChildren.Yes },
                    _ => Array.Empty<HaveChildren>()
                };
            }
        }

        public static IReadOnlyList<WantChildren> GetWantChildren(ProfileModel user, ProfilePreferenceModel? pref = null)
        {
            if (pref != null && pref.WantChildren.Any())
            {
                return pref.WantChildren;
            }
            else
            {
                return user.WantChildren switch
                {
                    WantChildren.No => new WantChildren[] { WantChildren.No },
                    WantChildren.Maybe => new WantChildren[] { WantChildren.Maybe, WantChildren.Yes },
                    WantChildren.Yes => new WantChildren[] { WantChildren.Maybe, WantChildren.Yes },
                    _ => Array.Empty<WantChildren>()
                };
            }
        }

        public static IReadOnlyList<EducationLevel> GetEducationLevel(ProfileModel user, ProfilePreferenceModel? pref = null)
        {
            if (pref != null && pref.EducationLevel.Any())
            {
                return pref.EducationLevel;
            }
            else
            {
                return new EducationLevel[] { user.EducationLevel.Value };
            }
        }

        public static IReadOnlyList<CareerCluster> GetCareerCluster(ProfileModel user, ProfilePreferenceModel? pref = null)
        {
            if (pref != null && pref.CareerCluster.Any())
            {
                return pref.CareerCluster;
            }
            else
            {
                return new CareerCluster[] { user.CareerCluster.Value };
            }
        }

        public static IReadOnlyList<TravelFrequency> GetTravelFrequency(ProfileModel user, ProfilePreferenceModel? pref = null)
        {
            if (pref != null && pref.TravelFrequency.Any())
            {
                return pref.TravelFrequency;
            }
            else
            {
                return user.TravelFrequency switch
                {
                    TravelFrequency.NeverRarely => new TravelFrequency[] { TravelFrequency.NeverRarely, TravelFrequency.SometimesFrequently },
                    TravelFrequency.SometimesFrequently => new TravelFrequency[] { TravelFrequency.NeverRarely, TravelFrequency.SometimesFrequently, TravelFrequency.UsuallyAlwaysNomad },
                    TravelFrequency.UsuallyAlwaysNomad => new TravelFrequency[] { TravelFrequency.SometimesFrequently, TravelFrequency.UsuallyAlwaysNomad },
                    _ => Array.Empty<TravelFrequency>()
                };
            }
        }

        #endregion LIFESTYLE

        #region PERSONALITY

        public static IReadOnlyList<MoneyPersonality> GetMoneyPersonality(ProfileModel user)
        {
            return user.MoneyPersonality.ToArray();
        }

        public static IReadOnlyList<SplitTheBill> GetSplitTheBill(ProfileModel user)
        {
            //invented by me (dhiogo)

            return user.SplitTheBill switch
            {
                SplitTheBill.Dependent => SplitTheBill.Provider.ToArray(),
                SplitTheBill.GetGifts => SplitTheBill.SendGifts.ToArray(),
                SplitTheBill.Balanced => SplitTheBill.Balanced.ToArray(),
                SplitTheBill.SendGifts => SplitTheBill.GetGifts.ToArray(),
                SplitTheBill.Provider => SplitTheBill.Dependent.ToArray(),
                _ => Array.Empty<SplitTheBill>()
            };
        }

        public static IReadOnlyList<RelationshipPersonality> GetRelationshipPersonality(ProfileModel user)
        {
            //https://helenfisher.com/downloads/articles/Article_%20We%20Have%20Chemistry.pdf

            return user.RelationshipPersonality switch
            {
                RelationshipPersonality.Explorers => RelationshipPersonality.Explorers.ToArray(),
                RelationshipPersonality.Directors => RelationshipPersonality.Negotiator.ToArray(),
                RelationshipPersonality.Builders => RelationshipPersonality.Builders.ToArray(),
                RelationshipPersonality.Negotiator => RelationshipPersonality.Directors.ToArray(),
                _ => Array.Empty<RelationshipPersonality>()
            };
        }

        public static IReadOnlyList<MyersBriggsTypeIndicator> GetMyersBriggsTypeIndicator(ProfileModel user)
        {
            //http://www.personalityrelationships.net/
            //https://web.archive.org/web/20220322143220/http://www.personalityrelationships.net/

            return user.MBTI switch
            {
                MyersBriggsTypeIndicator.INTJ => new MyersBriggsTypeIndicator[] { MyersBriggsTypeIndicator.ENTP, MyersBriggsTypeIndicator.ENFP },
                MyersBriggsTypeIndicator.INTP => new MyersBriggsTypeIndicator[] { MyersBriggsTypeIndicator.ENTJ, MyersBriggsTypeIndicator.ENFJ },
                MyersBriggsTypeIndicator.ENTJ => new MyersBriggsTypeIndicator[] { MyersBriggsTypeIndicator.INTP, MyersBriggsTypeIndicator.INFP },
                MyersBriggsTypeIndicator.ENTP => new MyersBriggsTypeIndicator[] { MyersBriggsTypeIndicator.INTJ, MyersBriggsTypeIndicator.INFJ },

                MyersBriggsTypeIndicator.INFJ => new MyersBriggsTypeIndicator[] { MyersBriggsTypeIndicator.ENFP, MyersBriggsTypeIndicator.ENTP, MyersBriggsTypeIndicator.INTJ, MyersBriggsTypeIndicator.INFJ },
                MyersBriggsTypeIndicator.INFP => new MyersBriggsTypeIndicator[] { MyersBriggsTypeIndicator.ENFJ, MyersBriggsTypeIndicator.ENTJ },
                MyersBriggsTypeIndicator.ENFJ => new MyersBriggsTypeIndicator[] { MyersBriggsTypeIndicator.INFP, MyersBriggsTypeIndicator.INTP },
                MyersBriggsTypeIndicator.ENFP => new MyersBriggsTypeIndicator[] { MyersBriggsTypeIndicator.INFJ, MyersBriggsTypeIndicator.INTJ },

                MyersBriggsTypeIndicator.ISTJ => new MyersBriggsTypeIndicator[] { MyersBriggsTypeIndicator.ESTP, MyersBriggsTypeIndicator.ESFP },
                MyersBriggsTypeIndicator.ISFJ => new MyersBriggsTypeIndicator[] { MyersBriggsTypeIndicator.ESFP, MyersBriggsTypeIndicator.ESTP },
                MyersBriggsTypeIndicator.ESTJ => new MyersBriggsTypeIndicator[] { MyersBriggsTypeIndicator.ISTP, MyersBriggsTypeIndicator.ISFP },
                MyersBriggsTypeIndicator.ESFJ => new MyersBriggsTypeIndicator[] { MyersBriggsTypeIndicator.ISFP, MyersBriggsTypeIndicator.ISTP },

                MyersBriggsTypeIndicator.ISTP => new MyersBriggsTypeIndicator[] { MyersBriggsTypeIndicator.ESFJ, MyersBriggsTypeIndicator.ESTJ },
                MyersBriggsTypeIndicator.ISFP => new MyersBriggsTypeIndicator[] { MyersBriggsTypeIndicator.ESTJ, MyersBriggsTypeIndicator.ESFJ },
                MyersBriggsTypeIndicator.ESTP => new MyersBriggsTypeIndicator[] { MyersBriggsTypeIndicator.ISTJ, MyersBriggsTypeIndicator.ISFJ },
                MyersBriggsTypeIndicator.ESFP => new MyersBriggsTypeIndicator[] { MyersBriggsTypeIndicator.ISTJ, MyersBriggsTypeIndicator.ISFJ },
                _ => Array.Empty<MyersBriggsTypeIndicator>()
            };
        }

        public static IReadOnlyList<LoveLanguage> GetLoveLanguage(ProfileModel user)
        {
            return user.LoveLanguage.ToArray();
        }

        public static IReadOnlyList<SexPersonality> GetSexPersonality(ProfileModel user, ProfilePreferenceModel? pref = null)
        {
            if (pref != null && pref.SexPersonality.Any())
            {
                return pref.SexPersonality;
            }
            else
            {
                return user.SexPersonality.ToArray();
            }
        }

        #endregion PERSONALITY

        #region INTEREST

        public static IReadOnlyList<Food> GetFood(ProfileModel user)
        {
            return user.Food.ToArray();
        }

        public static IReadOnlyList<Vacation> GetVacation(ProfileModel user)
        {
            return user.Vacation.ToArray();
        }

        public static IReadOnlyList<Sports> GetSports(ProfileModel user)
        {
            return user.Sports.ToArray();
        }

        public static IReadOnlyList<LeisureActivities> GetLeisureActivities(ProfileModel user)
        {
            return user.LeisureActivities.ToArray();
        }

        public static IReadOnlyList<MusicGenre> GetMusicGenre(ProfileModel user)
        {
            return user.MusicGenre.ToArray();
        }

        public static IReadOnlyList<MovieGenre> GetMovieGenre(ProfileModel user)
        {
            return user.MovieGenre.ToArray();
        }

        public static IReadOnlyList<TVGenre> GetTVGenre(ProfileModel user)
        {
            return user.TVGenre.ToArray();
        }

        public static IReadOnlyList<ReadingGenre> GetReadingGenre(ProfileModel user)
        {
            return user.ReadingGenre.ToArray();
        }

        #endregion INTEREST

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

        public static int GetPercentAffinity(this List<AffinityVM> Affinities, Section? category = null)
        {
            if (category == null)
            {
                var totBasic = Affinities.GetPercentAffinity(Section.Basic);
                var totBio = Affinities.GetPercentAffinity(Section.Bio);
                var totLifestyle = Affinities.GetPercentAffinity(Section.Lifestyle);
                var totPersonality = Affinities.GetPercentAffinity(Section.Personality);
                var totInterest = Affinities.GetPercentAffinity(Section.Interest);

                var pesoBasic = 1;
                var pesoBio = 1;
                var pesoLifestyle = 3;
                var pesoPersonality = 3;
                var pesoInterest = 2;

                return (totBasic * pesoBasic + totBio * pesoBio + totLifestyle * pesoLifestyle + totPersonality * pesoPersonality + totInterest * pesoInterest) /
                    (pesoBasic + pesoBio + pesoLifestyle + pesoPersonality + pesoInterest);
            }
            else
            {
                double totCheck = Affinities.Count(w => w.Section == category && w.HaveAffinity);
                double totItens = Affinities.Count(w => w.Section == category);

                if (totCheck == 0 || totItens == 0) return 0;

                return Convert.ToInt32(Math.Round((totCheck / totItens) * 100, 0));
            }
        }
    }
}