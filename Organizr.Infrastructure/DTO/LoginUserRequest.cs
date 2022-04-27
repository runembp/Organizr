using System.ComponentModel.DataAnnotations;

namespace Organizr.Infrastructure.DTO;

public class LoginUserRequest
{
    [Required]
    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; }
}