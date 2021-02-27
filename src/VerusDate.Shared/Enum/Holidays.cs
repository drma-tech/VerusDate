using System.ComponentModel.DataAnnotations;

namespace VerusDate.Shared.Enum
{
    public enum Holidays
    {
        [Display(Name = "Praia / Esportes aquáticos")]
        BeachWaterSports = 1,

        [Display(Name = "Visitar atrações turísticas famosas")]
        VisitingFamousLandmarks = 2,

        [Display(Name = "Explorar lugares exóticos e aventureiros")]
        ExploringExoticAdventurousPlaces = 3,

        [Display(Name = "Apenas ficar em casa")]
        JustStayingHome = 4,

        [Display(Name = "Visitar família")]
        VisitingFamily = 5,

        [Display(Name = "Atividades esportivas ao ar livre")]
        OutdoorSportingActivities = 6,

        [Display(Name = "Relaxar / Bem estar")]
        RelaxingWellness = 7,

        [Display(Name = "Mochilão", Description = "É a recreação ao ar livre de carregar coisas pessoais nas costas, enquanto caminha por mais de um dia. Freqüentemente, mas nem sempre, é uma viagem longa e pode ou não envolver acampar ao ar livre.")]
        Backpacking = 8,

        [Display(Name = "Cruzeiro de férias")]
        CruiseHolidays = 9,

        [Display(Name = "Passeio pela cidade")]
        CityBreak = 10,

        [Display(Name = "Férias no campo")]
        CountrysideBreak = 11,

        [Display(Name = "Lagos / Montanhas")]
        LakesMountains = 12,

        [Display(Name = "Eventos / Festivais de música")]
        MusicEventsFestivals = 13,

        [Display(Name = "Home Swap", Description = "Um arranjo em que duas famílias trocam de casas nas férias")]
        HomeSwap = 14,

        [Display(Name = "Couch Surfing", Description = "A prática de viajar e ficar hospedadas na casa de pessoas que você não conhece, que anunciam suas casas na internet")]
        CouchSurfing = 15,

        [Display(Name = "Camping", Description = "Um local com acomodações temporárias de cabanas, tendas ou outras estruturas, normalmente usadas por soldados, refugiados, prisioneiros ou viajantes")]
        Camping = 16,

        [Display(Name = "Viagens de carro / trailer")]
        RoadTtrips = 17,

        [Display(Name = "Safári")]
        Safaris = 18,

        [Display(Name = "Viagens de trem")]
        TrainJourneys = 19,

        [Display(Name = "Férias esportivas")]
        SportHolidays = 20,

        [Display(Name = "Férias apenas para adultos")]
        AdultOnlyHolidays = 21,
    }
}