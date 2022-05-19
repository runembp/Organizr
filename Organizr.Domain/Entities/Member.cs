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

        public List<MemberGroup> Groups { get; set; } = new();
        public List<Membership> Memberships { get; set; } = new();
        public List<News> News { get; set; } = new();
    }
}
