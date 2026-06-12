using CW21.Presentation.Data.Configurations;
using CW21.Presentation.Entities.BookTags;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CW21.Presentation.Data.Configurations.BookTags
{
    public class BookTagModelBuilderConfiguration : BaseModelBuilderConfiguration<BookTag>
    {
        protected override void ApplyEntityConfiguration(EntityTypeBuilder<BookTag> modelBuilder)
        {
            

            modelBuilder
            .HasOne(bt => bt.Book)
            .WithMany(b => b.BookTags)
            .HasForeignKey(bt => bt.BookId);

            modelBuilder
            .HasOne(bt => bt.Tag)
            .WithMany(t => t.BookTags)
            .HasForeignKey(bt => bt.TagId);

            modelBuilder.HasData(SeedData.SeedData.BookTags);

        }
    }
}
