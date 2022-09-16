namespace APIReto.Repositories;

public class PersonRepository : Repository<Person>, IPersonRepository
{
    public PersonRepository(AppDbContext context) : base(context)
    {
    }

    public Task<IEnumerable<PersonDto>> GetPersonsAsync(PersonDto personDto)
    {
        throw new NotImplementedException();
    }
}
