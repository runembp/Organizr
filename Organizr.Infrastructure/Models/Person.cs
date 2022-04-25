namespace Organizr.Infrastructure.Models;

public class Person
{
    public int PersonId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public List<Group> Groups { get; set; } = new ();
}