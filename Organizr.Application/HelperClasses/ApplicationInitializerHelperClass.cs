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
using MediatR;
using Organizr.Application.Commands;
using Organizr.Application.Handlers.CommandHandlers;
using Organizr.Application.Handlers.RequestHandlers;
using Organizr.Application.Handlers.RequestHandlers.Configurations;
using Organizr.Application.Requests;
using Organizr.Application.Requests.Configurations;
using Organizr.Application.Responses;
using Organizr.Application.Responses.Configurations;
using Organizr.Core.IRepositories;
using Organizr.Infrastructure.Repositories;

namespace Organizr.Application.HelperClasses;

public static class ApplicationInitializerHelperClass
{
    /// <summary>
    /// Sets up the Organizr Database with the recieved ConnectionString from appsettings.json and
    /// sets up the database with AspNet.Core Identity with the associated Roles and JWT Bearer token authentication.
    /// </summary>
    /// <param name="builder"></param>
    public static async Task SetUpDatabaseAndIdentity(WebApplicationBuilder builder)
    {
        var secret = await KeyVaultService.GetSecretFromBuilder(builder);
        
        builder.Services.AddDbContext<OrganizrDbContext>(options =>
        {
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("TestDatabase"),
                sqlOptions => sqlOptions.MigrationsAssembly(ApplicationConstants.OrganizrInfrastructureProject));
        });

        // Identity
        builder.Services.AddIdentity<Member, OrganizrRole>(options =>
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
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false
                };
            });
        builder.Services.AddAuthentication();
        builder.Services.AddAuthorization();
    }

    /// <summary>
    /// Makes sure we always have the same shared dependencies across Organizr.Api and Organizr.Admin
    /// </summary>
    /// <param name="builder"></param>
    public static void AddSharedDependencyInjections(WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        builder.Services.AddScoped<TokenHelperClass>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<IMemberRepository, MemberRepository>();
        builder.Services.AddScoped<IMemberGroupRepository, MemberGroupRepository>();
        builder.Services.AddScoped<IConfigurationRepository, ConfigurationRepository>();
        builder.Services.AddTransient<IRequestHandler<CreateMemberCommand, CreateMemberResponse>, CreateMemberCommandHandler>();
        builder.Services.AddTransient<IRequestHandler<CreateMemberGroupCommand, CreateMemberGroupResponse>, CreateMemberGroupCommandHandler>();
        builder.Services.AddTransient<IRequestHandler<GetAllMembersRequest, List<Member>>, GetAllMembersHandler>();
        builder.Services.AddTransient<IRequestHandler<GetAllMemberGroupsRequest, GetAllMemberGroupsResponse>, GetAllMemberGroupsHandler>();
        builder.Services.AddTransient<IRequestHandler<GetAllConfigurationsOfTypeConfigurationRequest, GetAllConfigurationsOfTypeConfigurationResponse>, GetAllConfigurationsOfTypeConfigurationHandler>(); 
    }

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
                Email = organizationAdministratorEmail,
                ConfigRefreshPrivilege = true,
            };

            const string organizationAdminPassword = "Orgadmin1+";
            await userManager.CreateAsync(organizationAdministrator, organizationAdminPassword);
            await userManager.AddToRoleAsync(organizationAdministrator, ApplicationConstants.OrganizationAdministrator);
        }
    }
}