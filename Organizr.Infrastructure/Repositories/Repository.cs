using Microsoft.EntityFrameworkCore;
using Organizr.Application.Common.Interfaces;
using Organizr.Infrastructure.Persistence;

namespace Organizr.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly OrganizrDbContext _organizrContext;

        protected Repository(OrganizrDbContext organizrDbContext)
        {
            _organizrContext = organizrDbContext;
        }

        public async Task<T> Add(T entity)
        {
            await _organizrContext.Set<T>().AddAsync(entity);
            await _organizrContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T?> DeleteByIdAsync(int id)
        {
            var entity = await _organizrContext.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _organizrContext.Set<T>().Remove(entity);
            }
            await _organizrContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _organizrContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _organizrContext.Set<T>().FindAsync(id);
        }
    }
}
