using Microsoft.EntityFrameworkCore;
using Organizr.Core.IRepositories;
using Organizr.Infrastructure.Data;

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

        public async Task DeleteAsync(T entity)
        {
            _organizrContext.Set<T>().Remove(entity);
            await _organizrContext.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _organizrContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _organizrContext.Set<T>().FindAsync(id);
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
