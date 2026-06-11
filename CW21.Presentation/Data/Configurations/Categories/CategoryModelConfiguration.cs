using CW21.Presentation.Entities.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CW21.Presentation.Data.Configurations.Categories;

public class CategoryModelConfiguration : BaseModelBuilderConfiguration<Category>
{
    protected override void ApplyEntityConfiguration(EntityTypeBuilder<Category> modelBuilder)
    {
        modelBuilder.Property(c => c.Name)
            .IsRequired().
            HasColumnType("nvarchar(50)");

        modelBuilder
            .Property(c => c.Description)
            .HasColumnType("nvarchar(400)");
            

        modelBuilder
            .HasMany(c => c.Books)
            .WithOne(b => b.Category)
            .HasForeignKey(b => b.CategoryId);
        
        modelBuilder.HasData(SeedData.SeedData.Categories);
    }
}