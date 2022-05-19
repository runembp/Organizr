using Organizr.Application.Common.Interfaces;
using Organizr.Domain.Entities;
using Organizr.Infrastructure.Persistence;

namespace Organizr.Infrastructure.Repositories;

public class NewsPostRepository : Repository<NewsPost>, INewsPostRepository
{
    public NewsPostRepository(OrganizrDbContext organizrDbContext) : base(organizrDbContext)
    {
    }

    public Task<List<NewsPost>> GetAllNewsPosts()
    {
        var newsposts = _organizrContext.NewsPosts
            .Join(_organizrContext.Users, newspost => newspost.Member.Id,
            member => member.Id,
            (newspost, member) => new NewsPost
            {
                Id = newspost.Id,
                Title = newspost.Title,
                Content = newspost.Content,
                CreatedAt = newspost.CreatedAt,
                IsPublic = newspost.IsPublic,
                Member = member

            }).ToList();

        return Task.FromResult(newsposts);
    }
}