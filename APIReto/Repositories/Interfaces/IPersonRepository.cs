namespace APIReto.Repositories.Interfaces;

public interface IPersonRepository : IRepository<Person>
{
    Task<IEnumerable<PersonDto>> GetPersonsAsync(PersonDto personDto);
}
