using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VerusDate.Shared.Core;
using VerusDate.Shared.Enum;

namespace VerusDate.Shared.ViewModel
{
    [Table("ProfileLooking")]
    public class ProfileLookingVM : ViewModelType
    {
        [ExplicitKey]
        public string Id { get; set; }

        #region BASIC - REQUIRED FIELDS

        //TODO: LIMITAÇÃO DO BLAZOR
        [Display(Name = "Intenção")]
        public IReadOnlyList<Intent> Intent { get; set; } = new List<Intent>();

        [Display(Name = "Distância (KM)")]
        public double Distance { get; set; }

        [Display(Name = "Idade (Min - Máx)")]
        public int MinimalAge { get; set; } = 18;

        [Display(Name = "Idade (Min - Máx)")]
        public int MaxAge { get; set; }

        #endregion BASIC - REQUIRED FIELDS

        #region EXTRA - OPTIONAL FIELDS

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

        #endregion EXTRA - OPTIONAL FIELDS

        #region EXTRA - ONLY FOR WHO LOOKING FOR LONG TERM RELATIONSHIP

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

        #endregion EXTRA - ONLY FOR WHO LOOKING FOR LONG TERM RELATIONSHIP
    }
}