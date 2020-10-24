using System.ComponentModel.DataAnnotations;

namespace VerusDate.Shared.Enum
{
    public enum BiologicalSex
    {
        [Display(Name = "Masculino")]
        Male = 1,

        [Display(Name = "Feminino")]
        Female = 2,

        [Display(Name = "Outro (Intersexo)", Description = "hermafrodita, pseudo-hermafrodita feminina, pseudo-hermafrodita masculino")]
        Other = 99
    }
}