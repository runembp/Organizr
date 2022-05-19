using Organizr.Domain.Entities;

namespace Organizr.Application.Responses.Memberships;

public class CreateMembershipResponse
{
    public bool Succeeded { get; set; }
    public string Error { get; set; }
    public Membership CreatedMembership { get; set; }
}