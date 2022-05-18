namespace Organizr.Domain.Entities;

public class Membership
{
    public int Id { get; set; }
    public MemberGroup MemberGroup { get; set; } = new();
    public Member Member { get; set; } = new();
    public GroupRole GroupRole { get; set; } = new();
}