using Organizr.Core.Repositories;
using Organizr.Infrastructure.Data;

namespace Organizr.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly OrganizrDbContext _dbContext;
    private IOrganizrUserRepository _userRepository;

    public UnitOfWork(OrganizrDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IOrganizrUserRepository OrganizrUserRepository =>
            _userRepository ??= new OrganizrUserRepository(_dbContext);

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}

