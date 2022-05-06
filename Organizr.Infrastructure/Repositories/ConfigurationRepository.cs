using Microsoft.EntityFrameworkCore;
using Organizr.Application.Commands;
using Organizr.Application.Common.Interfaces;
using Organizr.Domain.ApplicationConstants;
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

    public async Task<bool> UpdateConfigurationOfTypeConfiguration(UpdateConfigurationsOfTypeConfigCommand command)
    {
        var configurations = _organizrContext.Configurations.Where(x => x.ConfigType == ConfigType.Configuration).ToList();
        
        var organizationAddress = configurations.First(x => x.Id == ConfigurationIds.OrganizationAddress);
        organizationAddress.StringValue = command.OrganizationAddress;
        
        var organizationPhoneNumber = configurations.First(x => x.Id == ConfigurationIds.OrganizationPhoneNumber);
        organizationPhoneNumber.StringValue = command.OrganizationPhoneNumber;
        
        var organizationEmail = configurations.First(x => x.Id == ConfigurationIds.OrganizationEmailAddress);
        organizationEmail.StringValue = command.OrganizationEmailAddress;
        
        var predeterminedGroupForNewMember = configurations.First(x => x.Id == ConfigurationIds.PredeterminedGroupToAssignNewMembersTo);
        predeterminedGroupForNewMember.IdValue = command.PredeterminedGroupToAssignNewMembersTo;
        
        var activateCommentsOnNews = configurations.First(x => x.Id == ConfigurationIds.ActivateCommentsOnNews);
        activateCommentsOnNews.BoolValue = command.ActivateCommentsOnNews;
        
        var activateAdministratorCommentsOnNews = configurations.First(x => x.Id == ConfigurationIds.ActivateAdministratorMemberAbilityToCommentOnNews);
        activateAdministratorCommentsOnNews.BoolValue = command.ActivateAdministratorMemberAbilityToCommentOnNews;
        
        var activateBasicMemberCommentsOnNews = configurations.First(x => x.Id == ConfigurationIds.ActivateBasicMemberAbilityToCommentOnNews);
        activateBasicMemberCommentsOnNews.BoolValue = command.ActivateBasicMemberAbilityToCommentOnNews;
        
        var activateAbilityForAllMembersToCreateNews = configurations.First(x => x.Id == ConfigurationIds.ActivateAbilityForAllMembersToCreateNews);
        activateAbilityForAllMembersToCreateNews.BoolValue = command.ActivateAbilityForAllMembersToCreateNews;
        
        await _organizrContext.SaveChangesAsync();
        return true;
    }
}