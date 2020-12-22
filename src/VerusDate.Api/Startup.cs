using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using VerusDate.Api.Core;

[assembly: FunctionsStartup(typeof(VerusDate.Api.Startup))]

namespace VerusDate.Api
{
    internal class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddCosmosRepository();

            builder.Services.AddHandles();
            builder.Services.AddPipelines();
            builder.Services.AddValidations();
        }
    }
}