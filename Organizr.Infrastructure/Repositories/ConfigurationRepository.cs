using Microsoft.EntityFrameworkCore;
using Organizr.Core.Entities;
using Organizr.Core.Enums;
using Organizr.Core.IRepositories;
using Organizr.Infrastructure.Data;

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
}