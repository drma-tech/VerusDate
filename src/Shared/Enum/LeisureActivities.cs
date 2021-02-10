using System.ComponentModel.DataAnnotations;

namespace VerusDate.Shared.Enum
{
    public enum LeisureActivities
    {
        [Display(Name = "Esportes")]
        Sports = 1,

        [Display(Name = "Musica")]
        Music = 2,

        [Display(Name = "Leitura")]
        Reading = 3,

        [Display(Name = "Computadores / Internet")]
        ComputersInternet = 4,

        [Display(Name = "eSports")]
        eSports = 5,

        [Display(Name = "Jogos de Carta / Tabuleiro")]
        Games = 6,

        [Display(Name = "Museus / Exposições")]
        MuseumsExhibitions = 7,

        [Display(Name = "Teatro / Ópera / Cinema")]
        TheatreCabaretOperaCinema = 8,

        [Display(Name = "Astrologia")]
        Astrology = 9,

        [Display(Name = "Astronomia")]
        Astronomy = 10,

        [Display(Name = "Cozinhar")]
        Cooking = 11,

        //[Display(Name = "Baking")]
        //Baking = 12,

        [Display(Name = "Carros / Motos")]
        CarsMotorcycles = 13,

        [Display(Name = "TV / Filmes")]
        TVFilms = 14,

        [Display(Name = "Viajar")]
        Travelling = 15,

        [Display(Name = "Desenho / Pintura")]
        DrawingPainting = 16,

        [Display(Name = "Colecionar")]
        Collecting = 17,

        [Display(Name = "Escrita Criativa / Poesia")]
        CreativeWritingPoetry = 18,

        [Display(Name = "Genealogia")]
        Genealogy = 19,

        [Display(Name = "Trico / Costura / Bordado")]
        KnittingSewingPatchworking = 20,

        [Display(Name = "Serralharia / Mercearia")]
        MetalWoodWork = 21,

        [Display(Name = "Modelismo")]
        ModelBuilding = 22,

        [Display(Name = "Fotografia")]
        Photography = 23,

        [Display(Name = "Projetos Faça Você Mesmo")]
        DIY = 24,

        [Display(Name = "Moda")]
        Fashion = 25,

        [Display(Name = "Aprendizado de Idiomas")]
        LanguageLearning = 26,

        [Display(Name = "Caligrafia")]
        Calligraphy = 27,

        [Display(Name = "Radio Amador")]
        AmateurRadio = 28,

        [Display(Name = "Artes e Artesanato")]
        Crafts = 29
    }
}