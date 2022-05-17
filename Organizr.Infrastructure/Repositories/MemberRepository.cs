﻿using Microsoft.EntityFrameworkCore;
using Organizr.Application.Common.Interfaces;
using Organizr.Domain.Entities;
using Organizr.Infrastructure.Persistence;

namespace Organizr.Infrastructure.Repositories
{
    public class MemberRepository : Repository<Member>, IMemberRepository
    {
        public MemberRepository(OrganizrDbContext organizrContext) : base(organizrContext) { }
        public Task<Member?> GetMemberWithGroupsById(int memberId)
        {
            var member = _organizrContext.Users.Where(x => x.Id == memberId).Include(x => x.Groups).FirstOrDefault();
            return Task.FromResult(member);
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
    }
}
