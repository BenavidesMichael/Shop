using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Context;

namespace Shop.API.Extentions
{
    public static class DataBaseExtentions
    {
        public static IServiceCollection AddDataBase(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<ShopDbContext>(options
                  => options.UseSqlServer(
                        Configuration.GetConnectionString("ShopDemo"),
                        b => b.MigrationsAssembly(typeof(ShopDbContext).Assembly.FullName))
            );

            return services;
        }
    }
}
