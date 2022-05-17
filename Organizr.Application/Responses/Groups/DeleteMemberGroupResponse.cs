namespace Organizr.Application.Responses.Groups;

public class DeleteMemberGroupResponse
{
    public bool Succeeded { get; set; }
    public string Error { get; set; } = string.Empty;
}