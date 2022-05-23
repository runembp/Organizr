using Microsoft.EntityFrameworkCore;
using Organizr.Application.Common.Interfaces;
using Organizr.Domain.Entities;
using Organizr.Infrastructure.Persistence;

namespace Organizr.Infrastructure.Repositories;

public class MemberGroupRepository : Repository<MemberGroup>, IMemberGroupRepository
{
    public MemberGroupRepository(OrganizrDbContext organizrDbContext) : base(organizrDbContext)
    {
    }

    public async Task<MemberGroup?> GetMemberGroupWithMembershipsById(int groupId)
    {
        return await _organizrContext.MemberGroups.Where(x => x.Id == groupId)
            .Include(x => x.Memberships)
                .ThenInclude(x => x.Member)
            .FirstOrDefaultAsync();
    }

    public async Task<List<MemberGroup>?> GetOpenMembergroupsWhereMemberHasNoMembership(int memberId, bool onlyOpenGroups)
    {
        var member = _organizrContext.Users.FirstOrDefault(x => x.Id == memberId);

        if (member is null)
        {
            return null;
        }

        var groups = await _organizrContext.MemberGroups
            .Include(x => x.Memberships)
            .ThenInclude(x => x.Member)
            .Where(x => !onlyOpenGroups || x.IsOpen)
            .Where(x => x.Memberships.All(y => y.Member != member)).ToListAsync();

        return groups;
    }

    public Task<bool> GroupExists(string groupName)
    {
        var group = _organizrContext.MemberGroups.FirstOrDefault(x => x.Name == groupName);
        return Task.FromResult(group is not null);
    }

    public async Task<MemberGroup?> UpdateMemberGroup(MemberGroup memberGroup)
    {
        var group = _organizrContext.MemberGroups.FirstOrDefault(x => x.Id == memberGroup.Id);

        if (group is null)
        {
            return null;
        }

        group.Name = memberGroup.Name;
        group.IsOpen = memberGroup.IsOpen;

        await _organizrContext.SaveChangesAsync();

        return group;
    }
}