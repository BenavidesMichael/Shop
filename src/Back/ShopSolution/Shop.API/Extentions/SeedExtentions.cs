using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using Shop.Infrastructure.Context;

namespace Shop.API.Extentions
{
    public static class SeedExtentions
    {
        public static async Task AddSeed(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
            var loggerFactory = services.GetRequiredService<ILoggerFactory>();

            try
            {
                var shopDbContext = services.GetRequiredService<ShopDbContext>();
                var userManager = services.GetRequiredService<UserManager<User>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

                await shopDbContext.Database.MigrateAsync();
                await DataSeed.LoadDataAsync(shopDbContext, userManager, roleManager, loggerFactory);
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError("Error Migration", ex.Message);
            }
        }
    }
}
