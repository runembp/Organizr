using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace Organizr.Application.Services;

public class ApiAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorage;

    public ApiAuthenticationStateProvider(HttpClient httpClient, ILocalStorageService localStorage)
    {
        _httpClient = httpClient;
        _localStorage = localStorage;
    }
    
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var savedToken = await _localStorage.GetItemAsync<string>("authToken");
        var savedName = await _localStorage.GetItemAsync<string>("authEmail") ?? string.Empty;

        if (string.IsNullOrWhiteSpace(savedToken))
        {
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", savedToken);

        return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(ParseClaimsFromJwt(savedToken, savedName), "jwt")));
    }
    
    public void MarkUserAsAuthenticated(string email)
    {
        var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, email) }, "apiauth"));
        var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
        NotifyAuthenticationStateChanged(authState);
    }

    public void MarkUserAsLoggedOut()
    {
        var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
        var authState = Task.FromResult(new AuthenticationState(anonymousUser));
        NotifyAuthenticationStateChanged(authState);
    }
    
    private static IEnumerable<Claim> ParseClaimsFromJwt(string jwt, string name)
    {
        var claims = new List<Claim>();
        var payload = jwt.Split(".")[1];
        var jsonBytes = ParseBase64WithoutPadding(payload);
        var keyValuePairs = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonBytes) ?? new Dictionary<string, object>();

        keyValuePairs.TryGetValue(ClaimTypes.Role, out var roles);

        if (roles is not null)
        {
            var rolesAsString = roles.ToString();
            if (rolesAsString is not null)
            {
                if (rolesAsString.Trim().StartsWith("["))
                {
                    var parsedRoles = JsonSerializer.Deserialize<string[]>(rolesAsString) ?? Array.Empty<string>();

                    claims.AddRange(parsedRoles.Select(parsedRole => new Claim(ClaimTypes.Role, parsedRole)));
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Role, rolesAsString));
                }
            }

            keyValuePairs.Remove(ClaimTypes.Role);
        }
        
        claims.AddRange(keyValuePairs.Select(keyValuePair => new Claim(keyValuePair.Key, keyValuePair.Value.ToString() ?? string.Empty)));
        claims.Add(new Claim(ClaimTypes.Name, name));

        return claims;
    }
    
    private static byte[] ParseBase64WithoutPadding(string base64)
    {
        switch (base64.Length % 4)
        {
            case 2: base64 += "=="; break;
            case 3: base64 += "="; break;
        }
        return Convert.FromBase64String(base64);
    }
}