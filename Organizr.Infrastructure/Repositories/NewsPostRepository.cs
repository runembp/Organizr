using Microsoft.EntityFrameworkCore;
using Organizr.Application.Commands.NewsPosts;
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
            .Include(x => x.MemberGroup)
            .Where(x => x.IsPublic)
            .ToListAsync();
    }

    public async Task<NewsPost?> AddNewsPost(CreateNewsPostCommand command)
    {
        var member = _organizrContext.Users.FirstOrDefault(m => m.Id == command.MemberId);
        var group = _organizrContext.MemberGroups.FirstOrDefault(g => g.Id == command.MemberGroupId);

        if (group is null || member is null)
        {
            return null;
        }

        var newsPost = new NewsPost
        {
            Title = command.Title,
            Content = command.Content,
            CreatedAt = command.CreatedAt,
            IsPublic = command.IsPublic,
            Member = member,
            MemberGroup = group
        };

        var createdNewsPost = _organizrContext.NewsPosts.Add(newsPost);
        await _organizrContext.SaveChangesAsync();
        return createdNewsPost.Entity;

    }
}