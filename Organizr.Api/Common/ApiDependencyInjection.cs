using MediatR;
using Organizr.Application.Common.Interfaces;
using Organizr.Application.HelperClasses;
using Organizr.Infrastructure.Repositories;

namespace Organizr.Api.Common;

public static class ApiDependencyInjection
{
    /// <summary>
    /// Makes sure we always have the same shared dependencies across Organizr.Api and Organizr.Admin
    /// </summary>
    /// <param name="builder"></param>
    public static void AddDependencyInjections(WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        builder.Services.AddScoped<TokenHelperClass>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        AddRepositories(builder);
    }

    private static void AddRepositories(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IMemberRepository, MemberRepository>();
        builder.Services.AddScoped<IMemberGroupRepository, MemberGroupRepository>();
        builder.Services.AddScoped<IConfigurationRepository, ConfigurationRepository>();
        builder.Services.AddScoped<IMembershipRepository, MembershipRepository>();
    }
}