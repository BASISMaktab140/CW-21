using System.Linq.Expressions;
using CW21.Presentation.Data;
using CW21.Presentation.Entities;
using Microsoft.EntityFrameworkCore;

namespace CW21.Presentation.Repositories.Generics;

public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly AppDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    protected GenericRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);

        if(entity == null)
            return;
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<TEntity?> GetByIdAsync(int id, bool tracking = false)
    {
        var query = _dbSet.AsQueryable<TEntity>();

        if(tracking)
            query = query.AsTracking();
        return await query.FirstOrDefaultAsync(e => e.Id == id);
    }

    public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>>? predicate = null)
    {
        IQueryable<TEntity> query = _dbSet;

        if (predicate != null)
            query = query.Where(predicate);
        return query;
    }
    
}