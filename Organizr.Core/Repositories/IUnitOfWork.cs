using Microsoft.AspNetCore.Identity;
using Organizr.Core.Entities;

namespace Organizr.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IMemberRepository MemberRepository { get; }
        IMemberGroupRepository GroupRepository { get; }
        UserManager<Member> UserManager { get; }
        SignInManager<Member> SignInManager { get; }
    }
}
