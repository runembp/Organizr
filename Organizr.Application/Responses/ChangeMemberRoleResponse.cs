namespace Organizr.Application.Responses;

public class ChangeMemberRoleResponse
{
    public bool Succeeded { get; set; }
    public string Error { get; set; } = string.Empty;
}