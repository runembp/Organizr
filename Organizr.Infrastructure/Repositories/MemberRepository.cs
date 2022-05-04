using Organizr.Core.Entities;
using Organizr.Core.Repositories;
using Organizr.Infrastructure.Data;

namespace Organizr.Infrastructure.Repositories
{
    public class MemberRepository : Repository<Member>, IMemberRepository
    {
        public MemberRepository(OrganizrDbContext organizrContext) : base(organizrContext) { }
    }
}
