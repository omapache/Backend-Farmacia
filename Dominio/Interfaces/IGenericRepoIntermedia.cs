

using System.Linq.Expressions;

namespace Dominio.Interfaces;

public interface IGenericRepoIntermedia<T> 
{
    Task<T> GetByIdAsync(int id, int id2);
    Task<IEnumerable<T>> GetAllAsync();
    IEnumerable<T> Find(Expression<Func<T, bool>> expression);
    void Add(T entity);
    void AddRange(IEnumerable<T> entities);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
    void Update(T entity);
}