﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Common;
using Shop.Domain.Entities;
using Shop.Infrastructure.Conventions;
using System.Reflection;

namespace Shop.Infrastructure.Context;

public class ShopDbContext : IdentityDbContext<ApplicationUser>
{
    public ShopDbContext(DbContextOptions<ShopDbContext> opt)
        : base(opt)
    {
    }

    // Product
    public DbSet<Product>? Products { get; set; }
    public DbSet<Image>? Images { get; set; }
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Review>? Reviews { get; set; }
    // ShoppingCart
    public DbSet<ShoppingCart>? ShoppingCarts { get; set; }
    public DbSet<ShoppingCartItem>? ShoppingCartItems { get; set; }
    // Order
    public DbSet<Order>? Orders { get; set; }
    public DbSet<OrderItem>? OrderItems { get; set; }
    public DbSet<OrderAddress>? OrderAddresses { get; set; }
    // User
    public DbSet<Address>? Addresses { get; set; }
    public DbSet<Country>? Countries { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        var userName = "System";

        foreach (var entry in ChangeTracker.Entries<BaseDomain>().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = DateTime.Now;
                    entry.Entity.CreatedBy = userName;
                    break;

                case EntityState.Modified:
                    entry.Entity.LastModifiedDate = DateTime.Now;
                    entry.Entity.CreatedBy = userName;
                    break;

                default:
                    throw new NotImplementedException();
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Convert();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        builder.Entity<Product>().ToTable(nameof(Products), SchemaDB.PRODUCT);
        builder.Entity<Image>().ToTable(nameof(Images), SchemaDB.PRODUCT);
        builder.Entity<Category>().ToTable(nameof(Categories), SchemaDB.PRODUCT);
        builder.Entity<Review>().ToTable(nameof(Reviews), SchemaDB.PRODUCT);

        builder.Entity<ShoppingCart>().ToTable(nameof(ShoppingCarts), SchemaDB.BASKET);
        builder.Entity<ShoppingCartItem>().ToTable(nameof(ShoppingCartItems), SchemaDB.BASKET);

        builder.Entity<Order>().ToTable(nameof(Orders), SchemaDB.ORDER);
        builder.Entity<OrderItem>().ToTable(nameof(OrderItems), SchemaDB.ORDER);
        builder.Entity<OrderAddress>().ToTable(nameof(OrderAddresses), SchemaDB.ORDER);
    }
}
