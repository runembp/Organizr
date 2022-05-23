using MediatR;
using Organizr.Application.Responses;

namespace Organizr.Application.Commands.Roles;

public class ChangeMemberRoleCommand : IRequest<ChangeMemberRoleResponse>
{
    public int MemberId { get; init; }
    public bool IsOrganizationAdministrator { get; init; }
}