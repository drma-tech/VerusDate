using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Cosmos;
using System;
using System.Linq;
using System.Text.Json;

namespace VerusDate.Api.Core
{
    public class CosmosExceptionStructure
    {
        public string[] Errors { get; set; }
    }

    public static class ExceptionHelper
    {
        public static string ProcessException(this Exception ex)
        {
            if (ex is CosmosException cex)
            {
                //var result = JsonSerializer.Deserialize<CosmosExceptionStructure>(cex.ResponseBody);
                var result = JsonSerializer.Deserialize<CosmosExceptionStructure>("{" + cex.ResponseBody.Replace("Errors", "\"Errors\"") + "}", options: null);

                return result.Errors.FirstOrDefault();
            }
            else
            {
                return ex.Message;
            }
        }

        public static string BuildMessage(this IQueryCollection query)
        {
            return string.Join("", query.Select((s, index) => $"{{{index}}}"));
        }
    }
}