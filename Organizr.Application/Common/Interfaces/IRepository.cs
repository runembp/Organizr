namespace Organizr.Application.Common.Interfaces;

public interface IRepository<T> where T : class
{
    Task<IReadOnlyList<T>> GetAll();
    Task<T> GetByIdAsync(int id);
    Task<T> Add(T entity);
    Task<T?> DeleteByIdAsync(int id);
}

