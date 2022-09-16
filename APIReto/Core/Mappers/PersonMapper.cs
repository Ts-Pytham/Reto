namespace APIReto.Core.Mappers;

public static class PersonMapper
{
    public static PersonDTO ToPersonDTO(this Person person)
    {
        var personDTO = new PersonDTO
        {
            Address = person.Address,
            City = person.City,
            DNI = person.DNI,
            FullName = $"{person.Name} {person.LastName}"
        };

        return personDTO;
    }
}
