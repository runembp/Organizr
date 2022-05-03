using Organizr.Core.Entities;
using Organizr.Core.Repositories;
using Organizr.Infrastructure.Data;

namespace Organizr.Infrastructure.Repositories;

public class UserGroupRepository : Repository<UserGroup>, IUserGroupRepository
{
    public UserGroupRepository(OrganizrDbContext organizrDbContext) : base(organizrDbContext)
    {
    }

    public Task<bool> GroupExists(string groupName)
    {
        var group = _organizrContext.UserGroups.FirstOrDefault(x => x.Name == groupName);
        return Task.FromResult(group is not null);
    }
}