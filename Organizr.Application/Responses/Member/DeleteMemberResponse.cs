namespace Organizr.Application.Responses.Member;

public class DeleteMemberResponse
{
    public bool Succeeded { get; set; }
    public string Error { get; set; } = string.Empty;
}