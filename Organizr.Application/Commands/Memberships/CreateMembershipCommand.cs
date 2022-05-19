using MediatR;
using Organizr.Application.Responses.Memberships;

namespace Organizr.Application.Commands.Memberships;

public class CreateMembershipCommand : IRequest<CreateMembershipResponse>
{
    public int GroupId { get; init; }
    public int MemberId { get; init; }
    public int RoleId { get; init; }
}