using System.ComponentModel.DataAnnotations;

namespace VerusDate.Shared.Enum
{
    public enum Distance
    {
        [Display(Name = "1 Km")]
        _1 = 1,

        [Display(Name = "2 Km")]
        _2 = 2,

        [Display(Name = "3 Km")]
        _3 = 3,

        [Display(Name = "4 Km")]
        _4 = 4,

        [Display(Name = "5 Km")]
        _5 = 5,

        [Display(Name = "10 Km")]
        _10 = 10,

        [Display(Name = "15 Km")]
        _15 = 15,

        [Display(Name = "20 Km")]
        _20 = 20,

        [Display(Name = "30 Km")]
        _30 = 30,

        [Display(Name = "40 Km")]
        _40 = 40,

        [Display(Name = "50 Km")]
        _50 = 50,

        [Display(Name = "Toda a cidade")]
        City = 99,

        [Display(Name = "Todo o país")]
        Country = 999
    }
}