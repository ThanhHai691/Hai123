namespace hai123.Repositories.Repository;

public interface IRepository<T> where T : class
{
    IQueryable<T> Query();
    Task<T>       FindAsync(int T);
    bool          Add(T entity);
    bool          AddRange(List<T> entities);
    bool          DeleteRange(List<T> entity);
    bool          Update(T entity);
    bool          UpdateRange(List<T> entities);
    bool          Delete(T entity);
}