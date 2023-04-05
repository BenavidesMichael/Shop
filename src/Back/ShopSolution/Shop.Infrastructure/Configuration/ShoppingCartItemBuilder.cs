using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities;

namespace Shop.Infrastructure.Configuration
{
    internal class ShoppingCartItemBuilder : IEntityTypeConfiguration<ShoppingCartItem>
    {
        public void Configure(EntityTypeBuilder<ShoppingCartItem> builder)
        {
            builder.HasKey(shoppingCartItem => shoppingCartItem.Id);

            builder.Property(shoppingCartItem => shoppingCartItem.Product).IsRequired();
            builder.Property(shoppingCartItem => shoppingCartItem.Quantity).IsRequired();

            builder.Property(shoppingCartItem => shoppingCartItem.Price)
                    .IsRequired()
                    .HasColumnType("decimal(10,2)");
        }
    }
}
