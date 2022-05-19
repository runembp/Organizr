using Organizr.Application.Commands.Memberships;
using Organizr.Domain.Entities;

namespace Organizr.Application.Common.Interfaces;

public interface IMembershipRepository : IRepository<Membership>
{
    Task<Membership?> CreateMembership(CreateMembershipCommand command);
    Task<List<Membership>?> GetMembershipsForMember(int memberId);
}