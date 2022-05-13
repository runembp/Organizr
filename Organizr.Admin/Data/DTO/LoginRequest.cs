// ReSharper disable All
namespace Organizr.Admin.Data.DTO;

public class LoginRequest
{
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}