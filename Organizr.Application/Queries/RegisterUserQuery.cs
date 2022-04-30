using Organizr.Infrastructure;

namespace Organizr.Application.Queries;

public class RegisterUserQuery
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public bool ConfigRefreshPrivilege { get; set; }
}