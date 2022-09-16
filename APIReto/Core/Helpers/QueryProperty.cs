namespace igdPropiedadHorizontal.Application.Configuration.Pagination;

public class QueryProperty<T> where T : Entity
{
    public QueryProperty()
    {

    }

    public QueryProperty(int page, int pageCount)
    {
        page = page > 0 ? page : 1;
        pageCount = pageCount > 0 ? pageCount : 1;

        Skip = (page - 1) * pageCount;
        Take = pageCount;
    }

    public int Skip { get; set; }
    public int Take { get; set; }
    public Expression<Func<T, bool>> Where { get; set; }
    public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();
    public Expression<Func<T, object>> OrderBy { get; set; }
    public bool Decending { get; set; }


    public static IQueryable<T> ApplyQuery(QueryProperty<T> query, IQueryable<T> source)
    {
        if (query is null)
            return source;

        if (query.Where is not null)
            source = source.Where(query.Where);

        foreach (var property in query.Includes)
        {
            source = source.Include(property);
        }

        if (query.Skip > 0)
            source = source.Skip(query.Skip);

        if (query.Take > 0)
            source = source.Take(query.Take);

        return source;
    }
}
