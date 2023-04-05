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


    // Product
    public DbSet<Product> Products { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Review> Reviews { get; set; }
    // ShoppingCart
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    // Order
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<OrderAddress> OrderAddresses { get; set; }
    // User
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Country> Countries { get; set; }



    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        ColumnTypeConvention.Convert(configurationBuilder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
