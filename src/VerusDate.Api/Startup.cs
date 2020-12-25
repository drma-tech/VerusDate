using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VerusDate.Api.Core;

[assembly: FunctionsStartup(typeof(VerusDate.Api.Startup))]

namespace VerusDate.Api
{
    internal class Startup : FunctionsStartup
    {
        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        //public static IConfiguration Configuration { get; private set; }

        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddCosmosRepository();

            builder.Services.AddHandles();
            builder.Services.AddPipelines();
            builder.Services.AddValidations();

            //services.AddTransient<IEmailSender, EmailHelper>();
            //services.Configure<AuthMessageSenderOptions>(options =>
            //{
            //    options.SendGridUser = Configuration.GetValue<string>("Authentication:Sendgrid:SendGridUser");
            //    options.SendGridKey = Configuration.GetValue<string>("Authentication:Sendgrid:SendGridKey");
            //});

            //services.AddLogging(options =>
            //{
            //    options.ClearProviders();
            //    options.AddAzureWebAppDiagnostics();
            //});
        }
    }
}