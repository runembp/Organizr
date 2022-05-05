using Blazored.LocalStorage;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Blazorise.RichTextEdit;
using MediatR;
using Microsoft.AspNetCore.Components.Authorization;
using Organizr.Api.Common;
using Organizr.Application.HelperClasses;
using Organizr.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

await DependencyInjection.SetUpDatabaseAndIdentity(builder);
ApiDependencyInjection.AddSharedDependencyInjections(builder);

AddMandatoryServices();
AddApplicationSpecificDependencyInjections();
AddApplicationSetup();

void AddMandatoryServices()
{
    builder.Services.AddRazorPages();
    builder.Services.AddServerSideBlazor();
    builder.Services
        .AddMediatR(typeof(Program))
        .AddBlazorise(options => { options.Immediate = true; })
        .AddBlazoriseRichTextEdit()
        .AddBootstrapProviders()
        .AddFontAwesomeIcons()
        .AddBlazoredLocalStorage();
}

void AddApplicationSpecificDependencyInjections()
{
    builder.Services.AddScoped(_ => new HttpClient());
    builder.Services.AddScoped<AuthenticationStateProvider, AuthenticationStateProviderHelperClass>();
    builder.Services.AddScoped<AuthenticationHelperClass>();
}

void AddApplicationSetup()
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
    OrganizrDbContextSeed.SeedRolesToDb(app).Wait();
    OrganizrDbContextSeed.SeedMandatoryMembersToDatabase(app).Wait();

    app.Run();
}