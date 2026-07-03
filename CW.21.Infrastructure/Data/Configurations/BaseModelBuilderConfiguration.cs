using Cw._21.Abstraction;
using CW._21.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CW._21.Infrastructures.Data.Configurations;

public abstract class BaseModelBuilderConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
{
    public void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(x => x.Id);
        
        ApplyEntityConfiguration(builder);
    }

    protected abstract void ApplyEntityConfiguration(EntityTypeBuilder<TEntity> modelBuilder);
}