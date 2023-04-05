using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Common;
using Shop.Domain.Entities;

namespace Shop.Domain.Configuration
{
    internal class OrderItemBuilder : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.Metadata.SetSchema(SchemaDB.ORDER);

            builder.HasKey(orderItem => orderItem.Id);
        }
    }
}
