using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Linq;
using VerusDate.Server.App;
using VerusDate.Server.Core;
using VerusDate.Server.Core.Helper;
using VerusDate.Server.Core.Interface;
using VerusDate.Server.Data;
using VerusDate.Server.Data.Repository;
using VerusDate.Server.Mediator.Behavior;
using VerusDate.Server.Mediator.Queries.Gamification;
using VerusDate.Server.Models;
using VerusDate.Shared.Interface.App;

namespace VerusDate.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //EF CORE
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SQL")).LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
            );

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityServer(opt =>
            {
                opt.IssuerUri = Configuration.GetValue<string>("RootPath"); //necessário para funcionar no ambiente linux
            })
            .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

            services.AddAuthentication()
                .AddIdentityServerJwt();

            //força a não gerar erro com valores null
            services.AddControllers(options =>
            {
                options.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();
            });

            services.AddAuthentication()
                .AddGoogle(options =>
                {
                    options.ClientId = Configuration.GetValue<string>("Authentication_Google_ClientId");
                    options.ClientSecret = Configuration.GetValue<string>("Authentication_Google_ClientSecret");
                })
                .AddFacebook(options =>
                {
                    options.AppId = Configuration.GetValue<string>("Authentication_Facebook_AppId");
                    options.AppSecret = Configuration.GetValue<string>("Authentication_Facebook_AppSecret");
                });

            services.AddScoped<IRepository, RepositoryDapper>();
            services.AddScoped<StorageHelper>();

            services.AddScoped<IGamificationApp, GamificationApp>();

            services.AddMediatR(typeof(GamificationGetHandler)); //needs only one class

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UserSessionBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            services.AddSignalR();

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Verus Date",
                    Version = "v1",
                    Description = "Documentação da api do Verus Date"
                });

                c.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Scheme = "bearer"
                });

                // add auth header for [Authorize] endpoints
                c.OperationFilter<AddAuthHeaderOperationFilter>();

                c.IncludeXmlComments(Path.Combine(System.AppContext.BaseDirectory, "VerusDate.Server.xml"));
            });

            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/octet-stream" });
            });

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

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseResponseCompression();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Verus Date API V1");
            });

            app.UseIdentityServer();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                //endpoints.MapHub<ChatHub>("/chathub");
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}