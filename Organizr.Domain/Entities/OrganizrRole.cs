using Microsoft.AspNetCore.Identity;

namespace Organizr.Domain.Entities;

public class OrganizrRole : IdentityRole<int>
{
    public OrganizrRole() : base()
    {
    }

    public OrganizrRole(string roleName)
    {
        Name = roleName;
    }
}