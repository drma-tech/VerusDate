using System.ComponentModel.DataAnnotations;

namespace VerusDate.Shared.Enum
{
    public enum Food
    {
        [Display(Name = "Italiana")]
        Italian = 1,

        [Display(Name = "Francesa")]
        French = 2,

        [Display(Name = "Alemã")]
        German = 3,

        [Display(Name = "Grega")]
        Greek = 4,

        [Display(Name = "Espanhola")]
        Spanish = 5,

        [Display(Name = "Oriental")]
        MiddleEastern = 6,

        [Display(Name = "Indiana")]
        Indian = 7,

        [Display(Name = "Chinesa")]
        Chinese = 8,

        [Display(Name = "Tailandesa")]
        Thai = 9,

        [Display(Name = "Vietnamita")]
        Vietnamese = 10,

        [Display(Name = "Japonesa")]
        Japanese = 11,

        [Display(Name = "Coreana")]
        Korean = 12,

        [Display(Name = "Cubana")]
        Cuban = 13,

        [Display(Name = "Porto-Riquenha")]
        PuertoRican = 14,

        [Display(Name = "Cozinha Sul Americana")]
        SouthAmericanCuisine = 15,

        [Display(Name = "Mexicana")]
        Mexican = 16,

        [Display(Name = "Africana")]
        AfricanAmerican = 17,

        [Display(Name = "Culinaria Mista")]
        Fusionkitchen = 18,

        [Display(Name = "Comida de Rua")]
        StreetFood = 19,

        [Display(Name = "Fast Food")]
        FastFood = 20,

        [Display(Name = "Comida Simples")]
        PlainFare = 21
    }
}