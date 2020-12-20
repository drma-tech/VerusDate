using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace VerusDate.Api
{
    public static class Function1
    {
        [FunctionName("weather")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            //string name = req.Query["name"];

            var sb = new StringBuilder();

            sb.Append("[");
            sb.Append("{");
            sb.Append("  'date': '2018-05-06',");
            sb.Append("  'temperatureC': 1,");
            sb.Append("  'summary': 'Freezing'");
            sb.Append("},");
            sb.Append("{");
            sb.Append("  'date': '2018-05-07',");
            sb.Append("  'temperatureC': 14,");
            sb.Append("  'summary': 'Bracing'");
            sb.Append("},");
            sb.Append("]");

            dynamic data = JsonConvert.DeserializeObject(sb.ToString());

            return new OkObjectResult(data);
        }
    }
}