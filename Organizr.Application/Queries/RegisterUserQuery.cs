using System.ComponentModel.DataAnnotations;

namespace Organizr.Infrastructure.DTO;

public class RegisterUserQuery
{
    [Required]
    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; }
    
    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }
    
    [Required]
    public Gender Gender { get; set; }
}