using Organizr.Core.Entities;
using Organizr.Core.Repositories;
using Organizr.Infrastructure.Data;

namespace Organizr.Infrastructure.Repositories;

public class MemberGroupRepository : Repository<MemberGroup>, IMemberGroupRepository
{
    public MemberGroupRepository(OrganizrDbContext organizrDbContext) : base(organizrDbContext)
    {
    }

    public Task<bool> GroupExists(string groupName)
    {
        var group = _organizrContext.MemberGroups.FirstOrDefault(x => x.Name == groupName);
        return Task.FromResult(group is not null);
    }
}