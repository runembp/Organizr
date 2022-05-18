using MediatR;
using Organizr.Domain.Entities;

namespace Organizr.Application.Requests.Groups;

public class GetAllMemberGroupsWithNoMembershipOfMemberRequest : IRequest<List<MemberGroup>>
{
    public int MemberId { get; init; } 
}