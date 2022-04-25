namespace Organizr.Infrastructure.Models;

public class Group
{
    public int GroupId { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Person> Persons { get; set; } = new ();
}