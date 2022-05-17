using Organizr.Domain.Entities;

namespace Organizr.Application.Common.Interfaces;

public interface IMemberRepository : IRepository<Member>
{
    Task<Member?> GetMemberWithGroupsById(int memberId);
    Task<Member?> UpdateMember(Member updatedMember);
}
