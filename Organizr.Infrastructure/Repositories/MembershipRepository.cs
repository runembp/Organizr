using Organizr.Application.Common.Interfaces;
using Organizr.Domain.Entities;
using Organizr.Infrastructure.Persistence;

namespace Organizr.Infrastructure.Repositories;

public class MembershipRepository : Repository<Membership>, IMembershipRepository
{
    public MembershipRepository(OrganizrDbContext organizrDbContext) : base(organizrDbContext)
    {
    }
    
    
}