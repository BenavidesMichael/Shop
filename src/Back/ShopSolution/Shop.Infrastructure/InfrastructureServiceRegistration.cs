﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Models;
using Shop.Application.Models.Images;
using Shop.Application.Models.Mail;
using Shop.Application.Persistence;
using Shop.Infrastructure.Repositories;

namespace Shop.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServiceRegistartion(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddSettings(configuration);
            return services;
        }

        private static IServiceCollection AddSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JWTSetting>(configuration.GetSection("JWTSetting"));
            services.Configure<CloudinarySetting>(configuration.GetSection("CloudinarySetting"));
            services.Configure<SendGridSetting>(configuration.GetSection("SendGridSetting"));
            return services;
        }
    }
}
