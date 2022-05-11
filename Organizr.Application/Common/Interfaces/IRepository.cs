﻿namespace Organizr.Application.Common.Interfaces;

public interface IRepository<T> where T : class
{
    Task<IReadOnlyList<T>> GetAll();
    Task<T> GetByIdAsync(int id);
    Task<T> Add(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<int> DeleteByIdAsync(int id);
}

