namespace APIReto.Repositories;

public class PersonRepository : Repository<Person>, IPersonRepository
{
    public PersonRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<PersonDTO>> GetPersonsAsync(int? DNI, string Name, string City)
    {
        var filters = QueryFilter.True<Person>();

        if(DNI is not null)
        {
            filters.And(x => x.DNI == DNI);
        }

        if(Name is not null)
        {
            if(Name.Split(" ").Length > 1) // TO DO: Change it!
            {
                var names = Name.Split(" ");
                filters.And(x => x.Name == names[0] && x.LastName == names[1]);
            }
            else
            {
                filters.And(x => x.Name == Name || x.LastName == Name);
            }

        }

        if(City is not null)
        {
            filters.And(x => x.City == City);
        }

        var personsList = await Context.Set<Person>()
                                       .Where(filters)
                                       .Select(x => x.ToPersonDTO())
                                       .ToListAsync();
        return personsList;
    }
}
