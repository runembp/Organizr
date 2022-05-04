namespace Organizr.Core.IRepositories
{
    public interface IRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAll();
        Task<T> GetByIdAsync(int id);
        Task<T> Add(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
