using Organizr.Application.Commands.NewsPosts;
using Organizr.Domain.Entities;

namespace Organizr.Application.Common.Interfaces;

public interface INewsPostRepository : IRepository<NewsPost>
{
    Task<List<NewsPost>> GetAllPublicNewsPosts();
    Task<List<NewsPost>?> GetAllNewsPostsByGroupId(int groupId);
    Task<NewsPost?> AddNewsPost(CreateNewsPostCommand command);
}
