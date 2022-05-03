using MediatR;
using Organizr.Application.Responses;
using System.ComponentModel.DataAnnotations;

namespace Organizr.Application.Requests;

public class UserLoginRequest : IRequest<UserLoginResponse>
{
    [Required]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;
}