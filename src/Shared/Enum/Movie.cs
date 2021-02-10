using System.ComponentModel.DataAnnotations;

namespace VerusDate.Shared.Enum
{
    public enum Movie
    {
        [Display(Name = "Ação")]
        Action = 1,

        [Display(Name = "Aventura")]
        Adventure = 2,

        [Display(Name = "Animação")]
        Animation = 3,

        [Display(Name = "Biografia")]
        Biography = 4,

        [Display(Name = "Comédia")]
        Comedy = 5,

        [Display(Name = "Crime")]
        Crime = 6,

        [Display(Name = "Drama")]
        Drama = 7,

        [Display(Name = "Fantasia")]
        Fantasy = 8,

        [Display(Name = "Filme-Noir")]
        FilmNoir = 9,

        [Display(Name = "História")]
        History = 10,

        [Display(Name = "Terror")]
        Horror = 11,

        [Display(Name = "Musical")]
        Musical = 12,

        [Display(Name = "Ficção Científica")]
        SciFi = 13,

        [Display(Name = "Romance")]
        Romance = 14,

        [Display(Name = "Mistério")]
        Mystery = 15,

        [Display(Name = "Guerra")]
        War = 16,

        [Display(Name = "Faroeste")]
        Western = 17,

        [Display(Name = "Suspense")]
        Thriller = 18,

        [Display(Name = "Reality Show")]
        RealityTV = 19,

        [Display(Name = "Documentário")]
        Documentary = 20,

        [Display(Name = "Esporte")]
        Sport = 21,

        [Display(Name = "Talk show")]
        TalkShow = 22,

        [Display(Name = "Bollywood")]
        Bollywood = 23
    }
}