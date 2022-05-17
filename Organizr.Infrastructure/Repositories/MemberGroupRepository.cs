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

    public async Task<MemberGroup?> AddMemberToGroup(int groupId, int memberId)
    {
        var group = _organizrContext.MemberGroups.Include(x => x.Members).First(x => x.Id == groupId);
        var member = _organizrContext.Users.First(x => x.Id == memberId);

        if (group.Members.Contains(member)) return null;

        public async Task<MemberGroup?> AddMemberToGroup(int groupId, int memberId)
        {
            var group = _organizrContext.MemberGroups.Include(x => x.Members).FirstOrDefault(x => x.Id == groupId);

            if (group is null)
            {
                return null;
            }

            var member = _organizrContext.Users.FirstOrDefault(x => x.Id == memberId);

            if (member is null)
            {
                return null;
            }

            if (group.Members.Contains(member)) return null;

            group.Members.Add(member);
            member.Groups.Add(group);

            await _organizrContext.SaveChangesAsync();

            return group;
        }

        public async Task<MemberGroup?> RemoveMemberFromGroup(int groupId, int memberId)
        {
            var group = _organizrContext.MemberGroups.Where(x => x.Id == groupId).Include(x => x.Members).FirstOrDefault();
            var member = group?.Members.FirstOrDefault(x => x.Id == memberId);

            if (member is null)
            {
                return null;
            }

            group?.Members.Remove(member);
            await _organizrContext.SaveChangesAsync();
            return group;
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