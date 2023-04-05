using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Common;
using Shop.Domain.Entities;

namespace Shop.Domain.Configuration
{
    internal class OrderAddressBuilder : IEntityTypeConfiguration<OrderAddress>
    {
        public void Configure(EntityTypeBuilder<OrderAddress> builder)
        {
            builder.Metadata.SetSchema(SchemaDB.ORDER);
            builder.HasKey(orderAddress => orderAddress.Id);
        }
    }
}
