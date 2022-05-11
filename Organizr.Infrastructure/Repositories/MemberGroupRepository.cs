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

    public Task<MemberGroup?> GetMemberGroupWithMembers(int groupId)
    {
        var group = _organizrContext.MemberGroups.Where(x => x.Id == groupId).Include(x => x.Members).FirstOrDefault();
        return Task.FromResult(group);
    }

    public Task<bool> GroupExists(string groupName)
    {
        var group = _organizrContext.MemberGroups.FirstOrDefault(x => x.Name == groupName);
        return Task.FromResult(group is not null);
    }

    public async Task<MemberGroup> AddMemberToGroup(int groupId, int memberId)
    {
        var group = _organizrContext.MemberGroups.First(x => x.Id == groupId);
        var member = _organizrContext.Users.First(x => x.Id == memberId);

        group.Members.Add(member);
        member.Groups.Add(group);

        await _organizrContext.SaveChangesAsync();

        return group;
    }

    public async Task<MemberGroup> UpdateMemberGroup(MemberGroup memberGroup)
    {
        var group = _organizrContext.MemberGroups.First(x => x.Id == memberGroup.Id);
        group.Name = memberGroup.Name;
        group.IsOpen = memberGroup.IsOpen;

        await _organizrContext.SaveChangesAsync();

        return group;
    }
}