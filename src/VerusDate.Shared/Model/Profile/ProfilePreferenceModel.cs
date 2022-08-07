using System;
using System.Collections.Generic;
using VerusDate.Shared.Core;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.Model
{
    public class ProfilePreferenceModel
    {
        #region BASIC

        [Custom(Name = "Distância")]
        public Distance Distance { get; set; }

        [Custom(Name = "Idiomas")]
        public IReadOnlyList<Language> Languages { get; set; } = Array.Empty<Language>();

        [Custom(Name = "Situação Atual")]
        public IReadOnlyList<CurrentSituation> CurrentSituation { get; set; } = Array.Empty<CurrentSituation>();

        [Custom(Name = "Intenções", Description = "Selecionado automaticamente de acordo com seu perfil")]
        public IReadOnlyList<Intentions> Intentions { get; set; } = Array.Empty<Intentions>();

        [Custom(Name = "Sexo Biológico")]
        public IReadOnlyList<BiologicalSex> BiologicalSex { get; set; } = Array.Empty<BiologicalSex>();

        [Custom(Name = "Identidade de Gênero")]
        public IReadOnlyList<GenderIdentity> GenderIdentity { get; set; } = Array.Empty<GenderIdentity>();

        [Custom(Name = "Orientação Sexual")]
        public IReadOnlyList<SexualOrientation> SexualOrientation { get; set; } = Array.Empty<SexualOrientation>();

        #endregion BASIC

        #region BIO

        [Custom(Name = "Idade (Min - Máx)")]
        public int MinimalAge { get; set; }

        [Custom(Name = "Idade (Min - Máx)")]
        public int MaxAge { get; set; }

        [Custom(Name = "Altura (Min - Máx)")]
        public Height? MinimalHeight { get; set; }

        [Custom(Name = "Altura (Min - Máx)")]
        public Height? MaxHeight { get; set; }

        [Custom(Name = "Raça")]
        public IReadOnlyList<RaceCategory> RaceCategory { get; set; } = Array.Empty<RaceCategory>();

        [Custom(Name = "Corpo")]
        public IReadOnlyList<BodyMass> BodyMass { get; set; } = Array.Empty<BodyMass>();

        #endregion BIO

        public void UpdateData(ProfilePreferenceModel vm)
        {
            //BASIC
            Distance = vm.Distance;
            Languages = vm.Languages;
            CurrentSituation = vm.CurrentSituation;
            Intentions = vm.Intentions;
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