namespace APIReto.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    private readonly AppDbContext _context;
    private readonly DbSet<TEntity> _entities;

    protected AppDbContext Context => _context;

    public Repository(AppDbContext context)
    {
        _context = context;
        _entities = _context.Set<TEntity>();
    }

    public async virtual Task<TEntity> GetByIdAsync(long id)
    => await _entities.Where(entity => entity.Id == id).FirstOrDefaultAsync();

    public virtual Task InsertRangeAsync(IEnumerable<TEntity> entity)
     => _entities.AddRangeAsync(entity);

    public virtual Task<int> SaveAsync()
    => _context.SaveChangesAsync();
}
