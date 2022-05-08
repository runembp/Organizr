using Microsoft.EntityFrameworkCore;
using Organizr.Application.Commands.Configurations;
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

    public async Task<int> UpdateConfigurationOfTypeConfiguration(UpdateConfigurationsOfTypeConfigCommand command)
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
        
        return await _organizrContext.SaveChangesAsync();
    }

    public async Task<int> UpdateConfigurationOfTypePageSetup(UpdateConfigurationsOfTypePageSetupCommand command)
    {
        var pageSetupConfigurations = _organizrContext.Configurations.Where(x => x.ConfigType == ConfigType.PageSetup);

        var frontPageConfiguration = pageSetupConfigurations.First(x => x.Id == ConfigurationIds.FrontpageTopTextBox);
        frontPageConfiguration.StringValue = command.Frontpage.StringValue;
        
        var createMembershipConfiguration = pageSetupConfigurations.First(x => x.Id == ConfigurationIds.CreateMembershipTopText);
        createMembershipConfiguration.StringValue = command.CreateMembership.StringValue;
        
        var aboutUsConfiguration = pageSetupConfigurations.First(x => x.Id == ConfigurationIds.AboutUsPage);
        aboutUsConfiguration.StringValue = command.AboutUs.StringValue;
        
        var contactConfiguration = pageSetupConfigurations.First(x => x.Id == ConfigurationIds.ContactPageTopTextBox);
        contactConfiguration.StringValue = command.Contact.StringValue;

        return await _organizrContext.SaveChangesAsync();
    }
}