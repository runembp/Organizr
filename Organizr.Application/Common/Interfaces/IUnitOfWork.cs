using Microsoft.AspNetCore.Identity;
using Organizr.Domain.Entities;

namespace Organizr.Application.Common.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IMemberRepository MemberRepository { get; }
    IMemberGroupRepository GroupRepository { get; }
    IMembershipRepository MembershipRepository { get; }
    IConfigurationRepository ConfigurationRepository { get; }
    UserManager<Member> UserManager { get; }
    SignInManager<Member> SignInManager { get; }
}
