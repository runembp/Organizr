using Organizr.Domain.Entities;

namespace Organizr.Application.Common.Interfaces;

public interface IMemberGroupRepository : IRepository<MemberGroup>
{
    public Task<MemberGroup?> GetMemberGroupWithMembers(int groupId);
    public Task<bool> GroupExists(string groupName);
    Task<MemberGroup> AddMemberToGroup(int groupId, int memberId);
    Task<Member> RemoveMemberFromGroup(int groupId, int memberId);
    Task<MemberGroup> UpdateMemberGroup(MemberGroup memberGroup);
}