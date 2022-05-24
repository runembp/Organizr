using Microsoft.EntityFrameworkCore;
using Organizr.Application.Common.Interfaces;
using Organizr.Domain.Entities;
using Organizr.Infrastructure.Persistence;

namespace Organizr.Infrastructure.Repositories
{
    public class MemberRepository : Repository<Member>, IMemberRepository
    {
        public MemberRepository(OrganizrDbContext organizrContext) : base(organizrContext) { }
        public async Task<Member?> GetMemberWithMembershipsById(int memberId)
        {
            return await _organizrContext.Users.Where(x => x.Id == memberId).Include(x => x.Memberships).FirstOrDefaultAsync();
        }

        public async Task<Member?> GetMemberMembershipGroupsById(int memberId)
        {
            return await _organizrContext.Users.Where(u => u.Id == memberId)
                .Include(ms => ms.Memberships)
                .ThenInclude(x => x.MemberGroup)
                .FirstOrDefaultAsync();
        }

        public async Task<Member?> UpdateMember(Member updatedMember)
        {
            var member = _organizrContext.Users.FirstOrDefault(x => x.Id == updatedMember.Id);

            if (member is null)
            {
                return null;
            }

            member.FirstName = updatedMember.FirstName;
            member.LastName = updatedMember.LastName;
            member.Address = updatedMember.Address;
            member.Email = updatedMember.Email;
            member.PhoneNumber = updatedMember.PhoneNumber;
            member.Gender = updatedMember.Gender;

            await _organizrContext.SaveChangesAsync();
            
            return member;
        }

        public async Task<List<Member>> GetAllMembersWithNoMembershipInGroup(int groupId)
        {
            var result = await _organizrContext.Users
                .Include(x => x.Memberships)
                .Where(x => x.Memberships.All(y => y.MemberGroup.Id != groupId))
                .ToListAsync();

            return result;
        }
    }
}
