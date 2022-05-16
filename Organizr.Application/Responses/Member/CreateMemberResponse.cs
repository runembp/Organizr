namespace Organizr.Application.Responses.Member;

public class CreateMemberResponse
{
    public bool Succeeded { get; set; }
    public string Error { get; set; } = string.Empty;
    public Domain.Entities.Member CreatedMember { get; set; } = new();
}