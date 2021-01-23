using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.Model
{
    public class ProfileLookingModel
    {
        //TODO: IReadOnlyList - LIMITAÇÃO DO BLAZOR
        [Display(Name = "Intenções", Description = "Campo obrigatório (múltipla escolha)")]
        public IReadOnlyList<Intent> Intent { get; set; } = new List<Intent>();

        [Display(Name = "Distância (KM)", Description = "Campo obrigatório")]
        public double Distance { get; set; }

        [Display(Name = "Idade (Min - Máx)", Description = "Campo obrigatório")]
        public int MinimalAge { get; set; }

        [Display(Name = "Idade (Min - Máx)", Description = "Campo obrigatório")]
        public int MaxAge { get; set; }

        [Display(Name = "Sexo Biológico")]
        public BiologicalSex? BiologicalSex { get; set; }

        [Display(Name = "Status de relacionamento")]
        public MaritalStatus? MaritalStatus { get; set; }

        [Display(Name = "Identidade de Gênero")]
        public GenderIdentity? GenderIdentity { get; set; }

        [Display(Name = "Orientação Sexual")]
        public SexualOrientation? SexualOrientation { get; set; }

        [Display(Name = "Fuma")]
        public Smoke? Smoke { get; set; }

        [Display(Name = "Bebe")]
        public Drink? Drink { get; set; }

        [Display(Name = "Dieta")]
        public Diet? Diet { get; set; }

        [Display(Name = "Altura (Min - Máx)")]
        public Height? MinimalHeight { get; set; }

        [Display(Name = "Altura (Min - Máx)")]
        public Height? MaxHeight { get; set; }

        [Display(Name = "Corpo", Description = "Esta informação poderá ser subjetiva")]
        public BodyMass? BodyMass { get; set; }

        [Display(Name = "Raça", Description = "Classificação por US OMB")]
        public RaceCategory? RaceCategory { get; set; }

        [Display(Name = "Tem Filho(s)")]
        public HaveChildren? HaveChildren { get; set; }

        [Display(Name = "Quer Filho(s)")]
        public WantChildren? WantChildren { get; set; }

        [Display(Name = "Religião")]
        public Religion? Religion { get; set; }

        [Display(Name = "Educação")]
        public EducationLevel? EducationLevel { get; set; }

        [Display(Name = "Carreira")]
        public CareerCluster? CareerCluster { get; set; }

        public void UpdateData(ProfileLookingModel vm)
        {
            Intent = vm.Intent;
            Distance = vm.Distance;
            MinimalAge = vm.MinimalAge;
            MaxAge = vm.MaxAge;
            BiologicalSex = vm.BiologicalSex;
            MaritalStatus = vm.MaritalStatus;
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