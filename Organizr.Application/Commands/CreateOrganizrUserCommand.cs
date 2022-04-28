using MediatR;
using Organizr.Application.Responses;
using Organizr.Infrastructure;
using Organizr.Core.Enums;

namespace Organizr.Application.Commands
{
    public class CreateOrganizrUserCommand : IRequest<OrganizrUserResponse>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public Gender Gender { get; set; }
    }
}
