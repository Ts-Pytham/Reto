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
        var filters = QueryFilter.True<Person>();

        if (DNI is not null)
        {
            filters = filters.And(x => x.DNI == DNI);
        }

        if (Name is not null)
        {
            if (Name.Split(" ").Length > 1) // TO DO: Change it!
            {
                var names = Name.Split(" ");
                filters = filters.And(x => x.Name == names[0] && x.LastName == names[1]);
            }
            else
            {
                filters = filters.And(x => x.Name == Name || x.LastName == Name);
            }
        }

        if (City is not null)
        {
            filters = filters.And(x => x.City == City);
        }

        return await _personRepository.GetPersonsAsync(filters);
    }
}
