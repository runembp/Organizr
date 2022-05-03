using Organizr.Core.Entities;

namespace Organizr.Core.Repositories;

public interface IUserGroupRepository : IRepository<UserGroup>
{
    public Task<bool> GroupExists(string groupName);
}