using Organizr.Domain.Entities;
using Organizr.Domain.Enums;

namespace Organizr.Application.Common.Interfaces;

public interface IConfigurationRepository : IRepository<Configuration>
{
    public Task<List<Configuration>> GetConfigurationsOfConfigType(ConfigType configType);
    public Task<int> UpdateConfigurationOfTypeConfiguration(List<Configuration> command);
    public Task<int> UpdateConfigurationOfTypePageSetup(List<Configuration> command);
    public Task<int> UpdateConfigurationOfTypeCssSetup(List<Configuration> command);
}