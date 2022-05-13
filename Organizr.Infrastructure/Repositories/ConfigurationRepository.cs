using Microsoft.EntityFrameworkCore;
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

    public async Task<List<Configuration>> GetConfigurationsOfConfigType(ConfigType configType)
    {
        return await _organizrContext.Configurations.Where(x => x.ConfigType == configType).ToListAsync();
    }

    public async Task<int> UpdateConfigurationOfTypeConfiguration(List<Configuration> command)
    {
        var configurations = _organizrContext.Configurations.Where(x => x.ConfigType == ConfigType.Configuration).ToList();
        
        var organizationAddress = configurations.First(x => x.Id == ConfigurationIds.OrganizationAddress);
        organizationAddress.StringValue = command.First(x => x.Id == ConfigurationIds.OrganizationAddress).StringValue;
        
        var organizationPhoneNumber = configurations.First(x => x.Id == ConfigurationIds.OrganizationPhoneNumber);
        organizationPhoneNumber.StringValue = command.First(x => x.Id == ConfigurationIds.OrganizationPhoneNumber).StringValue;
        
        var organizationEmail = configurations.First(x => x.Id == ConfigurationIds.OrganizationEmailAddress);
        organizationEmail.StringValue = command.First(x => x.Id == ConfigurationIds.OrganizationEmailAddress).StringValue;
        
        var predeterminedGroupForNewMember = configurations.First(x => x.Id == ConfigurationIds.PredeterminedGroupToAssignNewMembersTo);
        predeterminedGroupForNewMember.IdValue = command.First(x => x.Id == ConfigurationIds.PredeterminedGroupToAssignNewMembersTo).IdValue;
        
        var activateCommentsOnNews = configurations.First(x => x.Id == ConfigurationIds.ActivateCommentsOnNews);
        activateCommentsOnNews.BoolValue = command.First(x => x.Id == ConfigurationIds.ActivateCommentsOnNews).BoolValue;
        
        var activateAdministratorCommentsOnNews = configurations.First(x => x.Id == ConfigurationIds.ActivateAdministratorMemberAbilityToCommentOnNews);
        activateAdministratorCommentsOnNews.BoolValue = command.First(x => x.Id == ConfigurationIds.ActivateAdministratorMemberAbilityToCommentOnNews).BoolValue;
        
        var activateBasicMemberCommentsOnNews = configurations.First(x => x.Id == ConfigurationIds.ActivateBasicMemberAbilityToCommentOnNews);
        activateBasicMemberCommentsOnNews.BoolValue = command.First(x => x.Id == ConfigurationIds.ActivateBasicMemberAbilityToCommentOnNews).BoolValue;
        
        var activateAbilityForAllMembersToCreateNews = configurations.First(x => x.Id == ConfigurationIds.ActivateAbilityForAllMembersToCreateNews);
        activateAbilityForAllMembersToCreateNews.BoolValue = command.First(x => x.Id == ConfigurationIds.ActivateAbilityForAllMembersToCreateNews).BoolValue;
        
        return await _organizrContext.SaveChangesAsync();
    }

    public async Task<int> UpdateConfigurationOfTypePageSetup(List<Configuration> command)
    {
        var pageSetupConfigurations = _organizrContext.Configurations.Where(x => x.ConfigType == ConfigType.PageSetup);

        var frontPageConfiguration = pageSetupConfigurations.First(x => x.Id == ConfigurationIds.FrontpageTopTextBox);
        frontPageConfiguration.StringValue = command.First(x => x.Id == ConfigurationIds.FrontpageTopTextBox).StringValue;
        
        var createMembershipConfiguration = pageSetupConfigurations.First(x => x.Id == ConfigurationIds.CreateMembershipTopText);
        createMembershipConfiguration.StringValue = command.First(x => x.Id == ConfigurationIds.CreateMembershipTopText).StringValue;
        
        var aboutUsConfiguration = pageSetupConfigurations.First(x => x.Id == ConfigurationIds.AboutUsPage);
        aboutUsConfiguration.StringValue = command.First(x => x.Id == ConfigurationIds.AboutUsPage).StringValue;
        
        var contactConfiguration = pageSetupConfigurations.First(x => x.Id == ConfigurationIds.ContactPageTopTextBox);
        contactConfiguration.StringValue = command.First(x => x.Id == ConfigurationIds.ContactPageTopTextBox).StringValue;

        return await _organizrContext.SaveChangesAsync();
    }

    public async Task<int> UpdateConfigurationOfTypeCssSetup(List<Configuration> command)
    {
        var cssConfiguration = _organizrContext.Configurations.First(x => x.Id == ConfigurationIds.MemberApplicationCss);
        cssConfiguration.StringValue = command.First(x => x.Id == ConfigurationIds.MemberApplicationCss).StringValue;
        
        return await _organizrContext.SaveChangesAsync();
    }
}