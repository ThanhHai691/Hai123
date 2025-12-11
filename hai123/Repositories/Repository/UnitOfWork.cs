using System.Collections.Concurrent;
using hai123.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace hai123.Repositories.Repository;

public class UnitOfWork<TContext>(TContext context, IServiceProvider serviceProvider)
  :IUnitOfWork
where TContext : AppDbContext
{
  private readonly ConcurrentDictionary<Type, object> _repositories = new();
  private          IDbContextTransaction?             _transaction;

  public void Dispose()
  {
    _transaction?.Dispose();
    context?.Dispose();
    GC.SuppressFinalize(this);
  }

  public IRepository<T> Repository<T>() where T : class
  {
    return (IRepository<T>)_repositories.GetOrAdd(typeof(T), _ =>
    {
      var repo = serviceProvider.GetService(typeof(IRepository<T>));
      if (repo is null)
        throw new InvalidOperationException(
          $"No registered IRepository<{typeof(T).Name}> found. Register a repository or provide a factory in DI.");
      return repo!;
    });
  }

  public async Task<int> SaveChangesAsync()
  {
    return await context.SaveChangesAsync();
  }


  public async Task BeginTransactionAsync()
  {
    if (_transaction is not null) return;
    await context.Database.BeginTransactionAsync();
  }

  public async Task CommitTransactionAsync()
  {
    await context.SaveChangesAsync();
    await context.Database.CommitTransactionAsync();

    if (_transaction != null)
    {
      await _transaction.DisposeAsync();
      _transaction = null;
    }
  }

  public async Task RollbackTransactionAsync()
  {
    if (_transaction == null) return;
    await _transaction.RollbackAsync();
    await _transaction.DisposeAsync();
    _transaction = null;
  }
}