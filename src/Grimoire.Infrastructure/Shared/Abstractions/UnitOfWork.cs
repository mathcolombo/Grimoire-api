using Grimoire.Domain.Shared.Abstractions.Interfaces;
using Grimoire.Infrastructure.Configs;
using Microsoft.EntityFrameworkCore.Storage;

namespace Grimoire.Infrastructure.Shared.Abstractions;

public class UnitOfWork(GrimoireDbContext context) : IUnitOfWork
{
    private IDbContextTransaction? _transaction;
    
    public async Task BeginTransactionAsync() => _transaction = await context.Database.BeginTransactionAsync();
    
    public async Task CommitAsync()
    {
        try
        {
            await context.SaveChangesAsync();
            await _transaction!.CommitAsync();
        }
        catch (Exception)
        {
            await _transaction!.RollbackAsync();
            throw;
        }
        finally
        {
            await _transaction!.DisposeAsync();
        }
    }
    
    public async Task RollbackAsync() => await _transaction?.RollbackAsync()!;
    
    public async Task SaveChangesAsync() => await context.SaveChangesAsync();
   
}