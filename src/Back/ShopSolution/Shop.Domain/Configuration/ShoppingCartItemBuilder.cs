using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities;

namespace Shop.Domain.Configuration
{
    internal class ShoppingCartItemBuilder : IEntityTypeConfiguration<ShoppingCartItem>
    {
        public void Configure(EntityTypeBuilder<ShoppingCartItem> builder)
        {
            builder.HasKey(shoppingCartItem => shoppingCartItem.Id);

            builder.Property(shoppingCartItem => shoppingCartItem.Product).IsRequired();
            builder.Property(shoppingCartItem => shoppingCartItem.Quantity).IsRequired();
        }
    }
}
