using System.Net.Http.Headers;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Organizr.Application.Requests;
using Organizr.Application.Responses;
using Organizr.Core.Repositories;

namespace Organizr.Application.HelperClasses;

public class AuthenticationHelperClass
{
    private readonly HttpClient _httpClient;
    private readonly AuthenticationStateProvider _authenticationStateProvider;
    private readonly ILocalStorageService _localStorage;
    private readonly IUnitOfWork _unitOfWork;
    private readonly TokenHelperClass _tokenHelperClass;

    public AuthenticationHelperClass(HttpClient httpClient, AuthenticationStateProvider authenticationStateProvider, ILocalStorageService localStorage, IUnitOfWork unitOfWork, TokenHelperClass tokenHelperClass)
    {
        _httpClient = httpClient;
        _authenticationStateProvider = authenticationStateProvider;
        _localStorage = localStorage;
        _unitOfWork = unitOfWork;
        _tokenHelperClass = tokenHelperClass;
    }

    public async Task<UserLoginResponse> Login(UserLoginRequest request)
    {
        var user = await _unitOfWork.UserManager.FindByEmailAsync(request.Email);
        var response = new UserLoginResponse { Succeeded = false};
        var signInResult = await _unitOfWork.SignInManager.CheckPasswordSignInAsync(user, request.Password, false);
        
        if (!signInResult.Succeeded)
        {
            return response;
        } 

        response.Succeeded = signInResult.Succeeded;
        response.Email = user.Email;
        response.Token = _tokenHelperClass.GenerateToken(user);

        await ((AuthenticationStateProviderHelperClass)_authenticationStateProvider).MarkUserAsAuthenticated(response);
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", response.Token);

        return response;
    }

    public async Task Logout()
    {
        await _localStorage.RemoveItemAsync("authToken");
        await _localStorage.RemoveItemAsync("authEmail");
        ((AuthenticationStateProviderHelperClass)_authenticationStateProvider).MarkUserAsLoggedOut();
        _httpClient.DefaultRequestHeaders.Authorization = null;
    }
}