using MediatR;
using Organizr.Application.Responses.Roles;

namespace Organizr.Application.Commands.Roles;

public class ChangeMemberRoleCommand : IRequest<ChangeMemberRoleResponse>
{
    public int MemberId { get; init; }
    public bool IsOrganizationAdministrator { get; init; }
}