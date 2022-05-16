namespace Organizr.Application.Responses;

public class UserLoginResponse
{
    public string Email { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public int Id { get; set; }
    public bool Succeeded { get; set; }
}