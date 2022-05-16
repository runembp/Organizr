using Microsoft.EntityFrameworkCore;
using Organizr.Application.Common.Interfaces;
using Organizr.Domain.Entities;
using Organizr.Infrastructure.Persistence;

namespace Organizr.Infrastructure.Repositories
{
    public class MemberRepository : Repository<Member>, IMemberRepository
    {
        public MemberRepository(OrganizrDbContext organizrContext) : base(organizrContext) { }

        public Task<Member?> GetAllGroupsByMemberId(int memberId)
        {
            var group = _organizrContext.Users.Where(x => x.Id == memberId).Include(x => x.Groups).FirstOrDefault();
            return Task.FromResult(group);

        }
    }
}
