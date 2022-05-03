using Microsoft.AspNetCore.Identity;
using Organizr.Core.Entities;
using Organizr.Core.Repositories;
using Organizr.Infrastructure.Data;

namespace Organizr.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly OrganizrDbContext _dbContext;
    public UserManager<OrganizrUser> UserManager { get; }
    public SignInManager<OrganizrUser> SignInManager { get; }
    public IOrganizrUserRepository OrganizrUserRepository { get; }
    public IUserGroupRepository UserGroupRepository { get; }

    public UnitOfWork(OrganizrDbContext dbContext, UserManager<OrganizrUser> userManager, SignInManager<OrganizrUser> signInManager, IUserGroupRepository userGroupRepository, IOrganizrUserRepository organizrUserRepository)
    {
        _dbContext = dbContext;
        UserManager = userManager;
        SignInManager = signInManager;
        UserGroupRepository = userGroupRepository;
        OrganizrUserRepository = organizrUserRepository;
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}