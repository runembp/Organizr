using System.ComponentModel.DataAnnotations;

namespace Organizr.Application.Queries;

public class LoginUserQuery 
{
    [Required]
    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; }
}