using CW._21.Domain.Tags;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CW._21.Infrastructures.Data.Configurations.Tags
{
    public class TagsModelBuilderConfiguration : BaseModelBuilderConfiguration<Tag>
    {
        protected override void ApplyEntityConfiguration(EntityTypeBuilder<Tag> modelBuilder)
        {
            modelBuilder.Property(t => t.Name)
                .HasColumnType("nvarchar(50)")
                .IsRequired();

            modelBuilder.HasIndex(t => t.Name)
                .IsUnique();

        }
    }
}
