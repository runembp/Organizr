using Microsoft.AspNetCore.Identity;
using Organizr.Core.Entities;

namespace Organizr.Core.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IMemberRepository MemberRepository { get; }
        IMemberGroupRepository GroupRepository { get; }
        IConfigurationRepository ConfigurationRepository { get; }
        UserManager<Member> UserManager { get; }
        SignInManager<Member> SignInManager { get; }
    }
}
