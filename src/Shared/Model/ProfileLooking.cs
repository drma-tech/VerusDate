using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VerusDate.Shared.Core;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.Model
{
    public class ProfileLooking : ModelBase
    {
        //TODO: LIMITAÇÃO DO BLAZOR
        [Display(Name = "Intenções", Description = "Campo obrigatório")]
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

        [Display(Name = "Corpo")]
        public BodyMass? BodyMass { get; set; }

        [Display(Name = "Raça")]
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

        public override void LoadDefatultData()
        {
            MinimalAge = 18;
            MaxAge = 40;
            MinimalHeight = Height._155;
            MaxHeight = Height._185;
        }
    }
}