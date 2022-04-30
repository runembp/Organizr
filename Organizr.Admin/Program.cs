using System.Reflection;
using Blazored.LocalStorage;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using MediatR;
using Microsoft.AspNetCore.Components.Authorization;
using Organizr.Application.Services;
using Organizr.Core.ApplicationConstants;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddBlazoredLocalStorage();
builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddBootstrapProviders()
    .AddFontAwesomeIcons();

// Database and Identity
AppDbInitializer.SetUpDatabaseAndIdentity(builder);

// Dependency Injection
builder.Services.AddScoped(_ => new HttpClient {BaseAddress = new Uri(ApplicationConstants.OrganizrApi)});
builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<AuthService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

// Seed Roles to Database
AppDbInitializer.SeedRolesToDb(app).Wait();

app.Run();