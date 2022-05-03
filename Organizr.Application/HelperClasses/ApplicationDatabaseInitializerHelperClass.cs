using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Organizr.Core.ApplicationConstants;
using Organizr.Core.Entities;
using Organizr.Infrastructure.Data;
using Organizr.Infrastructure.Services;
using System.Text;

namespace Organizr.Application.HelperClasses;

public static class ApplicationDatabaseInitializerHelperClass
{
    /// <summary>
    /// Sets up the Organizr Database with the recieved ConnectionString from appsettings.json and
    /// sets up the database with AspNet.Core Identity with the associated Roles and JWT Bearer token authentication.
    /// </summary>
    /// <param name="builder"></param>
    public static void SetUpDatabaseAndIdentity(WebApplicationBuilder builder)
    {

        builder.Services.AddDbContext<OrganizrDbContext>(options =>
        {
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection"),
                sqlOptions => sqlOptions.MigrationsAssembly(ApplicationConstants.OrganizrInfrastructureProject));
        });

        // Identity
        builder.Services.AddIdentity<OrganizrUser, OrganizrRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.User.RequireUniqueEmail = true;
            })
            .AddRoleManager<RoleManager<OrganizrRole>>()
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<OrganizrDbContext>()
            .AddRoles<OrganizrRole>();
        builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KeyVaultService.GetSecret("JwtKey", builder))),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false
                };
            });
        builder.Services.AddAuthorization();
    }

    /// <summary>
    /// Makes sure that we always have the established Organizr Roles on the database
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

        if (!await roleManager.RoleExistsAsync(ApplicationConstants.Administrator))
        {
            await roleManager.CreateAsync(new OrganizrRole(ApplicationConstants.Administrator));
        }

        if (!await roleManager.RoleExistsAsync(ApplicationConstants.Basic))
        {
            await roleManager.CreateAsync(new OrganizrRole(ApplicationConstants.Basic));
        }
    }

    /// <summary>
    /// Makes sure we always have an OrganizationAdministrator in the Database
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    //TODO Remove before production
    public static async Task SeedMandatoryUsersToDatabase(IApplicationBuilder builder)
    {
        using var serviceScope = builder.ApplicationServices.CreateScope();

        const string organizationAdministratorEmail = "organizationadministrator@organizr.com";
        var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<OrganizrUser>>();

        var organizationAdminUserFromDatabase = await userManager.FindByEmailAsync(organizationAdministratorEmail);

        if (organizationAdminUserFromDatabase is null)
        {
            var organizationAdministrator = new OrganizrUser
            {
                UserName = organizationAdministratorEmail,
                Email = organizationAdministratorEmail,
                ConfigRefreshPrivilege = true,
            };

            const string organizationAdminPassword = "Orgadmin1+";
            await userManager.CreateAsync(organizationAdministrator, organizationAdminPassword);
            await userManager.AddToRoleAsync(organizationAdministrator, ApplicationConstants.OrganizationAdministrator);
        }
    }
}