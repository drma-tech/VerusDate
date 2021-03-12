using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.Model
{
    public class ProfileLookingModel
    {
        [Display(Name = "Distância")]
        public Distance Distance { get; set; }

        [Display(Name = "Idiomas")]
        public IReadOnlyList<Language> Languages { get; set; } = Array.Empty<Language>();

        [Display(Name = "Situação Atual")]
        public IReadOnlyList<CurrentSituation> CurrentSituation { get; set; } = Array.Empty<CurrentSituation>();

        [Display(Name = "Intenções", Description = "Selecionado automaticamente de acordo com seu perfil")]
        public IReadOnlyList<Intent> Intent { get; set; } = Array.Empty<Intent>();

        [Display(Name = "Sexo Biológico")]
        public IReadOnlyList<BiologicalSex> BiologicalSex { get; set; } = Array.Empty<BiologicalSex>();

        [Display(Name = "Identidade de Gênero")]
        public IReadOnlyList<GenderIdentity> GenderIdentity { get; set; } = Array.Empty<GenderIdentity>();

        [Display(Name = "Orientação Sexual")]
        public IReadOnlyList<SexualOrientation> SexualOrientation { get; set; } = Array.Empty<SexualOrientation>();

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

        [Display(Name = "Bebe")]
        public Drink? Drink { get; set; }

        [Display(Name = "Fuma")]
        public Smoke? Smoke { get; set; }

        [Display(Name = "Dieta")]
        public Diet? Diet { get; set; }

        [Display(Name = "Tem Filho(s)")]
        public HaveChildren? HaveChildren { get; set; }

        [Display(Name = "Quer Filho(s)")]
        public WantChildren? WantChildren { get; set; }

        [Display(Name = "Educação")]
        public EducationLevel? EducationLevel { get; set; }

        [Display(Name = "Carreira")]
        public CareerCluster? CareerCluster { get; set; }

        [Display(Name = "Religião")]
        public Religion? Religion { get; set; }

        public void UpdateData(ProfileLookingModel vm)
        {
            Intent = vm.Intent;
            Distance = vm.Distance;
            MinimalAge = vm.MinimalAge;
            MaxAge = vm.MaxAge;
            BiologicalSex = vm.BiologicalSex;
            CurrentSituation = vm.CurrentSituation;
            GenderIdentity = vm.GenderIdentity;
            SexualOrientation = vm.SexualOrientation;
            Smoke = vm.Smoke;
            Drink = vm.Drink;
            Diet = vm.Diet;
            MinimalHeight = vm.MaxHeight;
            BodyMass = vm.BodyMass;
            RaceCategory = vm.RaceCategory;
            HaveChildren = vm.HaveChildren;
            WantChildren = vm.WantChildren;
            Religion = vm.Religion;
            EducationLevel = vm.EducationLevel;
            CareerCluster = vm.CareerCluster;
        }
    }
}