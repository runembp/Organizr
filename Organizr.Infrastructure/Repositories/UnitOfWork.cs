using Microsoft.AspNetCore.Identity;
using Organizr.Core.Entities;
using Organizr.Core.Repositories;
using Organizr.Infrastructure.Data;

namespace Organizr.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly OrganizrDbContext _dbContext;
    public UserManager<Member> UserManager { get; }
    public SignInManager<Member> SignInManager { get; }
    public IMemberRepository MemberRepository { get; }
    public IMemberGroupRepository GroupRepository { get; }

    public UnitOfWork(OrganizrDbContext dbContext, UserManager<Member> userManager, SignInManager<Member> signInManager, IMemberGroupRepository memberGroupRepository, IMemberRepository memberRepository)
    {
        _dbContext = dbContext;
        UserManager = userManager;
        SignInManager = signInManager;
        GroupRepository = memberGroupRepository;
        MemberRepository = memberRepository;
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}