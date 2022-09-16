namespace APIReto.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    
    public Task<TEntity> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void Insert(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task<int> SaveAsync()
    {
        throw new NotImplementedException();
    }
}
