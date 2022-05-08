namespace Organizr.Application.Responses.Groups;

public class CreateMemberGroupResponse
{
    public string GroupName { get; set; } = string.Empty;
    public bool Succeeded { get; set; }
}