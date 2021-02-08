using System.ComponentModel.DataAnnotations;

namespace VerusDate.Shared.Enum
{
    public enum Drink
    {
        [Display(Name = "Não", Description = "Não consome nenhum tipo de bebida alcoólica")]
        No = 1,

        [Display(Name = "Sim, socialmente", Description = "É a pessoa que bebe 3 drinks por semana ou menos.")]
        Yes_Light = 2,

        [Display(Name = "Sim, moderadamente", Description = "É a pessoa que bebe 3 a 14 drinks por semana para os homens e 3 a 7 drinks para as mulheres ou idosos.")]
        Yes_Moderate = 3,

        [Display(Name = "Sim, frequentemente", Description = "É a pessoa que bebe mais que 14 drinks por semana para os homens ou mais que 7 drinks para as mulheres ou idosos.")]
        Yes_Heavy = 4
    }
}