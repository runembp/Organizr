namespace Organizr.Application.Responses;

public class CreateUserGroupResponse
{
    public string GroupName { get; set; } = string.Empty;
    public bool Succeeded { get; set; }
}