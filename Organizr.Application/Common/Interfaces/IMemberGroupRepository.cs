using Organizr.Domain.Entities;

namespace Organizr.Application.Common.Interfaces;

public interface IMemberGroupRepository : IRepository<MemberGroup>
{
    public Task<MemberGroup?> GetMemberGroupWithMembers(int groupId);
    public Task<List<MemberGroup>?> GetOpenMembergroupsWhereMemberHasNoMembership(int memberId, bool onlyOpenGroups);
    public Task<bool> GroupExists(string groupName);
    Task<MemberGroup?> AddMemberToGroup(int groupId, int memberId);
    Task<MemberGroup?> RemoveMemberFromGroup(int groupId, int memberId);
    Task<MemberGroup?> UpdateMemberGroup(MemberGroup memberGroup);
}