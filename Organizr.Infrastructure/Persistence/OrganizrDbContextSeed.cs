using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Organizr.Domain.ApplicationConstants;
using Organizr.Domain.Entities;

namespace Organizr.Infrastructure.Persistence;

public static class OrganizrDbContextSeed
{


    /// <summary>
    /// Makes sure that we always have the established Organization Administrator role on the database
    /// </summary>
    /// <param name="builder"></param>
    public static async Task SeedRolesToDb(IApplicationBuilder builder)
    {
        using var serviceScope = builder.ApplicationServices.CreateScope();

        var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<OrganizrRole>>();

        if (!await roleManager.RoleExistsAsync(ApplicationConstants.OrganizationAdministrator))
        {
            await roleManager.CreateAsync(new OrganizrRole(ApplicationConstants.OrganizationAdministrator));
        }
    }

    /// <summary>
    /// Makes sure we always have an OrganizationAdministrator in the Database
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    //TODO Remove in production
    public static async Task SeedMandatoryMembersToDatabase(IApplicationBuilder builder)
    {
        using var serviceScope = builder.ApplicationServices.CreateScope();

        const string organizationAdministratorEmail = "organizationadministrator@organizr.com";
        var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<Member>>();

        var organizationAdminUserFromDatabase = await userManager.FindByEmailAsync(organizationAdministratorEmail);

        if (organizationAdminUserFromDatabase is null)
        {
            var organizationAdministrator = new Member
            {
                UserName = organizationAdministratorEmail,
                Email = organizationAdministratorEmail
            };

            const string organizationAdminPassword = "Orgadmin1+";
            await userManager.CreateAsync(organizationAdministrator, organizationAdminPassword);
            await userManager.AddToRoleAsync(organizationAdministrator, ApplicationConstants.OrganizationAdministrator);
        }
    }
}