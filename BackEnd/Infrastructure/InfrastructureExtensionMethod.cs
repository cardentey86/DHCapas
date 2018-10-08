using AutoMapper;
using Core.Entities;
using Infrastructure.DAL;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public static class InfrastructureExtensionMethod
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddAutoMapper();

            //services.AddTransient<IPersonasRepository, PersonaRepository>();
            //services.AddTransient<PersonaService, PersonaService>();
            //services.AddTransient<UnitOfWork, UnitOfWork>();
            //services.AddTransient<IRepository<Persona>, GenericRepository<Persona>>();

            return services;
        }
    }
}
