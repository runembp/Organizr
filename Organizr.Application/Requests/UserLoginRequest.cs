using MediatR;
using Organizr.Application.Responses;

namespace Organizr.Application.Requests;

public class UserLoginRequest : IRequest<UserLoginResponse>
{
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}