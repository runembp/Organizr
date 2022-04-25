using Organizr.Database;
using Organizr.Infrastructure.Models;

namespace Organizr.Core.Services;

public class PersonService
{
    private readonly OrganizrDataContext _context;

    public PersonService(OrganizrDataContext context)
    {
        _context = context;
    }

    public List<Person> GetAllPersons()
    {
        return _context.Persons.ToList() ;
    }

    public Person? GetPersonById(int personId)
    {
        return _context.Persons.FirstOrDefault(x => x.PersonId == personId);
    }
}