using Organizr.Application.Commands;
using Organizr.Domain.Entities;

namespace Organizr.Application.Common.Interfaces;

public interface IConfigurationRepository : IRepository<Configuration>
{
    public Task<List<Configuration>> GetConfigurationsOfConfigTypeConfig();
    public Task<List<Configuration>> GetConfigurationsOfConfigTypePageSetup();
    public Task<List<Configuration>> GetConfigurationsOfConfigTypePageCssSetup();
    public Task<bool> UpdateConfigurationOfTypeConfiguration(UpdateConfigurationsOfTypeConfigCommand command);
}