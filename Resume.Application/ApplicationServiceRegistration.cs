using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;


namespace Resume.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddMediatR(assembly);

            return services;

        }
    }
}
