using MediatR;
using Organizr.Application.Responses.Member;
using Organizr.Domain.Enums;

namespace Organizr.Application.Commands.Members;

public class UpdateMemberCommand : IRequest<UpdateMemberResponse>
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Gender Gender { get; set; }
}