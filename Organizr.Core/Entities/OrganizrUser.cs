using Microsoft.AspNetCore.Identity;
using Organizr.Core.Enums;

namespace Organizr.Core.Entities
{
    public class OrganizrUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Gender Gender { get; set; } = Gender.None;
    }
}
