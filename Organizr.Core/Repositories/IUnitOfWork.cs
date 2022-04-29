namespace Organizr.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IOrganizrUserRepository OrganizrUserRepository { get; }

    }
}
