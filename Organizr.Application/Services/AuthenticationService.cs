using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Organizr.Application.Queries;
using Organizr.Core.ApplicationConstants;
using Organizr.Infrastructure.DTO;

namespace Organizr.Application.Services;

public class AuthenticationService
{
    private readonly AuthenticationStateProvider _authenticationStateProvider;
    private readonly AccountService _accountService;
    private readonly ILocalStorageService _localStorage;
    private readonly HttpClient _httpClient;

    public AuthenticationService(AuthenticationStateProvider authenticationStateProvider, ILocalStorageService localStorage, AccountService accountService, HttpClient httpClient)
    {
        _authenticationStateProvider = authenticationStateProvider;
        _localStorage = localStorage;
        _accountService = accountService;
        _httpClient = httpClient;
    }
    
    public async Task<string> GetAuthenticatedUsername()
    {
        var authenticateState = await _authenticationStateProvider.GetAuthenticationStateAsync();

        return authenticateState.User.Identity?.Name ?? string.Empty;
    }

    public async Task<LoginUserResponse?> Login(LoginUserQuery query)
    {
        var response = await _accountService.Login(query);
        
        if (!response.Succeeded)
        {
            return response;
        }
        
        await _localStorage.RemoveItemAsync("authToken");
        await _localStorage.RemoveItemAsync("authEmail");
        await _localStorage.SetItemAsync("authToken", response.Token);
        await _localStorage.SetItemAsync("authEmail", response.Email);
        
        ((ApiAuthenticationStateProvider) _authenticationStateProvider).MarkUserAsAuthenticated(query.Email);
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", response.Token);

        return response;
    }

    public async Task<LoginUserResponse> LoginAsOrganizationAdministrator(LoginUserQuery query)
    {
        var response = await _accountService.LoginAsOrganizationAdministrator(query);

        if (!response.Succeeded)
        {
            return response;
        }

        await _localStorage.RemoveItemAsync("authToken");
        await _localStorage.RemoveItemAsync("authEmail");
        await _localStorage.SetItemAsync("authToken", response.Token);
        await _localStorage.SetItemAsync("authEmail", response.Email);

        ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(query.Email);
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", response.Token);

        return response;
    }

    public async Task Logout()
    {
        await _localStorage.RemoveItemAsync("authToken");
        await _localStorage.RemoveItemAsync("authEmail");
        ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
        _httpClient.DefaultRequestHeaders.Authorization = null;
    }
}