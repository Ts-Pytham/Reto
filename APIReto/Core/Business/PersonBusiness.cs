namespace APIReto.Core.Business;

public class PersonBusiness : IPersonBusiness
{
    private readonly IPersonRepository _personRepository;

    public PersonBusiness(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task<IEnumerable<PersonDTO>> GetPersonsAsync(int? DNI, string Name, string City)
    {
        return await _personRepository.GetPersonsAsync(DNI, Name, City);
    }
}
