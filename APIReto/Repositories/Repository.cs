namespace APIReto.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    private readonly AppDbContext _context;
    private readonly DbSet<TEntity> _entities;

    public Repository(AppDbContext context)
    {
        _context = context;
        _entities = _context.Set<TEntity>();
    }

    public async virtual Task<TEntity> GetByIdAsync(Guid id)
    => await _entities.Where(entity => entity.Id == id).FirstOrDefaultAsync();

    public virtual ValueTask<EntityEntry<TEntity>> InsertAsync(TEntity entity)
     => _entities.AddAsync(entity);

    public virtual Task<int> SaveAsync()
    => _context.SaveChangesAsync();
}
