namespace Organizr.Application.Responses.Memberships;

public class DeleteMembershipResponse
{
    public bool Succeeded { get; set; }
    public string Error { get; set; } = string.Empty;
}