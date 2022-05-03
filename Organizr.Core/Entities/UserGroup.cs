namespace Organizr.Core.Entities
{
    public class UserGroup
    {
        public int UserGroupId { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool Open { get; set; }
    }
}
