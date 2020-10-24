using System.Collections.Generic;

namespace VerusDate.Shared.ViewModel
{
    public class GeoLocation
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Accuracy { get; set; }
    }

    /// <summary>
    /// OBS: O idioma dos textos recuperados é o mesmo da localização
    /// </summary>
    public class HereAddress
    {
        public string countryCode { get; set; }
        public string countryName { get; set; }
        public string state { get; set; }
        public string city { get; set; }
    }

    public class HereRoot
    {
        public HereAddress address { get; set; }
    }

    public class HereJson
    {
        public List<HereRoot> items { get; set; }
    }
}