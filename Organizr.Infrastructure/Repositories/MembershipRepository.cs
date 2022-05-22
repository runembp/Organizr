using Microsoft.EntityFrameworkCore;
using Organizr.Application.Commands.Memberships;
using Organizr.Application.Common.Interfaces;
using Organizr.Domain.Entities;
using Organizr.Infrastructure.Persistence;

namespace Organizr.Infrastructure.Repositories;

public class MembershipRepository : Repository<Membership>, IMembershipRepository
{
    public MembershipRepository(OrganizrDbContext organizrDbContext) : base(organizrDbContext)
    {
    }

    public async Task<Membership?> CreateMembership(CreateMembershipCommand command)
    {
        var group = _organizrContext.MemberGroups.FirstOrDefault(x => x.Id == command.GroupId);
        var member = _organizrContext.Users.FirstOrDefault(x => x.Id == command.MemberId);
        var role = _organizrContext.Roles.FirstOrDefault(x => x.Id == command.RoleId);

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

    public async Task<Membership?> UpdateMembershipRole(int membershipId, int roleId)
    {
        var membership = await _organizrContext.Memberships.FirstOrDefaultAsync(x => x.Id == membershipId);
        var role = await _organizrContext.Roles.FirstOrDefaultAsync(x => x.Id == roleId);
        
        if (membership is null || role is null)
        {
            return null;
        }

        membership.Role = role;
        await _organizrContext.SaveChangesAsync();
        return membership;
    }
}