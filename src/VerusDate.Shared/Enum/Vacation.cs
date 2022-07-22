using VerusDate.Shared.Core;

namespace VerusDate.Shared.Enum
{
    /// <summary>
    /// https://simplicable.com/en/vacations
    /// </summary>
    public enum Vacation
    {
        [Custom(Name = "AdventureTours_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        AdventureTours,

        [Custom(Name = "Agriculture_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        Agriculture,

        [Custom(Name = "Animals_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        Animals,

        [Custom(Name = "ArtTourism_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        ArtTourism,

        [Custom(Name = "Backpacking_Name", Description = "Backpacking_Description", ResourceType = typeof(Resources.Enum.Vacation))]
        Backpacking,

        [Custom(Name = "Beach_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        Beach,

        [Custom(Name = "BoatTours_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        BoatTours,

        [Custom(Name = "BusTours_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        BusTours,

        [Custom(Name = "CampingGlamping_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        CampingGlamping,

        [Custom(Name = "CityBreak_Name", Description = "CityBreak_Description", ResourceType = typeof(Resources.Enum.Vacation))]
        CityBreak,

        [Custom(Name = "Classes_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        Classes,

        [Custom(Name = "ClimbingMountaineering_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        ClimbingMountaineering,

        [Custom(Name = "Concerts_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        Concerts,

        [Custom(Name = "Conferences_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        Conferences,

        [Custom(Name = "Cottages_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        Cottages,

        [Custom(Name = "CouchSurfing_Name", Description = "CouchSurfing_Description", ResourceType = typeof(Resources.Enum.Vacation))]
        CouchSurfing,

        [Custom(Name = "CreativeWork_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        CreativeWork,

        [Custom(Name = "CruiseHolidays_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        CruiseHolidays,

        [Custom(Name = "CulturalTourism_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        CulturalTourism,

        [Custom(Name = "CyclingTour_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        CyclingTour,

        [Custom(Name = "DivingSnorkeling_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        DivingSnorkeling,

        [Custom(Name = "DIYProjects_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        DIYProjects,

        [Custom(Name = "FamilyVisits_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        FamilyVisits,

        [Custom(Name = "FilmTourism_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        FilmTourism,

        [Custom(Name = "Fishing_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        Fishing,

        [Custom(Name = "FitnessVacations_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        FitnessVacations,

        [Custom(Name = "Golf_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        Golf,

        [Custom(Name = "Gourmet_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        Gourmet,

        [Custom(Name = "HighCulture_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        HighCulture,

        [Custom(Name = "Hiking_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        Hiking,

        [Custom(Name = "HistoricalSites_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        HistoricalSites,

        [Custom(Name = "Hobbies_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        Hobbies,

        [Custom(Name = "HomeImprovement_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        HomeImprovement,

        [Custom(Name = "Homecoming_Name", Description = "Homecoming_Description", ResourceType = typeof(Resources.Enum.Vacation))]
        Homecoming,

        [Custom(Name = "HomeSwap_Name", Description = "HomeSwap_Description", ResourceType = typeof(Resources.Enum.Vacation))]
        HomeSwap,

        [Custom(Name = "HorseRiding_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        HorseRiding,

        [Custom(Name = "InternationalTravel_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        InternationalTravel,

        [Custom(Name = "JustStayingHome_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        JustStayingHome,

        [Custom(Name = "LuxuryTravel_Name", Description = "LuxuryTravel_Description", ResourceType = typeof(Resources.Enum.Vacation))]
        LuxuryTravel,

        [Custom(Name = "MotorSports_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        MotorSports,

        [Custom(Name = "MountainsLakes_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        MountainsLakes,

        [Custom(Name = "MusicEventsFestivals_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        MusicEventsFestivals,

        [Custom(Name = "NatureNationalParks_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        NatureNationalParks,

        [Custom(Name = "Nightlife_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        Nightlife,

        [Custom(Name = "Photography_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        Photography,

        [Custom(Name = "PopCulture_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        PopCulture,

        [Custom(Name = "RVRoadTrips_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        RVRoadTrips,

        [Custom(Name = "RelaxingWellness_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        RelaxingWellness,

        [Custom(Name = "ReligionSpirituality_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        ReligionSpirituality,

        [Custom(Name = "Resorts_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        Resorts,

        [Custom(Name = "Retreats_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        Retreats,

        [Custom(Name = "Reunions_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        Reunions,

        [Custom(Name = "Romantic_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        Romantic,

        [Custom(Name = "Safaris_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        Safaris,

        [Custom(Name = "Sailing_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        Sailing,

        [Custom(Name = "Science_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        Science,

        [Custom(Name = "Shopping_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        Shopping,

        [Custom(Name = "SightseeingGuidedTours_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        SightseeingGuidedTours,

        [Custom(Name = "SnowboardSki_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        SnowboardSki,

        [Custom(Name = "SoloTravel_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        SoloTravel,

        [Custom(Name = "SportsEvents_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        SportsEvents,

        [Custom(Name = "Stargazing_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        Stargazing,

        [Custom(Name = "ThemeParks_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        ThemeParks,

        [Custom(Name = "TrainTravel_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        TrainTravel,

        [Custom(Name = "Volunteering_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        Volunteering,

        [Custom(Name = "Working_Name", Description = "Working_Description", ResourceType = typeof(Resources.Enum.Vacation))]
        Working,
    }

    public enum HolidaysOld
    {
        [Custom(Name = "BeachWaterSports_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        BeachWaterSports = 1,

        [Custom(Name = "VisitingFamousLandmarks_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        VisitingFamousLandmarks = 2,

        [Custom(Name = "ExploringExoticAdventurousPlaces_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        ExploringExoticAdventurousPlaces = 3,

        [Custom(Name = "JustStayingHome_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        JustStayingHome = 4,

        [Custom(Name = "VisitingFamily_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        VisitingFamily = 5,

        [Custom(Name = "OutdoorSportingActivities_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        OutdoorSportingActivities = 6,

        [Custom(Name = "RelaxingWellness_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        RelaxingWellness = 7,

        [Custom(Name = "Backpacking_Name", Description = "Backpacking_Description", ResourceType = typeof(Resources.Enum.Vacation))]
        Backpacking = 8,

        [Custom(Name = "CruiseHolidays_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        CruiseHolidays = 9,

        [Custom(Name = "CityBreak_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        CityBreak = 10,

        [Custom(Name = "CountrysideBreak_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        CountrysideBreak = 11,

        [Custom(Name = "LakesMountains_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        LakesMountains = 12,

        [Custom(Name = "MusicEventsFestivals_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        MusicEventsFestivals = 13,

        [Custom(Name = "HomeSwap_Name", Description = "HomeSwap_Description", ResourceType = typeof(Resources.Enum.Vacation))]
        HomeSwap = 14,

        [Custom(Name = "CouchSurfing_Name", Description = "CouchSurfing_Description", ResourceType = typeof(Resources.Enum.Vacation))]
        CouchSurfing = 15,

        [Custom(Name = "Camping_Name", Description = "Camping_Description", ResourceType = typeof(Resources.Enum.Vacation))]
        Camping = 16,

        [Custom(Name = "RoadTtrips_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        RoadTtrips = 17,

        [Custom(Name = "Safaris_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        Safaris = 18,

        [Custom(Name = "TrainJourneys_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        TrainJourneys = 19,

        [Custom(Name = "SportHolidays_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        SportHolidays = 20,

        [Custom(Name = "AdultOnlyHolidays_Name", ResourceType = typeof(Resources.Enum.Vacation))]
        AdultOnlyHolidays = 21,
    }
}