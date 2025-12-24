using System.Linq.Expressions;

namespace Grimoire.Domain.Shared.Abstractions.Interfaces;

public interface IRepository<T> where T : class
{
    Task CreateAsync(T entity);
    Task CreateAsync(IEnumerable<T> entity);
    Task<T?> GetByIdAsync(int id);
    void Update(T entity);
    void Update(IEnumerable<T> entities);
    Task<int> DeleteAsync(Expression<Func<T, bool>> whereCondition);
    void Delete(T entity);
    void Delete(IEnumerable<T> entities);
    IQueryable<T> Query();
}