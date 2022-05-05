using Organizr.Domain.Entities;

namespace Organizr.Application.Common.IRepositories;

public interface IConfigurationRepository : IRepository<Configuration>
{
    public Task<List<Configuration>> GetConfigurationsOfConfigTypeConfig();
    public Task<List<Configuration>> GetConfigurationsOfConfigTypePageSetup();
    public Task<List<Configuration>> GetConfigurationsOfConfigTypePageCssSetup();
    public Task<bool> UpdateConfigurationBasedOnIdAndStringValue(int configId, string? stringValue);
    public Task<bool> UpdateConfigurationBasedOnIdAndBoolValue(int configId, bool? boolValue);
    public Task<bool> UpdateConfigurationBasedOnIdAndIdValue(int configId, int? idValue);
}