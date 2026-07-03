using CW._21.Domain.Authors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CW._21.Infrastructures.Data.Configurations.Authors;

public class AuthorModelBuilderConfiguration : BaseModelBuilderConfiguration<Author>
{
    protected override void ApplyEntityConfiguration(EntityTypeBuilder<Author> modelBuilder)
    {
        modelBuilder.Property(u => u.FullName)
            .IsRequired()
            .HasColumnType("nvarchar(100)");

        modelBuilder.Property(u => u.BirthYear)
            .HasColumnType("int");

        modelBuilder.Property(u => u.Country)
            .IsRequired();

        modelBuilder
            .HasMany(a => a.Books)
            .WithOne(b => b.Author)
            .HasForeignKey(b => b.AuthorId);

        //modelBuilder.HasData(SeedData.SeedData.Authors);
    }
}