using System.ComponentModel.DataAnnotations;

namespace VerusDate.Shared.Enum
{
    public enum EducationLevel
    {
        [Display(Name = "Superior incompleto ou menos")]
        HighSchool = 1,

        [Display(Name = "Tecnólogo / Bacharelado / Licenciatura")]
        College = 2,

        [Display(Name = "Mestrado / Douturado / PHD")]
        Associate = 3
    }
}