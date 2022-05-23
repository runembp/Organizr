namespace Organizr.Domain.Entities
{
    public class MemberGroup
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsOpen { get; set; }
        public List<Member> Members { get; set; } = new();

        public List<Membership> Memberships { get; set; } = new();
        public List<NewsPost> NewsPosts { get; set; } = new();
    }
}
