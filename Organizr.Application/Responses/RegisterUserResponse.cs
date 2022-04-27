using Microsoft.AspNetCore.Identity;

namespace Organizr.Application.Responses;

public class RegisterUserResponse
{
    public bool Succeeded { get; set; }
    public IEnumerable<IdentityError> Errors { get; set; }
}