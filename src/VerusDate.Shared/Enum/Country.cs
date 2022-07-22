using VerusDate.Shared.Core;

namespace VerusDate.Shared.Enum
{
    /// <summary>
    /// https://en.wikipedia.org/wiki/List_of_countries_and_dependencies_by_population
    /// https://en.wikipedia.org/wiki/ISO_3166-1
    /// </summary>
    public enum Country
    {
        [Custom(Group = "Asia", Name = "China")]
        CHN = 156,

        [Custom(Group = "Asia", Name = "India")]
        IND = 356,

        [Custom(Group = "Americas", Name = "United States")]
        USA = 840,

        [Custom(Group = "Asia", Name = "Indonesia")]
        IDN = 360,

        [Custom(Group = "Asia", Name = "Pakistan")]
        PAK = 586,

        [Custom(Group = "Africa", Name = "Nigeria")]
        NGA = 566,

        [Custom(Group = "Americas", Name = "Brazil")]
        BRA = 076,

        [Custom(Group = "Asia", Name = "Bangladesh")]
        BGD = 050,

        [Custom(Group = "Europe", Name = "Russia")]
        RUS = 643,

        [Custom(Group = "Americas", Name = "Mexico")]
        MEX = 484,

        [Custom(Group = "Americas", Name = "Japan")]
        JPN = 392,

        [Custom(Group = "Americas", Name = "Ethiopia")]
        ETH = 231,

        [Custom(Group = "Americas", Name = "Philippines")]
        PHL = 608,

        [Custom(Group = "Americas", Name = "Egypt")]
        EGY = 818,

        [Custom(Group = "Americas", Name = "Vietnam")]
        VNM = 704,

        [Custom(Group = "Americas", Name = "DR Congo")]
        COD = 180,

        [Custom(Group = "Americas", Name = "Iran")]
        IRN = 364,

        [Custom(Group = "Americas", Name = "Turkey")]
        TUR = 792,

        [Custom(Group = "Americas", Name = "Germany")]
        DEU = 276,

        [Custom(Group = "Americas", Name = "France")]
        FRA = 250,

        [Custom(Group = "Americas", Name = "United Kingdom")]
        GBR = 826,

        [Custom(Group = "Americas", Name = "Thailand")]
        THA = 764,

        [Custom(Group = "Americas", Name = "South Africa")]
        ZAF = 710,

        [Custom(Group = "Americas", Name = "Tanzania")]
        TZA = 834,

        [Custom(Group = "Americas", Name = "Italy")]
        ITA = 380,

        [Custom(Group = "Americas", Name = "Myanmar")]
        MMR = 104,

        [Custom(Group = "Americas", Name = "South Korea")]
        KOR = 410,

        [Custom(Group = "Americas", Name = "Colombia")]
        COL = 170,

        [Custom(Group = "Americas", Name = "Kenya")]
        KEN = 404,

        [Custom(Group = "Americas", Name = "Spain")]
        ESP = 724,

        [Custom(Group = "Americas", Name = "Argentina")]
        ARG = 032,

        [Custom(Group = "Africa", Name = "Algeria")]
        DZA = 012,

        [Custom(Group = "Africa", Name = "Sudan")]
        SDN = 729,

        [Custom(Group = "Africa", Name = "Uganda")]
        UGA = 800,

        [Custom(Group = "Asia", Name = "Iraq")]
        IRQ = 368,

        [Custom(Group = "Europe", Name = "Ukraine")]
        UKR = 804,

        [Custom(Group = "Americas", Name = "Canada")]
        CAN = 124,

        [Custom(Group = "Europe", Name = "Poland")]
        POL = 616,

        [Custom(Group = "Africa", Name = "Morocco")]
        MAR = 504,

        [Custom(Group = "Asia", Name = "Uzbekistan")]
        UZB = 860,

        [Custom(Group = "Asia", Name = "Saudi Arabia")]
        SAU = 682,

        [Custom(Group = "Americas", Name = "Peru")]
        PER = 604,

        [Custom(Group = "Africa", Name = "Angola")]
        AGO = 024,

        [Custom(Group = "Asia", Name = "Afghanistan")]
        AFG = 004,

        [Custom(Group = "Asia", Name = "Malaysia")]
        MYS = 458,

        [Custom(Group = "Africa", Name = "Mozambique")]
        MOZ = 508,

        [Custom(Group = "Africa", Name = "Ghana")]
        GHA = 288,

        [Custom(Group = "Asia", Name = "Yemen")]
        YEM = 887,

        [Custom(Group = "Asia", Name = "Nepal")]
        NPL = 524,

        [Custom(Group = "Americas", Name = "Venezuela")]
        VEN = 862,

