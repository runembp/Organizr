using Organizr.Domain.Entities;

namespace Organizr.Application.Common.Interfaces;

public interface IMemberRepository : IRepository<Member>
{
    Task<Member?> GetMemberWithMembershipsById(int memberId);
    Task<Member?> UpdateMember(Member updatedMember);
    Task<List<Member>> GetAllMembersWithNoMembershipInGroup(int requestGroupId);
}
