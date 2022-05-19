using Organizr.Application.Common.Interfaces;
using Organizr.Domain.Entities;
using Organizr.Infrastructure.Persistence;

namespace Organizr.Infrastructure.Repositories;

public class NewsRepository : Repository<NewsPost>, INewsRepository
{
    public NewsRepository(OrganizrDbContext organizrDbContext) : base(organizrDbContext)
    {
    }
}