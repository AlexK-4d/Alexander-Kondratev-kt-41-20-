﻿using AlexandrKondratevKt4120.Interfaces.DisciplineInterfaces;

namespace AlexandrKondratevKt4120.ServiceExtensions
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
