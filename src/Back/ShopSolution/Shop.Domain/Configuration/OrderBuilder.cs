using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities;

namespace Shop.Domain.Configuration
{
    internal class OrderBuilder : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(order => order.Id);

            // 1-1 relationship with Address
            builder.OwnsOne(order => order.OrderAddress, shippingAddress =>
            {
                shippingAddress.WithOwner();
            });


            builder.HasMany(order => order.OrderItems)
                   .WithOne(orderItem => orderItem.Order)
                   .HasForeignKey(orderItem => orderItem.OrderId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
