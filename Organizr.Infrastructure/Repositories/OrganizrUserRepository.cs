﻿using Microsoft.EntityFrameworkCore;
using Organizr.Core.Entities;
using Organizr.Core.Repositories.Base;
using Organizr.Infrastructure.Data;
using Organizr.Infrastructure.Repositories.Base;

namespace Organizr.Infrastructure.Repositories
{
    public class OrganizrUserRepository : Repository<OrganizrUser>, IOrganizrUserRepository
    {
        public OrganizrUserRepository(OrganizrDbContext organizrContext) : base(organizrContext) { }
        public async Task<IEnumerable<OrganizrUser>> GetEmployeeByLastName(string lastname)
        {
            return await _organizrContext.Users.Where(m => m.LastName == lastname).ToListAsync();
        }
    }
}