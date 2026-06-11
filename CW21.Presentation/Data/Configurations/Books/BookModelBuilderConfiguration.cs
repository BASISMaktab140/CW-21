using CW21.Presentation.Entities.Books;
using CW21.Presentation.Entities.BookTags;
using CW21.Presentation.Entities.Tags;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CW21.Presentation.Data.Configurations.Books;

public class BookModelBuilderConfiguration : BaseModelBuilderConfiguration<Book>
{
    protected override void ApplyEntityConfiguration(EntityTypeBuilder<Book> modelBuilder)
    {
        modelBuilder.Property(b => b.Title)
            .HasColumnType("nvarchar(100)")
            .IsRequired();

        // 12.2D
        modelBuilder.Property(b => b.Price)
            .IsRequired()
            .HasColumnType("decimal(12,2)")
            .HasDefaultValue(0);

        //TODO
        modelBuilder.Property(b => b.PublishYear)
            .IsRequired()
            .HasColumnType("int");

        modelBuilder.Property(b => b.CreatedAt)
            .IsRequired()
            .HasColumnType("datetime2");

        modelBuilder.HasIndex(b => b.AuthorId);

        modelBuilder.HasIndex(b => b.CategoryId);

        modelBuilder.HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.HasOne(b => b.Category)
            .WithMany(c => c.Books)
            .HasForeignKey(b => b.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder
            .HasOne(b => b.Publisher)
            .WithMany(p => p.Books)
            .HasForeignKey(b => b.PublisherId)
            .OnDelete(DeleteBehavior.Restrict);


      modelBuilder.HasData(SeedData.SeedData.Books);


    }
}