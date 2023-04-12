using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities;

namespace Shop.Domain.Configuration
{
    internal class ShoppingCartBuilder : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> builder)
        {
            builder.HasKey(shoppingCart => shoppingCart.Id);

            builder.HasMany(shoppingCart => shoppingCart.ShoppingCartItems)
                   .WithOne(shoppingCartItem => shoppingCartItem.ShoppingCart)
                   .HasForeignKey(shoppingCartItem => shoppingCartItem.ShoppingCartId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
