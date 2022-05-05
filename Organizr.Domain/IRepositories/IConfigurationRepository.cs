using Organizr.Domain.Entities;

namespace Organizr.Domain.IRepositories;

public interface IConfigurationRepository : IRepository<Configuration>
{
    public Task<List<Configuration>> GetConfigurationsOfConfigTypeConfig();
    public Task<List<Configuration>> GetConfigurationsOfConfigTypePageSetup();
    public Task<List<Configuration>> GetConfigurationsOfConfigTypePageCssSetup();
}