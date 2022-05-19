using MediatR;
using Organizr.Application.Commands;
using Organizr.Application.Commands.Configurations;
using Organizr.Application.Commands.Groups;
using Organizr.Application.Commands.Members;
using Organizr.Application.Common.Interfaces;
using Organizr.Application.Handlers.CommandHandlers;
using Organizr.Application.Handlers.CommandHandlers.Configurations;
using Organizr.Application.Handlers.CommandHandlers.Groups;
using Organizr.Application.Handlers.CommandHandlers.Members;
using Organizr.Application.Handlers.RequestHandlers;
using Organizr.Application.Handlers.RequestHandlers.Configurations;
using Organizr.Application.Handlers.RequestHandlers.Groups;
using Organizr.Application.Handlers.RequestHandlers.Members;
using Organizr.Application.Handlers.RequestHandlers.Memberships;
using Organizr.Application.Handlers.RequestHandlers.News;
using Organizr.Application.HelperClasses;
using Organizr.Application.Requests;
using Organizr.Application.Requests.Configurations;
using Organizr.Application.Requests.Groups;
using Organizr.Application.Requests.Members;
using Organizr.Application.Requests.Memberships;
using Organizr.Application.Requests.News;
using Organizr.Application.Responses;
using Organizr.Application.Responses.Groups;
using Organizr.Application.Responses.Member;
using Organizr.Domain.Entities;
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
        AddMediatrRequests(builder);
        AddMediatrCommands(builder);
    }

    private static void AddRepositories(WebApplicationBuilder builder)
    {

        builder.Services.AddScoped<IMemberRepository, MemberRepository>();
        builder.Services.AddScoped<IMemberGroupRepository, MemberGroupRepository>();
        builder.Services.AddScoped<IConfigurationRepository, ConfigurationRepository>();
        builder.Services.AddScoped<IMembershipRepository, MembershipRepository>();
        builder.Services.AddScoped<INewsRepository, NewsRepository>();
    }

    private static void AddMediatrRequests(WebApplicationBuilder builder)
    {
        // Login
        builder.Services.AddTransient<IRequestHandler<UserLoginRequest, UserLoginResponse>, UserLoginHandler>();

        // Members
        builder.Services.AddTransient<IRequestHandler<GetAllMembersRequest, List<Member>>, GetAllMembersHandler>();
        builder.Services.AddTransient<IRequestHandler<GetMemberWithGroupsByIdRequest, Member?>, GetMemberWithGroupsByIdHandler>();

        // Groups
        builder.Services.AddTransient<IRequestHandler<GetAllMemberGroupsRequest, List<MemberGroup>>, GetAllMemberGroupsHandler>();
        builder.Services.AddTransient<IRequestHandler<GetMemberGroupByIdRequest, MemberGroup>, GetMemberGroupByIdHandler>();
        builder.Services.AddTransient<IRequestHandler<GetMemberGroupWithMembersByIdRequest, MemberGroup?>, GetMemberGroupWithMembersByIdHandler>();
        builder.Services.AddTransient<IRequestHandler<GetAllMemberGroupsWithNoMembershipOfMemberRequest, List<MemberGroup>>, GetAllMemberGroupsWithNoMembershipOfMemberHandler>();

        // Configurations
        builder.Services.AddTransient<IRequestHandler<GetAllConfigurationsRequest, List<Configuration>>, GetAllConfigurationsRequestHandler>();
        builder.Services.AddTransient<IRequestHandler<GetAllConfigurationsOfTypeRequest, List<Configuration>>, GetAllConfigurationsOfTypeHandler>();

        // Memberships
        builder.Services.AddTransient<IRequestHandler<GetAllMembershipsRequest, List<Membership>>, GetAllMembershipsHandler>();

    }

    private static void AddMediatrCommands(WebApplicationBuilder builder)
    {
        // Members
        builder.Services.AddTransient<IRequestHandler<CreateMemberCommand, CreateMemberResponse>, CreateMemberCommandHandler>();
        builder.Services.AddTransient<IRequestHandler<DeleteMemberCommand, DeleteMemberResponse>, DeleteMemberHandler>();
        builder.Services.AddTransient<IRequestHandler<UpdateMemberCommand, UpdateMemberResponse>, UpdateMemberHandler>();
        builder.Services.AddTransient<IRequestHandler<AddMemberToMemberGroupCommand, AddMemberToMemberGroupResponse>, AddMemberToMemberGroupHandler>();

        // Groups
        builder.Services.AddTransient<IRequestHandler<CreateMemberGroupCommand, CreateMemberGroupResponse>, CreateGroupCommandHandler>();
        builder.Services.AddTransient<IRequestHandler<AddMemberToMemberGroupCommand, AddMemberToMemberGroupResponse>, AddMemberToMemberGroupHandler>();
        builder.Services.AddTransient<IRequestHandler<DeleteMemberGroupCommand, DeleteMemberGroupResponse>, DeleteGroupHandler>();
        builder.Services.AddTransient<IRequestHandler<RemoveMemberFromGroupCommand, RemoveMemberFromGroupResponse>, RemoveMemberFromGroupHandler>();
        builder.Services.AddTransient<IRequestHandler<UpdateMemberGroupCommand, UpdateMemberGroupResponse>, UpdateMemberGroupHandler>();

        // Configurations
        builder.Services.AddTransient<IRequestHandler<UpdateConfigurationsOfTypeCommand, List<Configuration>>, UpdateConfigurationsOfTypeHandler>();
    }
}