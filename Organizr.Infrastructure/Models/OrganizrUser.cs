using Microsoft.AspNetCore.Identity;

namespace Organizr.Infrastructure.Models;

public class OrganizrUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Gender Gender { get; set; }
}