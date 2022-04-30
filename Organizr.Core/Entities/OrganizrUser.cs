using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using Organizr.Core.Enums;

namespace Organizr.Core.Entities
{
    public class OrganizrUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        [Required]
        public Gender Gender { get; set; } = Gender.Undefined;
        [Required]
        public bool ConfigRefreshPrivilege { get; set; }
    }
}
