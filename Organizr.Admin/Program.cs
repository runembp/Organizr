using Blazored.LocalStorage;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Blazorise.RichTextEdit;
using Microsoft.AspNetCore.Components.Authorization;
using Organizr.Admin.Data.HelperClasses;
using Organizr.Admin.Data.Services;

var builder = WebApplication.CreateBuilder(args);
RunBuilderSetup();
RunApplicationSetup();

void RunBuilderSetup()
{
    builder.Services.AddAuthentication();
    builder.Services.AddAuthorization();
    builder.Services.AddRazorPages();
    builder.Services.AddServerSideBlazor();
    builder.Services.AddBlazoredLocalStorage();
    builder.Services.AddBlazorise(options => { options.Immediate = true; });
    builder.Services.AddBlazoriseRichTextEdit();
    builder.Services.AddBootstrapProviders();
    builder.Services.AddFontAwesomeIcons();
    
    //TODO Change in production
    builder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri("https://localhost:7157")});
    builder.Services.AddScoped<MemberService>();
    builder.Services.AddScoped<GroupService>();
    builder.Services.AddScoped<ConfigurationService>();

    builder.Services.AddScoped<AuthenticationStateProvider, AuthenticationStateProviderHelperClass>();
    builder.Services.AddScoped<LoginService>();
}

void RunApplicationSetup()
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
    app.Run();
}