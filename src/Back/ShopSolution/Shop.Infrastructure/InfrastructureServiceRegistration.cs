using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Models;
using Shop.Application.Persistence;
using Shop.Infrastructure.Repositories;
using Shop.Infrastructure.Services.ImageService;

namespace Shop.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServiceRegistartion(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.Configure<JWTSetting>(configuration.GetSection("JWTSetting"));
            services.Configure<CloudinarySetting>(configuration.GetSection("CloudinarySetting"));

            return services;
        }
    }
}
