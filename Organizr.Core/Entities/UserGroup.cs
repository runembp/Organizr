namespace Organizr.Core.Entities
{
    public class UserGroup
    {
        public int GroupId { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<OrganizrUser> Users { get; set; } = new();
    }
}
