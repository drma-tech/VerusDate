using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.Model
{
    public class ProfilePreferenceModel
    {
        #region BASIC

        [Display(Name = "Distância")]
        public Distance Distance { get; set; }

        [Display(Name = "Idiomas")]
        public IReadOnlyList<Language> Languages { get; set; } = Array.Empty<Language>();

        [Display(Name = "Situação Atual")]
        public IReadOnlyList<CurrentSituation> CurrentSituation { get; set; } = Array.Empty<CurrentSituation>();

        [Display(Name = "Intenções", Description = "Selecionado automaticamente de acordo com seu perfil")]
        public IReadOnlyList<Intentions> Intentions { get; set; } = Array.Empty<Intentions>();

        [Display(Name = "Sexo Biológico")]
        public IReadOnlyList<BiologicalSex> BiologicalSex { get; set; } = Array.Empty<BiologicalSex>();

        [Display(Name = "Identidade de Gênero")]
        public IReadOnlyList<GenderIdentity> GenderIdentity { get; set; } = Array.Empty<GenderIdentity>();

        [Display(Name = "Orientação Sexual")]
        public IReadOnlyList<SexualOrientation> SexualOrientation { get; set; } = Array.Empty<SexualOrientation>();

        #endregion BASIC

        #region BIO

        [Display(Name = "Idade (Min - Máx)")]
        public int MinimalAge { get; set; }

        [Display(Name = "Idade (Min - Máx)")]
        public int MaxAge { get; set; }

        [Display(Name = "Altura (Min - Máx)")]
        public Height? MinimalHeight { get; set; }

        [Display(Name = "Altura (Min - Máx)")]
        public Height? MaxHeight { get; set; }

        [Display(Name = "Raça")]
        public IReadOnlyList<RaceCategory> RaceCategory { get; set; } = Array.Empty<RaceCategory>();

        [Display(Name = "Corpo")]
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