using MediatR;
using Organizr.Application.Commands;
using Organizr.Application.Commands.Configurations;
using Organizr.Application.Common.Interfaces;
using Organizr.Application.Handlers.CommandHandlers;
using Organizr.Application.Handlers.CommandHandlers.Configurations;
using Organizr.Application.Handlers.RequestHandlers;
using Organizr.Application.Handlers.RequestHandlers.Configurations;
using Organizr.Application.HelperClasses;
using Organizr.Application.Requests.Configurations;
using Organizr.Application.Requests.Groups;
using Organizr.Application.Responses;
using Organizr.Application.Responses.Configurations;
using Organizr.Application.Responses.Groups;
using Organizr.Domain.Entities;
using Organizr.Infrastructure.Repositories;

namespace Organizr.Api.Common;

public static class ApiDependencyInjection
{
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
        
        AddRepositories(builder);
        AddMediatrRequests(builder);
        AddMediatrCommands(builder);
    }

    private static void AddRepositories(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IMemberRepository, MemberRepository>();
        builder.Services.AddScoped<IMemberGroupRepository, MemberGroupRepository>();
        builder.Services.AddScoped<IConfigurationRepository, ConfigurationRepository>();
        builder.Services.AddTransient<IRequestHandler<GetAllConfigurationsRequest, List<Configuration>>, GetAllConfigurationsRequestHandler>();
        builder.Services.AddTransient<IRequestHandler<CreateMemberCommand, CreateMemberResponse>, CreateMemberCommandHandler>();
        builder.Services.AddTransient<IRequestHandler<CreateMemberGroupCommand, CreateMemberGroupResponse>, CreateMemberGroupCommandHandler>();
    }

    private static void AddMediatrRequests(WebApplicationBuilder builder)
    {
        // Members
        builder.Services.AddTransient<IRequestHandler<GetAllMembersRequest, List<Member>>, GetAllMembersHandler>();
        
        // Groups
        builder.Services.AddTransient<IRequestHandler<GetAllMemberGroupsRequest, GetAllMemberGroupsResponse>, GetAllMemberGroupsHandler>();
        
        // Configurations
        builder.Services.AddTransient<IRequestHandler<GetAllConfigurationsOfTypeRequest, GetAllConfigurationsOfTypeResponse>, GetAllConfigurationsOfTypeHandler>();
    }

    private static void AddMediatrCommands(WebApplicationBuilder builder)
    {
        // Members
        builder.Services.AddTransient<IRequestHandler<CreateMemberCommand, CreateMemberResponse>, CreateMemberCommandHandler>();
        
        // Groups
        builder.Services.AddTransient<IRequestHandler<CreateMemberGroupCommand, CreateMemberGroupResponse>, CreateMemberGroupCommandHandler>();
        
        // Commands
        builder.Services.AddTransient<IRequestHandler<UpdateConfigurationsOfTypeConfigCommand, UpdateConfigurationsResponse>, UpdateConfigurationsOfTypeConfigHandler>();
        builder.Services.AddTransient<IRequestHandler<UpdateConfigurationsOfTypePageSetupCommand, UpdateConfigurationsResponse>, UpdateConfigurationsOfTypePageSetupHandler>();
    }
}