using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Organizr.Core.Entities;

namespace Organizr.Application.Services;

public static class AppDbInitializer
{
    /// <summary>
    /// Makes sure that we always have the established Organizr Roles on the database
    /// </summary>
    /// <param name="builder"></param>
    public static async Task SeedRolesToDb(IApplicationBuilder builder)
    {
        using var serviceScope = builder.ApplicationServices.CreateScope();

        var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        if (!await roleManager.RoleExistsAsync(OrganizrRole.OrganizationAdministrator))
        {
            await roleManager.CreateAsync(new IdentityRole(OrganizrRole.OrganizationAdministrator));
        }
        
        if (!await roleManager.RoleExistsAsync(OrganizrRole.Administrator))
        {
            await roleManager.CreateAsync(new IdentityRole(OrganizrRole.Administrator));
        }
        
        if (!await roleManager.RoleExistsAsync(OrganizrRole.Basic))
        {
            await roleManager.CreateAsync(new IdentityRole(OrganizrRole.Basic));
        }
    }
}