using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities;

namespace Shop.Infrastructure.Configuration
{
    internal class ReviewBuilder : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(review => review.Id);

            builder.Property(review => review.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(review => review.Name)
                   .IsRequired()
                   .HasMaxLength(4000);
        }
    }
}
