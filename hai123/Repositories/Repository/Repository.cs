using hai123.Data;


namespace hai123.Repositories.Repository;


public class Repository<T>(AppDbContext context) : IRepository<T>
    where T : class, IEntity
{
    public IQueryable<T> Query()
    {
        return context.Set<T>();
    }

    public Task<T> FindAsync(int T)
    {
        throw new NotImplementedException();
    }

    public bool Add(T entity)
    {
        throw new NotImplementedException();
    }

    public bool AddRange(List<T> entities)
    {
        throw new NotImplementedException();
    }

    public bool DeleteRange(List<T> entity)
    {
        throw new NotImplementedException();
    }

    public bool Update(T entity)
    {
        throw new NotImplementedException();
    }

    public bool UpdateRange(List<T> entities)
    {
        throw new NotImplementedException();
    }

    public bool Delete(T entity)
    {
        throw new NotImplementedException();
    }
}