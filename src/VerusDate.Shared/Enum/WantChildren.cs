using System.ComponentModel.DataAnnotations;

namespace VerusDate.Shared.Enum
{
    public enum WantChildren
    {
        [Display(Name = "Não")]
        No = 1,

        [Display(Name = "Talvez / Provavelmente")]
        Maybe = 2,

        [Display(Name = "Sim")]
        Yes = 3
    }
}