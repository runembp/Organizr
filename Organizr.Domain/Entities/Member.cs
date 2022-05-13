using Microsoft.AspNetCore.Identity;
using Organizr.Domain.Enums;

namespace Organizr.Domain.Entities
{
    public class Member : IdentityUser<int>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public Gender Gender { get; set; } = Gender.Undefined;
        public bool ConfigRefreshPrivilege { get; set; }

        public virtual List<MemberGroup> Groups { get; set; } = new();
    }
}
