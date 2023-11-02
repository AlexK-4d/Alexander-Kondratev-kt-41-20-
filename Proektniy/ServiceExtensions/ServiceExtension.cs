using Proektniy.Interfaces.DisciplineInterfaces;

namespace Proektniy.ServiceExtensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {

            services.AddScoped<IDisciplineService, DisciplineServices>();

            return services;
        }
    }
}
