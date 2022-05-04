using Microsoft.AspNetCore.Identity;

namespace Organizr.Application.Responses;

public class CreateMemberResponse
{
    public bool Succeeded { get; set; }
    public List<IdentityError> Errors { get; set; } = new();
}