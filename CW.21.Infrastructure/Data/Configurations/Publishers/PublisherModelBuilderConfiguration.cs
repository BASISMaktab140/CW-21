using CW._21.Domain.Publishers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CW._21.Infrastructures.Data.Configurations.Publishers;

public class PublisherModelBuilderConfiguration : BaseModelBuilderConfiguration<Publisher>
{
    protected override void ApplyEntityConfiguration(EntityTypeBuilder<Publisher> modelBuilder)
    {
        modelBuilder
            .HasIndex(b => b.Name)
            .IsUnique();
        
        modelBuilder.Property(b => b.Name)
            .HasColumnType("nvarchar(100)")
            .IsRequired();

        modelBuilder.Property(p => p.City)
            .HasColumnType("nvarchar(50)");

        modelBuilder.Property(p => p.PhoneNumber)
            .HasColumnType("nvarchar(20)");
        
        
        modelBuilder.HasMany(p => p.Books)
            .WithOne(b => b.Publisher)
            .HasForeignKey(b => b.PublisherId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Property(b => b.CreatedAt)
            .HasDefaultValueSql("getdate()");
        
        //modelBuilder.HasData(SeedData.SeedData.Publishers);

    }
    
}