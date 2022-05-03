using Organizr.Core.Entities;

namespace Organizr.Application.Responses;

public class GetAllUserGroupsResponse
{
    public IReadOnlyList<UserGroup> UserGroups { get; init; }
}