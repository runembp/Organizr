using Microsoft.EntityFrameworkCore;
using Organizr.Application.Common.Interfaces;
using Organizr.Domain.Entities;
using Organizr.Domain.Enums;

using Organizr.Infrastructure.Persistence;

namespace Organizr.Infrastructure.Repositories;

public class ConfigurationRepository : Repository<Configuration>, IConfigurationRepository
{
    public ConfigurationRepository(OrganizrDbContext organizrDbContext) : base(organizrDbContext)
    {
    }

    public async Task<List<Configuration>> GetConfigurationsOfConfigTypeConfig()
    {
        return await _organizrContext.Configurations.Where(x => x.ConfigType == ConfigType.Configuration).ToListAsync();
    }

    public async Task<List<Configuration>> GetConfigurationsOfConfigTypePageSetup()
    {
        return await _organizrContext.Configurations.Where(x => x.ConfigType == ConfigType.PageSetup).ToListAsync();
    }

    public async Task<List<Configuration>> GetConfigurationsOfConfigTypePageCssSetup()
    {
        return await _organizrContext.Configurations.Where(x => x.ConfigType == ConfigType.CssSetup).ToListAsync();
    }

    public async Task<bool> UpdateConfigurationBasedOnIdAndStringValue(int configId, string? stringValue)
    {
        var config = _organizrContext.Configurations.First(x => x.Id == configId);
        
        config.StringValue = stringValue;
        
        _organizrContext.Configurations.Update(config);
        
        await _organizrContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateConfigurationBasedOnIdAndBoolValue(int configId, bool? boolValue)
    {
        var config = _organizrContext.Configurations.First(x => x.Id == configId);
        
        config.BoolValue = boolValue;
        
        _organizrContext.Configurations.Update(config);
        
        await _organizrContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateConfigurationBasedOnIdAndIdValue(int configId, int? idValue)
    {
        var config = _organizrContext.Configurations.First(x => x.Id == configId);
        
        config.IdValue = idValue;
        
        _organizrContext.Configurations.Update(config);
        
        await _organizrContext.SaveChangesAsync();

        return true;
    }
}