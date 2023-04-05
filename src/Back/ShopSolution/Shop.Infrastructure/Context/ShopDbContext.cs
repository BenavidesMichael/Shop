using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using Shop.Infrastructure.Conventions;
using System.Reflection;

namespace Shop.Infrastructure.Context;

internal class ShopDbContext : IdentityDbContext<User>
{
    public ShopDbContext(DbContextOptions<ShopDbContext> opt)
        : base(opt) { }


    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        DateTimeConvention.Convert(configurationBuilder);
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
