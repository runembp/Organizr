using Organizr.Domain.Entities;

namespace Organizr.Application.Common.Interfaces;

public interface IMemberGroupRepository : IRepository<MemberGroup>
{
    public Task<MemberGroup?> GetMemberGroupWithMembershipsById(int groupId);
    public Task<List<MemberGroup>?> GetOpenMembergroupsWhereMemberHasNoMembership(int memberId, bool onlyOpenGroups);
    public Task<bool> GroupExists(string groupName);
    Task<MemberGroup?> UpdateMemberGroup(MemberGroup memberGroup);
}