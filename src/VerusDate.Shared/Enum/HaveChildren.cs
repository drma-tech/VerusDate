using System.ComponentModel.DataAnnotations;

namespace VerusDate.Shared.Enum
{
    public enum HaveChildren
    {
        [Display(Name = "Não")]
        No = 1,

        [Display(Name = "Sim (não moram juntos)")]
        Yes_No = 2,

        [Display(Name = "Sim (moram juntos)")]
        Yes = 3
    }
}