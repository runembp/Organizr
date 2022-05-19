using Organizr.Application.Common.Interfaces;
using Organizr.Domain.Entities;
using Organizr.Infrastructure.Persistence;

namespace Organizr.Infrastructure.Repositories;

public class NewsPostRepository : Repository<NewsPost>, INewsPostRepository
{
    public NewsPostRepository(OrganizrDbContext organizrDbContext) : base(organizrDbContext)
    {
    }
}