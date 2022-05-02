using Microsoft.AspNetCore.Identity;

namespace Organizr.Application.Responses;

public class CreateUserResponse
{
    public bool Succeeded { get; set; }
    public List<IdentityError> Errors { get; set; } = new();
}