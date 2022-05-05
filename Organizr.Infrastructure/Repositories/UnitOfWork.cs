using Microsoft.AspNetCore.Identity;
using Organizr.Application.Common.Interfaces;
using Organizr.Domain.Entities;
using Organizr.Infrastructure.Persistence;

namespace Organizr.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly OrganizrDbContext _dbContext;
    public UserManager<Member> UserManager { get; }
    public SignInManager<Member> SignInManager { get; }
    public IMemberRepository MemberRepository { get; }
    public IMemberGroupRepository GroupRepository { get; }
    public IConfigurationRepository ConfigurationRepository { get; }

    public UnitOfWork(OrganizrDbContext dbContext, UserManager<Member> userManager, SignInManager<Member> signInManager, IMemberGroupRepository memberGroupRepository, IMemberRepository memberRepository, IConfigurationRepository configurationRepository)
    {
        _dbContext = dbContext;
        UserManager = userManager;
        SignInManager = signInManager;
        GroupRepository = memberGroupRepository;
        MemberRepository = memberRepository;
        ConfigurationRepository = configurationRepository;
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}