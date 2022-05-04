using Organizr.Core.Entities;

namespace Organizr.Core.Repositories;

public interface IMemberGroupRepository : IRepository<MemberGroup>
{
    public Task<bool> GroupExists(string groupName);
}