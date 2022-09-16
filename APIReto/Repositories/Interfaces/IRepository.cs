namespace APIReto.Repositories.Interfaces;

public interface IRepository<TEntity> where TEntity : Entity
{
    Task<TEntity> GetByIdAsync(int id);
    void Insert(TEntity entity);
    Task<int> SaveAsync();
}
