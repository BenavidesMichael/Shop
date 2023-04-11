using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Common;
using Shop.Domain.Entities;

namespace Shop.Domain.Configuration
{
    internal class ShoppingCartBuilder : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.ToTable("ShoppingCarts", SchemaDB.BASKET);

            builder.HasKey(shoppingCart => shoppingCart.Id);

            builder.HasMany(shoppingCart => shoppingCart.ShoppingCartItems)
                   .WithOne(shoppingCartItem => shoppingCartItem.ShoppingCart)
                   .HasForeignKey(shoppingCartItem => shoppingCartItem.ShoppingCartId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
