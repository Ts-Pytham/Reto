namespace APIReto.Core.Interfaces;

public interface IPersonBusiness
{
    public Task<IEnumerable<PersonDTO>> GetPersonsAsync(int? DNI, string Name, string City);

    public Task<int> InsertPersonsAsync(IFormFile file);
}
