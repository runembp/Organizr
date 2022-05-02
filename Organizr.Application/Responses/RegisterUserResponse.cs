using Microsoft.AspNetCore.Identity;

namespace Organizr.Application.Responses;

public class RegisterUserResponse
{
    public bool Succeeded { get; set; } = false;
    public List<IdentityError> Errors { get; set; } = new();
}