namespace APIReto.Repositories.Interfaces;

public interface IPersonRepository : IRepository<Person>
{
    Task<IEnumerable<PersonDTO>> GetPersonsAsync(Expression<Func<Person, bool>> filters);
}
