using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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
            var config = builder.GetContext().Configuration;

            //web não aceita status NoContent
            builder.Services.AddMvcCore().AddMvcOptions(options =>
            {
                options.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();
            });

            builder.Services.AddHandles();
            builder.Services.AddRepositories(config);
            builder.Services.AddPipelines();
            builder.Services.AddValidations();

            //services.AddTransient<IEmailSender, EmailHelper>();
            //services.Configure<AuthMessageSenderOptions>(options =>
            //{
            //    options.SendGridUser = Configuration.GetValue<string>("Authentication:Sendgrid:SendGridUser");
            //    options.SendGridKey = Configuration.GetValue<string>("Authentication:Sendgrid:SendGridKey");
            //});

            builder.Services.AddLogging(logging =>
            {
                logging.AddProvider(new CosmosLoggerProvider(new LoggerConfiguration(), new Repository.CosmosLogRepository(config)));
                //logging.AddAzureWebAppDiagnostics();
            });
        }
    }
}