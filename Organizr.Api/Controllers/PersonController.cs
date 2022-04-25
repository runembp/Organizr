using Microsoft.AspNetCore.Mvc;
using Organizr.Core.Services;
using Organizr.Infrastructure.Models;

namespace Organizr.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly PersonService _personService;

    public PersonController(PersonService personService)
    {
        _personService = personService;
    }
    
    [HttpGet("/AllPersons")]
    public ActionResult<List<Person>> GetAllPersons()
    {
        return _personService.GetAllPersons();
    }

    [HttpGet("int:id")]
    
    public ActionResult<Person>? GetPersonById(int id)
    {
        var person =_personService.GetPersonById(id);
        if (person is null)
        {
            return NotFound(404);
        }

        return person;
    }
}