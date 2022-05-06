using Organizr.Domain.Entities;

namespace Organizr.Application.Responses;

public class GetAllMemberGroupsResponse
{
    public IReadOnlyList<MemberGroup> MemberGroups { get; init; }
}