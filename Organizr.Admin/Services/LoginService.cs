using System.Net.Http.Headers;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Organizr.Admin.HelperClasses;
using Organizr.Domain.ApplicationConstants;

namespace Organizr.Admin.Services;

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

    public async Task<Tuple<string, bool, string>> Login(string email, string password)
    {
        var request = (Email: email, Password: password);
        var response = await _httpClient.PostAsJsonAsync(ApiEndpoints.Login, request);
        var result = await response.Content.ReadFromJsonAsync<Tuple<string, bool, string>>();

        await ((AuthenticationStateProviderHelperClass)_authenticationStateProvider).MarkUserAsAuthenticated(result!);
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result!.Item3);

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