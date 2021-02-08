using System.ComponentModel.DataAnnotations;

namespace VerusDate.Shared.Enum
{
    public enum EducationLevel
    {
        [Display(Name = "Superior incompleto ou menos")]
        HighSchool = 1,

        [Display(Name = "Bacharelado / Licenciatura")]
        College = 2,

        [Display(Name = "Mestrado / Doutorado / PHD")]
        Associate = 3
    }
}