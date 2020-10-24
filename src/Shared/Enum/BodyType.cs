using System.ComponentModel.DataAnnotations;

namespace VerusDate.Shared.Enum
{
    public enum BodyMass
    {
        [Display(Name = "Abaixo do peso")]
        UnderWeight = 1,

        [Display(Name = "Normal")]
        NormalWeight = 2,

        [Display(Name = "Atlético / Musculuso")]
        Athletic = 3,

        [Display(Name = "Acima do peso")]
        OverWeight = 4,

        [Display(Name = "Obeso")]
        Obese = 5,
    }
}