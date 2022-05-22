using MediatR;
using Organizr.Application.Responses.Memberships;

namespace Organizr.Application.Commands.Memberships;

public class UpdateMembershipRoleCommand : IRequest<UpdateMembershipRoleResponse>
{
    public int MembershipId { get; set; }
    public int RoleId { get; init; }
}