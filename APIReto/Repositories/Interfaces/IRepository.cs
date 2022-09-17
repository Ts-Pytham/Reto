namespace APIReto.Repositories.Interfaces;

public interface IRepository<TEntity> where TEntity : Entity
{
    Task<TEntity> GetByIdAsync(long id);
    Task InsertRangeAsync(IEnumerable<TEntity> entity);
    Task<int> SaveAsync();
}
