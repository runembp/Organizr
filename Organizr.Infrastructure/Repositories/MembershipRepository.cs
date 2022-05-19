using Microsoft.EntityFrameworkCore;
using Organizr.Application.Common.Interfaces;
using Organizr.Domain.Entities;
using Organizr.Infrastructure.Persistence;

namespace Organizr.Infrastructure.Repositories;

public class MembershipRepository : Repository<Membership>, IMembershipRepository
{
    public MembershipRepository(OrganizrDbContext organizrDbContext) : base(organizrDbContext)
    {
    }

    public async Task<Membership?> CreateNewMembership(int groupId, int memberId, int roleId)
    {
        var group = _organizrContext.MemberGroups.FirstOrDefault(x => x.Id == groupId);
        var member = _organizrContext.Users.FirstOrDefault(x => x.Id == memberId);
        var role = _organizrContext.Roles.FirstOrDefault(x => x.Id == roleId);

        if (group is null || member is null || role is null)
        {
            return null;
        }

        var membership = new Membership
        {
            MemberGroup = group,
            Member = member,
            Role = role
        };

        var createdMembership = _organizrContext.Memberships.Add(membership);
        await _organizrContext.SaveChangesAsync();
        return createdMembership.Entity;
    }

    public async Task<List<Membership>?> GetMembershipsForMember(int memberId)
    {
        var member = await _organizrContext.Users.FirstOrDefaultAsync(x => x.Id == memberId);

        if (member is null)
        {
            return null;
        }

        return await _organizrContext.Memberships
            .Where(x => x.Member == member)
            .Include(x => x.MemberGroup)
            .Include(x => x.Role)
            .ToListAsync();
    }
}