        [Custom(Group = "Africa", Name = "Ivory Coast")]
        CIV = 384,

        [Custom(Group = "Africa", Name = "Madagascar")]
        MDG = 450,

        [Custom(Group = "Oceania", Name = "Australia")]
        AUS = 036,

        [Custom(Group = "Asia", Name = "North Korea")]
        PRK = 408,

        [Custom(Group = "Africa", Name = "Cameroon")]
        CMR = 120,

        [Custom(Group = "Africa", Name = "Niger")]
        NER = 562,

        [Custom(Group = "Asia", Name = "Taiwan")]
        TWN = 158,

        [Custom(Group = "Asia", Name = "Sri Lanka")]
        LKA = 144,

        [Custom(Group = "Africa", Name = "Burkina Faso")]
        BFA = 854,

        [Custom(Group = "Africa", Name = "Malawi")]
        MWI = 454,

        [Custom(Group = "Africa", Name = "Mali")]
        MLI = 466,

        [Custom(Group = "Americas", Name = "Chile")]
        CHL = 152,

        [Custom(Group = "Asia", Name = "Kazakhstan")]
        KAZ = 398,

        [Custom(Group = "Europe", Name = "Romania")]
        ROU = 642,

        [Custom(Group = "Africa", Name = "Zambia")]
        ZMB = 894,

        [Custom(Group = "Asia", Name = "Syria")]
        SYR = 760,

        [Custom(Group = "Americas", Name = "Ecuador")]
        ECU = 218,

        [Custom(Group = "Europe", Name = "Netherlands")]
        NLD = 528,

        [Custom(Group = "Africa", Name = "Senegal")]
        SEN = 686,

        [Custom(Group = "Americas", Name = "Guatemala")]
        GTM = 320,

        [Custom(Group = "Africa", Name = "Chad")]
        TCD = 148,

        [Custom(Group = "Africa", Name = "Somalia")]
        SOM = 706,

        [Custom(Group = "Africa", Name = "Zimbabwe")]
        ZWE = 716,

        [Custom(Group = "Asia", Name = "Cambodia")]
        KHM = 116,

        [Custom(Group = "Africa", Name = "South Sudan")]
        SSD = 728,

        [Custom(Group = "Africa", Name = "Rwanda")]
        RWA = 646,

        [Custom(Group = "Africa", Name = "Guinea")]
        GIN = 324,

        [Custom(Group = "Africa", Name = "Burundi")]
        BDI = 108,

        [Custom(Group = "Africa", Name = "Benin")]
        BEN = 204,

        [Custom(Group = "Americas", Name = "Bolivia")]
        BOL = 068,

        [Custom(Group = "Africa", Name = "Tunisia")]
        TUN = 788,

        [Custom(Group = "Americas", Name = "Haiti")]
        HTI = 332,

        [Custom(Group = "Europe", Name = "Belgium")]
        BEL = 056,

        [Custom(Group = "Asia", Name = "Jordan")]
        JOR = 400,

        [Custom(Group = "Americas", Name = "Cuba")]
        CUB = 192,

        [Custom(Group = "Europe", Name = "Greece")]
        GRC = 300,

        [Custom(Group = "Americas", Name = "Dominican Republic")]
        DOM = 214,

        [Custom(Group = "Europe", Name = "Czech Republic")]
        CZE = 203,

        [Custom(Group = "Europe", Name = "Sweden")]
        SWE = 752,

        [Custom(Group = "Europe", Name = "Portugal")]
        PRT = 620,

        [Custom(Group = "Asia", Name = "Azerbaijan")]
        AZE = 031,

        [Custom(Group = "Europe", Name = "Hungary")]
        HUN = 348,

        [Custom(Group = "Americas", Name = "Honduras")]
        HND = 340,

        [Custom(Group = "Asia", Name = "Israel")]
        ISR = 376,

        [Custom(Group = "Asia", Name = "Tajikistan")]
        TJK = 762,

        [Custom(Group = "Europe", Name = "Belarus")]
        BLR = 112,

        [Custom(Group = "Asia", Name = "United Arab Emirates")]
        ARE = 784,

        [Custom(Group = "Oceania", Name = "Papua New Guinea")]
        PNG = 598,

        [Custom(Group = "Europe", Name = "Austria")]
        AUT = 040,

        [Custom(Group = "Europe", Name = "Switzerland")]
        CHE = 756,

        [Custom(Group = "Africa", Name = "Sierra Leone")]
        SLE = 694,

        [Custom(Group = "Africa", Name = "Togo")]
        TGO = 768,

        [Custom(Group = "Asia", Name = "Hong Kong")]
        HKG = 344,

        [Custom(Group = "Americas", Name = "Paraguay")]
        PRY = 600
    }
}