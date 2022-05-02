using Microsoft.AspNetCore.Identity;
using Organizr.Core.Entities;
using Organizr.Core.Repositories;
using Organizr.Infrastructure.Data;

namespace Organizr.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly OrganizrDbContext _dbContext;
    private IOrganizrUserRepository _userRepository;
    public UserManager<OrganizrUser> UserManager { get; }
    public SignInManager<OrganizrUser> SignInManager { get; }

    public UnitOfWork(OrganizrDbContext dbContext, UserManager<OrganizrUser> userManager, SignInManager<OrganizrUser> signInManager, IUserGroupRepository userGroupRepository)
    {
        _dbContext = dbContext;
        UserManager = userManager;
        SignInManager = signInManager;
        UserGroupRepository = userGroupRepository;
    }

    public IOrganizrUserRepository OrganizrUserRepository =>
            _userRepository ??= new OrganizrUserRepository(_dbContext);

    public IUserGroupRepository UserGroupRepository { get; }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}

