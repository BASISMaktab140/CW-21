using CW._21.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CW._21.Infrastructures.Data.Configurations.Customers;

public class CustomerModelBuilderConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.HasMany(c => c.Orders)
            .WithOne(o => o.Customer)
            .HasForeignKey(o => o.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(c => c.Email)
            .IsUnique();

        builder.HasIndex(c => c.UserName)
            .IsUnique();

        builder.Property(c => c.PasswordHash)
            .HasColumnType("nvarchar(256)");
    }
}