using Blazored.LocalStorage;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using MediatR;
using Microsoft.AspNetCore.Components.Authorization;
using Organizr.Application.Handlers.CommandHandlers;
using Organizr.Application.HelperClasses;
using Organizr.Application.Requests;
using Organizr.Application.Responses;
using Organizr.Core.Repositories;
using Organizr.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

ApplicationDatabaseInitializerHelperClass.SetUpDatabaseAndIdentity(builder);

MandatoryServices();
DependencyInjections();
ApplicationSetup();

void MandatoryServices()
{
    builder.Services.AddRazorPages();
    builder.Services.AddServerSideBlazor();
    builder.Services.AddMediatR(typeof(Program));
    builder.Services.AddAutoMapper(typeof(Program));
    builder.Services.AddBlazoredLocalStorage();
    builder.Services
        .AddBlazorise(options =>
        {
            options.Immediate = true;
        })
        .AddBootstrapProviders()
        .AddFontAwesomeIcons();
    builder.Services.AddAuthentication();
    builder.Services.AddAuthorization();
}

void DependencyInjections()
{
    builder.Services.AddScoped(_ => new HttpClient());
    builder.Services.AddScoped<TokenHelperClass>();
    builder.Services.AddScoped<AuthenticationStateProvider, AuthenticationStateProviderHelperClass>();
    builder.Services.AddScoped<AuthenticationHelperClass>();
    builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
    builder.Services.AddScoped<IOrganizrUserRepository, OrganizrUserRepository>();
    builder.Services.AddTransient<IRequestHandler<RegisterUserCommand, RegisterUserResponse>, RegisterOrganizationAdministratorCommandHandler>();
}

void ApplicationSetup()
{
    var app = builder.Build();
    
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        app.UseHsts();
    }
    
    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseRouting();
    app.MapBlazorHub();
    app.MapFallbackToPage("/_Host");

    // Seed Roles and Users to Database
    ApplicationDatabaseInitializerHelperClass.SeedRolesToDb(app).Wait();
    ApplicationDatabaseInitializerHelperClass.SeedMandatoryUsersToDatabase(app).Wait();

    app.Run();
}