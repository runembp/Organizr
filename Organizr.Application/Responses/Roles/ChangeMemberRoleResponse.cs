namespace Organizr.Application.Responses.Roles;

public class ChangeMemberRoleResponse
{
    public bool Succeeded { get; set; }
    public string Error { get; set; } = string.Empty;
}