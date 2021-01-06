using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using VerusDate.Shared.ModelQuery;
using VerusDate.Web.Core;

namespace VerusDate.Web.Api
{
    public static class PublicApi
    {
        public async static Task<List<ProfileSearch>> Public_ListDestaques(this HttpClient http)
        {
            return await http.GetList<ProfileSearch>($"Public/ListDestaques");
        }
    }
}