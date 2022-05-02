using Microsoft.AspNetCore.Identity;

namespace Organizr.Core.Entities;

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