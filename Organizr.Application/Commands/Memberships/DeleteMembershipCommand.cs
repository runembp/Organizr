using MediatR;
using Organizr.Application.Responses.Memberships;

namespace Organizr.Application.Commands.Memberships;

public class DeleteMembershipCommand : IRequest<DeleteMembershipResponse>
{
    public int MembershipId { get; init; }
}