using System.Linq.Expressions;

namespace ChoirSubscriptionManager.Data.Repositories.Interfaces;

/// <summary>
/// Interfaz genérica para repositorios
/// Define las operaciones básicas que puede hacer cualquier repositorio
/// T = el tipo de entidad (Member, Subscription, Payment, etc.)
/// </summary>
public interface IRepository<T> where T : class
{
    // Operaciones de consulta (Lectura)
    
    /// <summary>
    /// Obtener una entidad por su ID
    /// </summary>
    Task<T?> GetByIdAsync(int id);

    /// <summary>
    /// Obtener todas las entidades
    /// </summary>
    Task<IEnumerable<T>> GetAllAsync();

    /// <summary>
    /// Buscar entidades que cumplan una condición
    /// </summary>
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

    /// <summary>
    /// Buscar la primera entidad que cumpla una condición
    /// </summary>
    Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

    /// <summary>
    /// Verificar si existe alguna entidad que cumpla una condición
    /// </summary>
    Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);

    /// <summary>
    /// Contar cuántas entidades cumplen una condición
    /// </summary>
    Task<int> CountAsync(Expression<Func<T, bool>> predicate);

    // Operaciones de modificación (Escritura)
    
    /// <summary>
    /// Agregar una nueva entidad
    /// </summary>
    Task AddAsync(T entity);

    /// <summary>
    /// Agregar múltiples entidades
    /// </summary>
    Task AddRangeAsync(IEnumerable<T> entities);

    /// <summary>
    /// Actualizar una entidad existente
    /// </summary>
    void Update(T entity);

    /// <summary>
    /// Actualizar múltiples entidades
    /// </summary>
    void UpdateRange(IEnumerable<T> entities);

    /// <summary>
    /// Eliminar una entidad
    /// </summary>
    void Remove(T entity);

    /// <summary>
    /// Eliminar múltiples entidades
    /// </summary>
    void RemoveRange(IEnumerable<T> entities);

    /// <summary>
    /// Eliminar una entidad por su ID
    /// </summary>
    Task RemoveByIdAsync(int id);
}
