using System.ComponentModel.DataAnnotations;

namespace VerusDate.Shared.Enum
{
    public enum Drink
    {
        [Display(Name = "Não", Description = "Não consome nenhum tipo de bebida alcoólica")]
        No = 1,

        [Display(Name = "Sim, socialmente", Description = "É a pessoa que bebe raramente e/ou apenas em ocasiões sociais, não ultrapassando duas vezes ao mês")]
        Yes_Light = 2,

        [Display(Name = "Sim, moderadamente", Description = "É a pessoa que bebe aproximadamente uma vez por semana, podendo chegar a seis vezes ao mês")]
        Yes_Moderate = 3,

        [Display(Name = "Sim, frequentemente", Description = "É a pessoa que bebe pelo menos duas vezes por semana")]
        Yes_Heavy = 4
    }
}