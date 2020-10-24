using System.ComponentModel.DataAnnotations;

namespace VerusDate.Shared.Enum
{
    public enum Smoke
    {
        [Display(Name = "Não")]
        No = 1,

        [Display(Name = "Sim, ocasionalmente")]
        Yes_Occasionally = 2,

        [Display(Name = "Sim, frequentemente")]
        Yes_Often = 3
    }
}