using Organizr.Domain.Entities;

namespace Organizr.Application.Common.Interfaces;

public interface IMembershipRepository : IRepository<Membership>
{
    Task<Membership?> CreateNewMembership(int groupId, int memberId, int roleId);
    Task<List<Membership>?> GetMembershipsForMember(int memberId);
}