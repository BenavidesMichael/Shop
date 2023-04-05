using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities;

namespace Shop.Infrastructure.Configuration
{
    internal class ProductBuilder : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(product => product.Id);

            builder.Property(product => product.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(product => product.Description)
                   .IsRequired()
                   .HasDefaultValue("No description")
                   .HasMaxLength(4000);

            builder.Property(product => product.Price)
                     .IsRequired()
                     .HasColumnType("decimal(10,2)");
        }
    }
}
