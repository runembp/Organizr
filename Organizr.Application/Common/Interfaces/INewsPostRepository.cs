using Organizr.Domain.Entities;

namespace Organizr.Application.Common.Interfaces;

public interface INewsPostRepository : IRepository<NewsPost>
{
    Task<List<NewsPost>> GetAllPublicNewsPosts();
}
