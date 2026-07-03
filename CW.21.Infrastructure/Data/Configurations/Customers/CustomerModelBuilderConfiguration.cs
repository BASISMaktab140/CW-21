using CW._21.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CW._21.Infrastructures.Data.Configurations.Customers;

public class CustomerModelBuilderConfiguration : BaseModelBuilderConfiguration<Customer>
{
    protected override void ApplyEntityConfiguration(EntityTypeBuilder<Customer> modelBuilder)
    {
        //modelBuilder.HasMany(c => c.Orders)
        //    .WithOne()
        //    .HasForeignKey(o => o.CustomerId)
        //    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.HasMany(c => c.Orders)
                 .WithOne(o => o.Customer)
                 .HasForeignKey(o => o.CustomerId)
                 .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.HasIndex(c => c.Email)
            .IsUnique();
        
        modelBuilder.HasIndex(c => c.Username)
            .IsUnique();
        
        modelBuilder.Property(c => c.PasswordHash)
            .HasColumnType("nvarchar(256)");
    }
}