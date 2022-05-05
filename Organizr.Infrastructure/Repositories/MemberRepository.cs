using Organizr.Application.Common.IRepositories;
using Organizr.Domain.Entities;
using Organizr.Infrastructure.Persistence;

namespace Organizr.Infrastructure.Repositories
{
    public class MemberRepository : Repository<Member>, IMemberRepository
    {
        public MemberRepository(OrganizrDbContext organizrContext) : base(organizrContext) { }
    }
}
