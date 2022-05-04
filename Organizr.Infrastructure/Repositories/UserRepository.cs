using Microsoft.EntityFrameworkCore;
using Organizr.Core.Entities;
using Organizr.Core.Repositories;
using Organizr.Infrastructure.Data;

namespace Organizr.Infrastructure.Repositories
{
    public class UserRepository : Repository<OrganizrUser>, IUserRepository
    {
        public UserRepository(OrganizrDbContext organizrContext) : base(organizrContext) { }
        public async Task<IEnumerable<OrganizrUser>> GetEmployeeByLastName(string lastname)
        {
            return await _organizrContext.Users.Where(m => m.LastName == lastname).ToListAsync();
        }
    }
}
