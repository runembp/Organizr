using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Organizr.Application.Services;
using Organizr.Domain.ApplicationConstants;
using Organizr.Domain.Entities;
using System.Text;

namespace Organizr.Infrastructure.Persistence;

public class DependencyInjection
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
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KeyVaultService.GetSecret("JwtKey", builder))),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = false
                };
            });
        builder.Services.AddAuthentication();
        builder.Services.AddAuthorization();
    }
}