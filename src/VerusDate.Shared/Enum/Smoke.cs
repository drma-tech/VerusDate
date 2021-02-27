using System.ComponentModel.DataAnnotations;

namespace VerusDate.Shared.Enum
{
    public enum Smoke
    {
        [Display(Name = "Não")]
        No = 1,

        [Display(Name = "Sim, socialmente")]
        Yes_Occasionally = 2,

        [Display(Name = "Sim, diariamente")]
        Yes_Often = 3
    }
}