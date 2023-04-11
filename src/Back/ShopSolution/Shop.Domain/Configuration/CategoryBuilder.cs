using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Common;
using Shop.Domain.Entities;

namespace Shop.Domain.Configuration
{
    internal class CategoryBuilder : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories", SchemaDB.PRODUCT);

            builder.HasKey(category => category.Id);

            builder.Property(category => category.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasMany(category => category.Products)
                   .WithOne(product => product.Category)
                   .HasForeignKey(product => product.CategoryId)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
