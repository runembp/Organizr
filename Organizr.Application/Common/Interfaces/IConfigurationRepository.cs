using Organizr.Application.Commands.Configurations;
using Organizr.Domain.Entities;
using Organizr.Domain.Enums;

namespace Organizr.Application.Common.Interfaces;

public interface IConfigurationRepository : IRepository<Configuration>
{
    public Task<List<Configuration>> GetConfigurationsOfConfigTypeConfig(ConfigType configType);
    public Task<int> UpdateConfigurationOfTypeConfiguration(UpdateConfigurationsOfTypeConfigCommand command);
    public Task<int> UpdateConfigurationOfTypePageSetup(UpdateConfigurationsOfTypePageSetupCommand command);
}