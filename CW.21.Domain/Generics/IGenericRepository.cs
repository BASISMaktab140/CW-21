using System.Linq.Expressions;

namespace CW._21.Domain.Generics;

public interface IGenericRepository<TEntity> where TEntity : BaseEntity
{
    /// <summary>
    /// Add an entity
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task AddAsync(TEntity entity);

    /// <summary>
    /// Update an Entity
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task UpdateAsync(TEntity entity);

    /// <summary>
    /// Hard-deletes a record
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task DeleteAsync(int id);

    /// <summary>
    /// Finds an entity by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="tracking"></param>
    /// <returns></returns>
    Task<TEntity?> GetByIdAsync(int id, bool tracking = false);

    /// <summary>
    /// Gets all records based on a condition
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    IQueryable<TEntity> GetAllQueryable(Expression<Func<TEntity, bool>>? predicate = null);
    
    Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null);

    Task<int> SaveChangesAsync();
}