using MediatR;
using Organizr.Domain.Entities;

namespace Organizr.Application.Requests.Memberships;

public class GetMembershipsForMemberRequest : IRequest<List<Membership>?>
{
    public int MemberId { get; init; }
}