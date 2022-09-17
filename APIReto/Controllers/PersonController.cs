namespace APIReto.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class PersonController : ControllerBase
{
    private readonly IPersonBusiness _personBusiness;

	public PersonController(IPersonBusiness personBusiness)
	{
		_personBusiness = personBusiness;
	}

	[HttpGet]
	public async Task<ActionResult<IEnumerable<PersonDTO>>> GetPersons(int? DNI, string Name, string City)
	{
		var result = await _personBusiness.GetPersonsAsync(DNI, Name, City);

		if (result.Any())
		{
			return Ok(result);
		}
		return NotFound();

	}

    [HttpPost]
    public async Task<ActionResult<int>> AddPersons(IFormFile file)
    {
        var result = await _personBusiness.InsertPersonsAsync(file);

        if (result == 1)
        {
            return Ok();
        }
        return BadRequest();

    }
}
