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

        public List<Membership> Memberships { get; set; } = new();
        public List<NewsPost> NewsPosts { get; set; } = new();
        
        public string GetFullName()
        {
            return $"{FirstName} {LastName}"; 
        }
        
        public string GetFullNameWithId()
        {
            return $"({Id}) {FirstName} {LastName}";
        }
        
    }
}
