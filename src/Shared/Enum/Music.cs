using System.ComponentModel.DataAnnotations;

namespace VerusDate.Shared.Enum
{
    public enum Music
    {
        [Display(Name = "Pop")]
        Pop = 1,

        [Display(Name = "Rock")]
        Rock = 2,

        [Display(Name = "R&B / Soul")]
        RBSoul = 3,

        [Display(Name = "Rap / Hip Hop")]
        RapHipHop = 4,

        [Display(Name = "Metal")]
        Metal = 5,

        [Display(Name = "Jazz")]
        Jazz = 6,

        [Display(Name = "Reaggae")]
        Reaggae = 7,

        [Display(Name = "Dance")]
        Dance = 8,

        //[Display(Name = "MPB")]
        //Techno = 9,

        [Display(Name = "Música Eletrônica")]
        Electronic = 10,

        [Display(Name = "Música Latina")]
        Latin = 11,

        [Display(Name = "Música Sertaneja")]
        Country = 12,

        [Display(Name = "MPB")]
        Folk = 13, //música popular

        [Display(Name = "Blues")]
        Blues = 14,

        [Display(Name = "Paradas de Sucesso")]
        ChartMusic = 15,

        [Display(Name = "Música Clássica")]
        ClassicalMusic = 16,

        [Display(Name = "Música Alternativa")]
        Alternative = 17
    }
}