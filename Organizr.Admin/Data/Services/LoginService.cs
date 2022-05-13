using System.Net.Http.Headers;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Organizr.Admin.Data.DTO;
using Organizr.Admin.HelperClasses;

namespace Organizr.Admin.Data.Services;

public class LoginService
{
    private readonly HttpClient _httpClient;
    private readonly AuthenticationStateProvider _authenticationStateProvider;
    private readonly ILocalStorageService _localStorage;

    public LoginService(HttpClient httpClient, AuthenticationStateProvider authenticationStateProvider, ILocalStorageService localStorage)
    {
        _httpClient = httpClient;
        _authenticationStateProvider = authenticationStateProvider;
        _localStorage = localStorage;
    }

    public async Task<LoginResponse> Login(string email, string password)
    {
        var request = new LoginRequest {Email = email, Password = password};
        var response = await _httpClient.PostAsJsonAsync("api/login", request);
        var result = await response.Content.ReadFromJsonAsync<LoginResponse>() ?? new LoginResponse();

        if (!result.Succeeded)
        {
            return result;
        }
        
        await ((AuthenticationStateProviderHelperClass)_authenticationStateProvider).MarkUserAsAuthenticated(result);
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Token);

        return result;
    }

    public async Task Logout()
    {
        await _localStorage.RemoveItemAsync("authToken");
        await _localStorage.RemoveItemAsync("authEmail");
        ((AuthenticationStateProviderHelperClass)_authenticationStateProvider).MarkUserAsLoggedOut();
        _httpClient.DefaultRequestHeaders.Authorization = null;
    }
}