using CW._21.Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CW._21.Infrastructures.Data.Configurations.Orders;

public class OrderModelBuilderConfiguration : BaseModelBuilderConfiguration<Order>
{
    protected override void ApplyEntityConfiguration(EntityTypeBuilder<Order> modelBuilder)
    {


        modelBuilder.HasMany(o => o.OrderItems)
            .WithOne(oi => oi.Order)
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Property(o => o.TotalAmount)
            .HasColumnType("decimal(12,2)");
    }
}