using Organizr.Core.Entities;

namespace Organizr.Core.IRepositories;

public interface IMemberGroupRepository : IRepository<MemberGroup>
{
    public Task<bool> GroupExists(string groupName);
}