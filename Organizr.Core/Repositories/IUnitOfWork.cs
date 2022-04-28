using Organizr.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizr.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IOrganizrUserRepository OrganizrUserRepository { get; }
        Task Save();
    }
}
