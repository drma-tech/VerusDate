using System;
using System.Collections.Generic;
using VerusDate.Shared.Core;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.Model
{
    public class ProfilePreferenceModel
    {
        #region BASIC

        [Custom(Name = "Região")]
        public Region Region { get; set; }

        [Custom(Name = "Mudança")]
        public Change Change { get; set; }

        [Custom(Name = "Idiomas", Description = "Filtra perfis que tenham pelo menos um dos idiomas selecionados")]
        public IReadOnlyList<Language> Languages { get; set; } = Array.Empty<Language>();

        [Custom(Name = "Situação Atual")]
        public IReadOnlyList<CurrentSituation> CurrentSituation { get; set; } = Array.Empty<CurrentSituation>();

        [Custom(Name = "Sexo Biológico")]
        public IReadOnlyList<BiologicalSex> BiologicalSex { get; set; } = Array.Empty<BiologicalSex>();

        [Custom(Name = "Identidade de Gênero")]
        public IReadOnlyList<GenderIdentity> GenderIdentity { get; set; } = Array.Empty<GenderIdentity>();

        [Custom(Name = "Orientação Sexual")]
        public IReadOnlyList<SexualOrientation> SexualOrientation { get; set; } = Array.Empty<SexualOrientation>();

        #endregion BASIC

        #region BIO

        [Custom(Name = "Raça")]
        public IReadOnlyList<RaceCategory> RaceCategory { get; set; } = Array.Empty<RaceCategory>();

        [Custom(Name = "Corpo")]
        public IReadOnlyList<BodyMass> BodyMass { get; set; } = Array.Empty<BodyMass>();

        [Custom(Name = "Idade (Min - Máx)")]
        public int MinimalAge { get; set; }

        [Custom(Name = "Idade (Min - Máx)")]
        public int MaxAge { get; set; }

        [Custom(Name = "Altura (Min - Máx)")]
        public Height? MinimalHeight { get; set; }

        [Custom(Name = "Altura (Min - Máx)")]
        public Height? MaxHeight { get; set; }

        #endregion BIO

        #region LIFESTYLE

        [Custom(Name = "Drink_Name", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public IReadOnlyList<Drink> Drink { get; set; }

        [Custom(Name = "Smoke_Name", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public IReadOnlyList<Smoke> Smoke { get; set; }

        [Custom(Name = "Diet_Name", Description = "Diet_Description", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public IReadOnlyList<Diet> Diet { get; set; }

        [Custom(Name = "HaveChildren_Name", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public IReadOnlyList<HaveChildren> HaveChildren { get; set; }

        [Custom(Name = "WantChildren_Name", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public IReadOnlyList<WantChildren> WantChildren { get; set; }

        [Custom(Name = "EducationLevel_Name", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public IReadOnlyList<EducationLevel> EducationLevel { get; set; }

        [Custom(Name = "CareerCluster_Name", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public IReadOnlyList<CareerCluster> CareerCluster { get; set; }

        [Custom(Name = "Religion_Name", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public IReadOnlyList<Religion> Religion { get; set; }

        [Custom(Name = "Travel Frequency")]
        public IReadOnlyList<TravelFrequency> TravelFrequency { get; set; }

        #endregion LIFESTYLE

        #region OTHERS

        [Custom(Name = "SexPersonalityPreferences_Name", Description = "SexPersonalityPreferences_Description", ResourceType = typeof(Resources.Model.ProfileLifestyleModel))]
        public IReadOnlyList<SexPersonality> SexPersonality { get; set; } = Array.Empty<SexPersonality>();

        [Custom(Name = "Neurodiversity")]
        public Neurodiversity? Neurodiversity { get; set; }

        [Custom(Name = "Disabilities")]
        public IReadOnlyList<Disability> Disabilities { get; set; }

        #endregion OTHERS

        public void UpdateData(ProfilePreferenceModel vm)
        {
            //BASIC
            Region = vm.Region;
            Languages = vm.Languages;
            CurrentSituation = vm.CurrentSituation;
            BiologicalSex = vm.BiologicalSex;
            GenderIdentity = vm.GenderIdentity;
            SexualOrientation = vm.SexualOrientation;
            //BIO
            MinimalAge = vm.MinimalAge;
            MaxAge = vm.MaxAge;
            MinimalHeight = vm.MinimalHeight;
            MaxHeight = vm.MaxHeight;
            RaceCategory = vm.RaceCategory;
            BodyMass = vm.BodyMass;
        }
    }
}