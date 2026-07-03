using CW._21.Domain.OrderItems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CW._21.Infrastructures.Data.Configurations.OrderItems;

public class OrderItemModelBuilderConfiguration : BaseModelBuilderConfiguration<OrderItem>
{
    protected override void ApplyEntityConfiguration(EntityTypeBuilder<OrderItem> modelBuilder)
    {

        //modelBuilder.HasOne(o => o.Book)
        //    .WithOne()
        //    .HasForeignKey<OrderItem>(o => o.BookId)
        //    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.HasOne(oi => oi.Book)
              .WithMany(b => b.OrderItems)
              .HasForeignKey(oi => oi.BookId)
              .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Property(o => o.UnitPrice)
            .HasColumnType("decimal(12,2)");
    }
}