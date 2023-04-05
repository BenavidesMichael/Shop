using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Common;
using Shop.Domain.Entities;

namespace Shop.Domain.Configuration
{
    internal class ProductBuilder : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Metadata.SetSchema(SchemaDB.PRODUCT);

            builder.HasKey(product => product.Id);

            builder.Property(product => product.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(product => product.Description)
                   .IsRequired()
                   .HasDefaultValue("No description")
                   .HasMaxLength(4000);

            builder.HasMany(product => product.Reviews)
                 .WithOne(review => review.Product)
                 .HasForeignKey(review => review.ProductId)
                 .IsRequired()
                 .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(product => product.Images)
                   .WithOne(review => review.Product)
                   .HasForeignKey(review => review.ProductId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
