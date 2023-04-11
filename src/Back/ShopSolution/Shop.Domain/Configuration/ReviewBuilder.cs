﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Common;
using Shop.Domain.Entities;

namespace Shop.Domain.Configuration
{
    internal class ReviewBuilder : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("Reviews", SchemaDB.PRODUCT);

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
