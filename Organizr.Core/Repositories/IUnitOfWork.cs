using Microsoft.AspNetCore.Identity;
using Organizr.Core.Entities;

namespace Organizr.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IOrganizrUserRepository OrganizrUserRepository { get; }
        UserManager<OrganizrUser> UserManager { get; }
        SignInManager<OrganizrUser> SignInManager { get; }
    }
}
