using MediatR;
using Organizr.Application.Responses.Member;
using Organizr.Domain.Enums;

namespace Organizr.Application.Commands
{
    public class CreateMemberCommand : IRequest<CreateMemberResponse>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public Gender Gender { get; set; } = Gender.Undefined;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}