using System.Net;
using System.Xml.Linq;

namespace APIReto.Repositories;

public class PersonRepository : Repository<Person>, IPersonRepository
{
    public PersonRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<PersonDTO>> GetPersonsAsync(Expression<Func<Person, bool>> filters)
    {
        
        var personList = await Context.Set<Person>()
                               .Where(filters)
                               .Select(p => p.ToPersonDTO())
                               .ToListAsync();

        return personList;
    }

}
