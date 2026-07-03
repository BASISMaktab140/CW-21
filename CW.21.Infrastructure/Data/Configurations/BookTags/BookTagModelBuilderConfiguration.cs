using CW._21.Domain.BookTags;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CW._21.Infrastructures.Data.Configurations.BookTags;

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

        // modelBuilder.HasData(SeedData.SeedData.BookTags);
    }
}