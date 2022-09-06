using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using VerusDate.Api.Core;
using VerusDate.Shared;

namespace VerusDate.Api.Function
{
    public class ExternalFunction
    {
        public string HereApiKey { get; set; }

        public ExternalFunction(IConfiguration config)
        {
            HereApiKey = config.GetValue<string>("Here_ApiKey");
        }

        [FunctionName("ExternalGetLocation")]
        [OpenApiOperation(operationId: "Run", tags: new[] { "name" })]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiParameter(name: "name", In = ParameterLocation.Query, Required = true, Type = typeof(string), Description = "The **Name** parameter")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Description = "The OK response")]
        public async Task<IActionResult> GetLocation(
           [HttpTrigger(AuthorizationLevel.Function, FunctionMethod.GET, Route = "External/GetLocation")] HttpRequest req,
           ILogger log, CancellationToken cancellationToken)
        {
            using var source = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, req.HttpContext.RequestAborted);

            try
            {
                var latitude = req.Query["latitude"];
                var longitude = req.Query["longitude"];

                var http = new HttpClient();

                var response = await http.GetAsync($"https://browse.search.hereapi.com/v1/browse?at={latitude},{longitude}&limit=1&apiKey={HereApiKey}", source.Token);

                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadAsAsync<HereJson>(source.Token);

                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                log.LogError(ex, req.Query.BuildMessage(), req.Query.ToList());
                return new BadRequestObjectResult(ex.ProcessException());
            }
        }
    }
}