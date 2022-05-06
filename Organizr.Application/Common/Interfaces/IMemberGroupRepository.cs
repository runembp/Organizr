using Organizr.Domain.Entities;

namespace Organizr.Application.Common.Interfaces;

public interface IMemberGroupRepository : IRepository<MemberGroup>
{
    public Task<bool> GroupExists(string groupName);
}