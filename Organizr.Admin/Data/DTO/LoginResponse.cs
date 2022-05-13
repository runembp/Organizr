// ReSharper disable All
namespace Organizr.Admin.Data.DTO;

public class LoginResponse
{
    public string Email { get; init; } = string.Empty;
    public bool Succeeded { get; init; }
    public string Token { get; init; } = string.Empty;
}