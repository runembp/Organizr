using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Organizr.Application.Queries;
using Organizr.Core.ApplicationConstants;
using Organizr.Infrastructure.DTO;

namespace Organizr.Application.Services;

public class AuthService
{
    private readonly HttpClient _httpClient;
    private readonly AuthenticationStateProvider _authenticationStateProvider;
    private readonly ILocalStorageService _localStorage;

    public AuthService(HttpClient httpClient, AuthenticationStateProvider authenticationStateProvider, ILocalStorageService localStorage)
    {
        _httpClient = httpClient;
        _authenticationStateProvider = authenticationStateProvider;
        _localStorage = localStorage;
    }
    
    public async Task<string> GetAuthenticatedUsername()
    {
        var authenticateState = await _authenticationStateProvider.GetAuthenticationStateAsync();

        return authenticateState.User.Identity?.Name ?? string.Empty;
    }

    public async Task<LoginUserResponse?> Login(LoginUserQuery query)
    {
        var loginAsJson = JsonSerializer.Serialize(query);

        var response = await _httpClient.PostAsync(ApplicationConstants.LoginAsOrganisationAdministratorApiEndpoint, new StringContent(loginAsJson, Encoding.UTF8, ApplicationConstants.ApplicationJson));
        if (!response.IsSuccessStatusCode)
        {
            return new LoginUserResponse {Succeeded = false};
        }
        
        var loginResult = JsonSerializer.Deserialize<LoginUserResponse>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
        
        await _localStorage.RemoveItemAsync("authToken");
        await _localStorage.RemoveItemAsync("authEmail");
        await _localStorage.SetItemAsync("authToken", loginResult.Token);
        await _localStorage.SetItemAsync("authEmail", loginResult.Username);
        
        ((ApiAuthenticationStateProvider) _authenticationStateProvider).MarkUserAsAuthenticated(query.Email);
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", loginResult.Token);

        return loginResult;
    }

    public async Task Logout()
    {
        await _localStorage.RemoveItemAsync("authToken");
        await _localStorage.RemoveItemAsync("authEmail");
        ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
        _httpClient.DefaultRequestHeaders.Authorization = null;
    }
}