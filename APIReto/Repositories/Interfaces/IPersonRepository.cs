namespace APIReto.Repositories.Interfaces;

public interface IPersonRepository : IRepository<Person>
{
    Task<IEnumerable<PersonDTO>> GetPersonsAsync(int? DNI, string Name, string City);
}
