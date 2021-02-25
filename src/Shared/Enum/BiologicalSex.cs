using System.ComponentModel.DataAnnotations;

namespace VerusDate.Shared.Enum
{
    public enum BiologicalSex
    {
        [Display(Name = "Masculino", Description = "A pessoa que nasceu com o órgão sexual masculino ou o mudou cirurgicamente")]
        Male = 1,

        [Display(Name = "Feminino", Description = "A pessoa que nasceu com o órgão sexual feminino ou o mudou cirurgicamente")]
        Female = 2,

        [Display(Name = "Outro (Intersexo)", Description = "hermafrodita, pseudo-hermafrodita feminina, pseudo-hermafrodita masculino")]
        Other = 99
    }
}