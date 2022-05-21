using MediatR;
using Organizr.Domain.Entities;

namespace Organizr.Application.Requests.Groups;

public class GetMemberGroupsWithNoMembershipOfMemberRequest : IRequest<List<MemberGroup>?>
{
    public int MemberId { get; init; }
    public bool OnlyOpenGroups { get; init; } = true;
}