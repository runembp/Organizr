// ReSharper disable All
namespace Organizr.Admin.Data.DTO;

public class LoginResponse
{
    public bool Succeeded { get; init; }
    public string Email { get; init; } = string.Empty;
    public string Token { get; init; } = string.Empty;
    public int Id { get; init; }
}