using Blazored.SessionStorage;
using System;
using System.Globalization;
using System.Net.Http;
using System.Threading.Tasks;
using VerusDate.Shared;
using VerusDate.Web.Core;

namespace VerusDate.Web.Api
{
    public static class MapApi
    {
        public async static Task<HereJson> Map_GetLocation(this HttpClient http, ISyncSessionStorageService storage, double Latitude, double Longitude)
        {
            if (Latitude == 0) throw new ArgumentNullException(nameof(Latitude));
            if (Longitude == 0) throw new ArgumentNullException(nameof(Longitude));

            return await http.Get<HereJson>($"External/GetLocation?latitude={Latitude.ToString(CultureInfo.InvariantCulture)}&longitude={Longitude.ToString(CultureInfo.InvariantCulture)}", storage);
        }
    }
}