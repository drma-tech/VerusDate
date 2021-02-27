using System.ComponentModel.DataAnnotations;

namespace VerusDate.Shared.Enum
{
    public enum Height
    {
        [Display(Name = "< 5.0 (< 152 cm)")]
        _150 = 150,

        [Display(Name = "5’0” (152 cm)")]
        _152 = 152,

        [Display(Name = "5’1” (155 cm)")]
        _155 = 155,

        [Display(Name = "5’2” (157 cm)")]
        _157 = 157,

        [Display(Name = "5’3” (160 cm)")]
        _160 = 160,

        [Display(Name = "5’4” (162 cm)")]
        _162 = 162,

        [Display(Name = "5’5” (165 cm)")]
        _165 = 165,

        [Display(Name = "5’6” (168 cm)")]
        _168 = 168,

        [Display(Name = "5’7” (170 cm)")]
        _170 = 170,

        [Display(Name = "5’8” (173 cm)")]
        _173 = 173,

        [Display(Name = "5’9” (175 cm)")]
        _175 = 175,

        [Display(Name = "5’10” (178 cm)")]
        _178 = 178,

        [Display(Name = "5,11” (180 cm)")]
        _180 = 180,

        [Display(Name = "6’0” (183 cm)")]
        _183 = 183,

        [Display(Name = "6’1” (185 cm)")]
        _185 = 185,

        [Display(Name = "6’2” (188 cm)")]
        _188 = 188,

        [Display(Name = "6’3” (190 cm)")]
        _190 = 190,

        [Display(Name = "> 6’3” (> 190 cm)")]
        _192 = 192,
    }
}