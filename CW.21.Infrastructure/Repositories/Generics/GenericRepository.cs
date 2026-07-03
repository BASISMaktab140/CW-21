using System.Linq.Expressions;
using Cw._21.Abstraction;
using CW._21.Domain;
using CW._21.Domain.Generics;
using CW._21.Infrastructures.Data;
using Microsoft.EntityFrameworkCore;

namespace CW._21.Infrastructures.Repositories.Generics;

public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly AppDbContext Context;
    protected readonly DbSet<TEntity> DbSet;

    protected GenericRepository(AppDbContext context)
    {
        Context = context;
        DbSet = context.Set<TEntity>();
    }
    public IQueryable<TEntity> GetAllQueryable(Expression<Func<TEntity, bool>>? predicate = null)
    {
        IQueryable<TEntity> query = DbSet;

        if (predicate != null)
            query = query.Where(predicate);
        return query;
    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null)
    {
        IQueryable<TEntity> query = DbSet;

        if (predicate != null)
            query = query.Where(predicate);
        return await query.ToListAsync();
    }
   
    public async Task<TEntity?> GetByIdAsync(int id, bool tracking = false)
    {
        var query = DbSet.AsQueryable<TEntity>();

        if(tracking)
            query = query.AsTracking();
        return await query.FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task AddAsync(TEntity entity)
    {
        await DbSet.AddAsync(entity);
        await SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        DbSet.Update(entity);
        await SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await DbSet.FindAsync(id);

        if(entity == null)
            return;
        DbSet.Remove(entity);
        await SaveChangesAsync();
    }

    public async Task<int> SaveChangesAsync()
    {
       return await Context.SaveChangesAsync();
    }
}