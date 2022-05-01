using System.ComponentModel.DataAnnotations;
using MediatR;
using Organizr.Application.Responses;

namespace Organizr.Application.Queries;

public class UserLoginRequest : IRequest<UserLoginResponse>
{
    [Required]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
}