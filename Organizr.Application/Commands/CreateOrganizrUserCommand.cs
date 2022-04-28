using MediatR;
using Organizr.Application.Responses;
using Organizr.Core.Enums;

namespace Organizr.Application.Commands;

public class CreateOrganizrUserCommand : IRequest<OrganizrUserResponse>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public Gender Gender { get; set; } = Gender.None;
    public string Password { get; set; } = string.Empty;
}

