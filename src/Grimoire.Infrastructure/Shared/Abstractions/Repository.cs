using System.Linq.Expressions;
using Grimoire.Domain.Shared.Abstractions.Interfaces;
using Grimoire.Infrastructure.Configs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Grimoire.Infrastructure.Shared.Abstractions;

public class Repository<T>(GrimoireDbContext context) : IRepository<T> where T : class
{
    private readonly GrimoireDbContext _context = context;
    private readonly DbSet<T> _dbSet = context.Set<T>();

    public async Task CreateAsync(T entity) => await _dbSet.AddAsync(entity);

    public async Task CreateAsync(IEnumerable<T> entities) => await _dbSet.AddRangeAsync(entities);
    
    public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

    public async Task<int> UpdateAsync(Expression<Func<T, bool>> whereCondition, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> setPropertyCalls) =>
        await _dbSet.Where(whereCondition).ExecuteUpdateAsync(setPropertyCalls);
    
    public void Update(T entity) => _dbSet.Update(entity);
    
    public void Update(IEnumerable<T> entities) => _dbSet.UpdateRange(entities);

    public async Task<int> DeleteAsync(Expression<Func<T, bool>> whereCondition) => await _dbSet.Where(whereCondition).ExecuteDeleteAsync();
    
    public void Delete(T entity) => _dbSet.Remove(entity);
    
    public void Delete(IEnumerable<T> entities) => _dbSet.RemoveRange(entities);
    
    public IQueryable<T> Query() => _dbSet.AsNoTracking();
}