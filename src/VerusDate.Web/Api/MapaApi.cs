using System;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using VerusDate.Shared;

namespace VerusDate.Web.Api
{
    public static class MapApi
    {
        public async static Task<HereJson> Map_GetLocation(this HttpClient http, double Latitude, double Longitude)
        {
            if (Latitude == 0) throw new ArgumentNullException(nameof(Latitude));
            if (Longitude == 0) throw new ArgumentNullException(nameof(Longitude));

            //return await http.GetCustom<HereJson>($"Map/GetLocation/{Latitude}/{Longitude}");
            return await http.GetFromJsonAsync<HereJson>($"https://browse.search.hereapi.com/v1/browse?at={Latitude.ToString(CultureInfo.InvariantCulture)},{Longitude.ToString(CultureInfo.InvariantCulture)}&limit=1&apiKey=pF1CJDET40JGtCu-hoMqX2WL934-vki1uNE_CPPW4KQ");
        }
    }
}