using Microsoft.EntityFrameworkCore;
using Organizr.Core.Repositories.Base;
using Organizr.Infrastructure.Data;

namespace Organizr.Infrastructure.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly OrganizrDbContext _organizrContext;

        public Repository(OrganizrDbContext organizrDbContext)
        {
            _organizrContext = organizrDbContext;
        }

        public async Task<T> AddAsync(T entity)
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

        public async Task<IReadOnlyList<T>> GetAllAsync()
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
