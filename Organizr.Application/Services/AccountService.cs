using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Organizr.Application.Commands;
using Organizr.Application.Requests;
using Organizr.Application.Responses;
using Organizr.Core.ApplicationConstants;
using Organizr.Core.Entities;
using Organizr.Infrastructure.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;

namespace Organizr.Application.Services;

public class AccountService
{
    private readonly UserManager<OrganizrUser> _userManager;
    private readonly SignInManager<OrganizrUser> _signInManager;
    private readonly IConfiguration _configuration;

    public AccountService(UserManager<OrganizrUser> userManager, SignInManager<OrganizrUser> signInManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _configuration = configuration;
    }

    public async Task<RegisterUserResponse> RegisterOrganizationAdministrator(RegisterUserRequest request)
    {
        var user = new OrganizrUser
        {
            UserName = request.Email,
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Address = request.Address,
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        var roleResult = new IdentityResult();

        if (result.Succeeded)
        {
            roleResult = await _userManager.AddToRoleAsync(user, ApplicationConstants.OrganizationAdministrator);
        }

        return new RegisterUserResponse
        {
            Succeeded = roleResult.Succeeded,
            Errors = roleResult.Errors.ToList()
        };
    }

    [Authorize]
    public async Task<RegisterUserResponse> RegisterUser(RegisterUserRequest request)
    {
        var response = new RegisterUserResponse();

        if(!new EmailAddressAttribute().IsValid(request.Email))
        {
            response.Errors.Add(new IdentityError { Description = "Email er ikke i et godkendt format" });
            return response;
        }

        var user = new OrganizrUser
        {
            UserName = request.Email,
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Address = request.LastName,
            Gender = request.Gender,
            PhoneNumber = request.PhoneNumber,
            ConfigRefreshPrivilege = request.ConfigRefreshPrivilege
        };

        var result = await _userManager.CreateAsync(user, request.Password);


        return new RegisterUserResponse
        {
            Succeeded = result.Succeeded,
            Errors = result.Errors.ToList()
        };
    }

    [AllowAnonymous]
    public async Task<LoginUserResponse> Login(LoginUserRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        var response = new LoginUserResponse();

        if (user is null)
        {
            response.Succeeded = false;
            return response;
        }

        var signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

        if (!signInResult.Succeeded)
        {
            response.Succeeded = false;
            return response;
        }

        response.Email = user.Email;
        response.Token = await GenerateToken(user);
        response.Succeeded = signInResult.Succeeded;

        return response;
    }

    [AllowAnonymous]
    public async Task<LoginUserResponse> LoginAsOrganizationAdministrator(LoginUserRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        var response = new LoginUserResponse();

        if (user is null)
        {
            response.Succeeded = false;
            return response;
        }

        var signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

        if (!signInResult.Succeeded)
        {
            response.Succeeded = false;
            return response;
        }

        var isOrganizationAdministrator = await _userManager.IsInRoleAsync(user, ApplicationConstants.OrganizationAdministrator);

        if (!isOrganizationAdministrator)
        {
            response.Succeeded = false;
            return response;
        }

        response.Email = request.Email;
        response.Token = await GenerateToken(user);
        response.Succeeded = signInResult.Succeeded;

        return response;
    }

    private async Task<string> GenerateToken(OrganizrUser user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

        var authClaims = new List<Claim>
        {
            new (ClaimTypes.Name, user.UserName)
        };
        var userRoles = await _userManager.GetRolesAsync(user);
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
}