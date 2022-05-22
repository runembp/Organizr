using Microsoft.EntityFrameworkCore;
using Organizr.Application.Common.Interfaces;
using Organizr.Domain.Entities;
using Organizr.Infrastructure.Persistence;

namespace Organizr.Infrastructure.Repositories;

public class NewsPostRepository : Repository<NewsPost>, INewsPostRepository
{
    public NewsPostRepository(OrganizrDbContext organizrDbContext) : base(organizrDbContext)
    {
    }

    public async Task<List<NewsPost>> GetAllPublicNewsPosts()
    {
        return await _organizrContext.NewsPosts
            .Include(x => x.Member)
            // .Include(x => x.MemberGroup) -- Remove Comments once Membergroup is a part of NewsPosts
            .Where(x => x.IsPublic)
            .ToListAsync();
    }
}