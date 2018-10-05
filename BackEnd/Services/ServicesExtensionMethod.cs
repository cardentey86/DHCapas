using AutoMapper;
using Infrastructure.DAL;
using Infrastructure.DAL.Interfaces;
using Infrastructure.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Services.Services.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public static class ServicesExtensionMethod
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddAutoMapper();

            services.AddTransient<IPersonasRepository, PersonaRepository>();
            services.AddTransient<PersonaService, PersonaService>();
            services.AddTransient<UnitOfWork, UnitOfWork>();

            return services;
        }

        //private static IServiceCollection AddRepositories(this IServiceCollection services, string connectionString)
        //{
        //    services.ConfigDatabase(connectionString);
        //    services.ConfigRepositories();
        //    return services;
        //}
    }
}
