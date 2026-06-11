using CW21.Presentation.Entities.Tags;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CW21.Presentation.Data.Configurations.Tags
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
