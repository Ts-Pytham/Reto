namespace APIReto.Repositories.Interfaces;

public interface IRepository<TEntity> where TEntity : Entity
{
    Task<TEntity> GetByIdAsync(long id);
    ValueTask<EntityEntry<TEntity>> InsertAsync(TEntity entity);
    Task<int> SaveAsync();
}
