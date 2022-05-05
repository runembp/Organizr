using Microsoft.AspNetCore.Identity;
using Organizr.Domain.Entities;

namespace Organizr.Application.Common.IRepositories;

public interface IUnitOfWork : IDisposable
{
    IMemberRepository MemberRepository { get; }
    IMemberGroupRepository GroupRepository { get; }
    IConfigurationRepository ConfigurationRepository { get; }
    UserManager<Member> UserManager { get; }
    SignInManager<Member> SignInManager { get; }
}
