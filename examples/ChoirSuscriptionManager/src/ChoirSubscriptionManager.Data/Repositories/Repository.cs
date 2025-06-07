using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ChoirSubscriptionManager.Data.Context;
using ChoirSubscriptionManager.Data.Repositories.Interfaces;

namespace ChoirSubscriptionManager.Data.Repositories;

/// <summary>
/// Implementación base del repositorio genérico
/// Esta clase implementa todas las operaciones comunes para cualquier entidad
/// </summary>
public class Repository<T> : IRepository<T> where T : class
{
    protected readonly ChoirDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public Repository(ChoirDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    // Implementación de operaciones de consulta

    public virtual async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }

    public virtual async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.FirstOrDefaultAsync(predicate);
    }

    public virtual async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.AnyAsync(predicate);
    }

    public virtual async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.CountAsync(predicate);
    }

    // Implementación de operaciones de modificación

    public virtual async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public virtual async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    public virtual void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public virtual void UpdateRange(IEnumerable<T> entities)
    {
        _dbSet.UpdateRange(entities);
    }

    public virtual void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }

    public virtual void RemoveRange(IEnumerable<T> entities)
    {
        _dbSet.RemoveRange(entities);
    }

    public virtual async Task RemoveByIdAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            Remove(entity);
        }
    }
}
