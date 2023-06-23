using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Contracts.Identity;
using Shop.Application.Contracts.Infrastructure;
using Shop.Application.Contracts.User;
using Shop.Application.Models.AppSettings;
using Shop.Application.Persistence;
using Shop.Infrastructure.Repositories;
using Shop.Infrastructure.Services.Auth;
using Shop.Infrastructure.Services.Email;
using Shop.Infrastructure.Services.ImageService;
using Shop.Infrastructure.Services.User;

namespace Shop.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServiceRegistartion(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddServices();
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

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IImageManageService, ImageManageService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUserService, UserService>();
            return services;
        }
    }
}
