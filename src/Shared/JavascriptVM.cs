using System.Collections.Generic;
using System.Linq;

namespace VerusDate.Shared
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
        public string county { get; set; }
        public string city { get; set; }

        /// <summary>
        /// Recupera a localização contendo as seguintes informaçoes: country, state, county, city
        /// <para>Caso county e city sejam iguais, só retornará um deles</para>
        /// </summary>
        /// <returns></returns>
        public string GetLocation()
        {
            var locations = new List<string>() { countryName, state };

            locations.AddRange(new[] { county, city }.Distinct());

            return string.Join(" - ", locations.Where(w => !string.IsNullOrEmpty(w)));
        }
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