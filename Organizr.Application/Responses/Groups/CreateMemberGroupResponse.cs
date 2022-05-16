using Organizr.Domain.Entities;

namespace Organizr.Application.Responses.Groups;

public class CreateMemberGroupResponse
{
    public bool Succeeded { get; set; }
    public string Error { get; set; } = string.Empty;
    public MemberGroup CreatedGroup { get; set; } = new();
}