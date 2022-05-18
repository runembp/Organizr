using Organizr.Domain.Enums;

namespace Organizr.Domain.Entities;

public class GroupRole
{
    public int Id { get; set; }
    public Role Role { get; set; }
    public string Description { get; set; } = string.Empty;
}