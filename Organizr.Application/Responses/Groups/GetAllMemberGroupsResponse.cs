using Organizr.Domain.Entities;

namespace Organizr.Application.Responses.Groups;

public class GetAllMemberGroupsResponse
{
    public IReadOnlyList<MemberGroup> MemberGroups { get; init; }
}