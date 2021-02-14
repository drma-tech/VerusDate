using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VerusDate.Api.Core.Interfaces;
using VerusDate.Api.Mediator.Behavior;
using VerusDate.Api.Mediator.Command.Profile;
using VerusDate.Api.Mediator.Command.Support;
using VerusDate.Api.Repository;
using VerusDate.Server.Core.Helper;

namespace VerusDate.Api.Core
{
    public static class StartupExtensions
    {
        public static void AddHandles(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ProfileAddHandler)); //needs only one class
        }

        public static void AddRepositories(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<IRepository>(func =>
            {
                return new CosmosRepository(config);
            });

            services.AddScoped(typeof(StorageHelper), typeof(StorageHelper));
            services.AddScoped(typeof(FaceHelper), typeof(FaceHelper));
        }

        public static void AddPipelines(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UserSessionBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }

        public static void AddValidations(this IServiceCollection services)
        {
            services.AddSingleton<IValidator<PrincipalAddCommand>, PrincipalAddCommandValidation>();
            services.AddSingleton<IValidator<ProfileAddCommand>, ProfileAddCommandValidation>();
            services.AddSingleton<IValidator<ProfileUpdateCommand>, ProfileUpdateCommandValidation>();
            services.AddSingleton<IValidator<ProfileUpdateLookingCommand>, ProfileUpdateLookingCommandValidation>();
            services.AddSingleton<IValidator<TicketInsertCommand>, TicketInsertCommandValidation>();
        }
    }
}