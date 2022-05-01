using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Organizr.Application.Queries;
using Organizr.Application.Responses;
using Organizr.Core.Entities;
using Organizr.Core.Repositories;

namespace Organizr.Application.HelperClasses;

public class AuthenticationHelperClass : AuthenticationStateProvider
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorage;
    private readonly IConfiguration _configuration;

    public AuthenticationHelperClass(IUnitOfWork unitOfWork, HttpClient httpClient, ILocalStorageService localStorage, IConfiguration configuration)
    {
        _unitOfWork = unitOfWork;
        _httpClient = httpClient;
        _localStorage = localStorage;
        _configuration = configuration;
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

    public async Task HandleLocalStorageAuthentication(UserLoginRequest request, UserLoginResponse response)
    {
        await _localStorage.RemoveItemAsync("authToken");
        await _localStorage.RemoveItemAsync("authEmail");
        await _localStorage.SetItemAsync("authToken", response.Token);
        await _localStorage.SetItemAsync("authEmail", response.Email);

        MarkUserAsAuthenticated(request.Email);
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", response.Token);
    }
    
    public async Task<string> GenerateToken(OrganizrUser user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

        var authClaims = new List<Claim>
        {
            new (ClaimTypes.Name, user.UserName)
        };
        var userRoles = await _unitOfWork.UserManager.GetRolesAsync(user);
        authClaims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(authClaims),
            Expires = DateTime.UtcNow.AddMinutes(30),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
    
    public async Task Logout()
    {
        await _localStorage.RemoveItemAsync("authToken");
        await _localStorage.RemoveItemAsync("authEmail");
        MarkUserAsLoggedOut();
        _httpClient.DefaultRequestHeaders.Authorization = null;
    }

    public void MarkUserAsAuthenticated(string email)
    {
        var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, email) }, "apiauth"));
        var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
        NotifyAuthenticationStateChanged(authState);
    }

    private void MarkUserAsLoggedOut()
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