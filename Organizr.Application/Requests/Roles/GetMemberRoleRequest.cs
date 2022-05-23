using MediatR;

namespace Organizr.Application.Requests.Roles;

public class GetMemberRoleRequest  : IRequest<bool?>
{
    public int MemberId { get; init; }
}