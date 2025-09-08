using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;


namespace Resume.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // MediatR
            services.AddMediatR(typeof(ApplicationAssemblyMarker).Assembly);

            // FluentValidation (optional if you use it)
            // services.AddValidatorsFromAssembly(typeof(ApplicationAssemblyMarker).Assembly);

            // Add other app-level services if needed
            // services.AddScoped<IMyService, MyService>();

            return services;
        }
    }
}
