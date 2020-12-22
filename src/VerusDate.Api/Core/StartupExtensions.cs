using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using VerusDate.Api.Mediator.Behavior;
using VerusDate.Api.Mediator.Command.Profile;
using VerusDate.Shared.Validation;

namespace VerusDate.Api.Core
{
    public static class StartupExtensions
    {
        public static void AddHandles(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly()); //needs only one class
        }

        public static void AddPipelines(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UserSessionBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }

        public static void AddValidations(this IServiceCollection services)
        {
            services.AddSingleton<IValidator<ProfileAddCommand>, ProfileAddCommandValidation>();
        }
    }
}