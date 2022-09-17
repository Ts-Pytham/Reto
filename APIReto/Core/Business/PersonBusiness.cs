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

    public async Task<int> InsertPersonsAsync(IFormFile file)
    {
        if (!Path.GetExtension(file.FileName).Contains("xlsx")) return 0;
        var path = Path.GetTempPath() + Guid.NewGuid().ToString() + ".xlsx";
        try
        {  
            
            using (var stream = File.Create(path))
            {
                await file.CopyToAsync(stream);
            }

            SLDocument document = new(path);
            int iRow = 2;

        
            List<Person> list = new();
            while(!string.IsNullOrEmpty(document.GetCellValueAsString(iRow, 1)))
            {
                int DNI = document.GetCellValueAsInt32(iRow, 1);
                string Name = document.GetCellValueAsString(iRow, 2);
                string LastName = document.GetCellValueAsString(iRow, 3);
                string Address = document.GetCellValueAsString(iRow, 4);
                string City = document.GetCellValueAsString(iRow, 5);

                list.Add(new Person
                {
                    DNI = DNI,
                    Name = Name,
                    LastName = LastName,
                    Address = Address,
                    City = City
                });

                iRow++;
            }

            await _personRepository.InsertRangeAsync(list);
            await _personRepository.SaveAsync();

            return 1;

        }
        catch(Exception)
        {
            return 0;
        }
        finally
        {
            File.Delete(path);
        }
        
    }
}
