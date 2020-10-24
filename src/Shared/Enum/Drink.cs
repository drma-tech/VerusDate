using System.ComponentModel.DataAnnotations;

namespace VerusDate.Shared.Enum
{
    public enum Drink
    {
        [Display(Name = "Não")]
        No = 1,

        [Display(Name = "Sim, socialmente")]
        Yes_Socially = 2,

        [Display(Name = "Sim, frequentemente")]
        Yes_Often = 3
    }
}