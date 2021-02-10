using System.ComponentModel.DataAnnotations;

namespace VerusDate.Shared.Enum
{
    public enum BodyMass
    {
        [Display(Name = "Magro (a)")]
        UnderWeight = 1,

        [Display(Name = "Normal")]
        NormalWeight = 2,

        [Display(Name = "Atlético (a) / Musculuso (a)")]
        Athletic = 3,

        [Display(Name = "Pouco acima do peso / Com curvas")]
        OverWeight = 4,

        [Display(Name = "Acima do peso / Obeso (a)")]
        Obese = 5,
    }
}