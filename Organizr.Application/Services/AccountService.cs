using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Organizr.Application.Commands;
using Organizr.Application.Queries;
using Organizr.Application.Responses;
using Organizr.Core.ApplicationConstants;
using Organizr.Core.Entities;
using Organizr.Infrastructure.DTO;
using System.IdentityModel.Tokens.Jwt;
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

    public async Task<RegisterUserResponse> RegisterOrganizationAdministrator(RegisterUserQuery query)
    {
        var user = new OrganizrUser
        {
            UserName = "organizationadministrator@organizr.com",
            Email = "organizationadministrator@organizr.com",
            //Password = "Orgadmin1+",
            FirstName = "OrgAdmin",
            LastName = "Istrator",
            Address = ""
        };

        var result = await _userManager.CreateAsync(user, user.Password);

        var roleResult = new IdentityResult();

        if (result.Succeeded)
        {
            roleResult = await _userManager.AddToRoleAsync(user, ApplicationConstants.OrganizationAdministrator);
        }

        return new RegisterUserResponse
        {
            Succeeded = roleResult.Succeeded,
            Errors = roleResult.Errors
        };
    }

    [AllowAnonymous]
    public async Task<RegisterUserResponse> RegisterUser(CreateOrganizrUserCommand command)
    {
        var user = new OrganizrUser
        {
            UserName = command.Email,
            Email = command.Email,
            FirstName = command.FirstName,
            LastName = command.LastName,
            Address = command.LastName,
        };

        var result = await _userManager.CreateAsync(user, command.Password);

        return new RegisterUserResponse
        {
            Succeeded = result.Succeeded,
            Errors = result.Errors
        };
    }

    [AllowAnonymous]
    public async Task<LoginUserResponse> Login(LoginUserQuery query)
    {
        var user = await _userManager.FindByEmailAsync(query.Email);

        var response = new LoginUserResponse();

        if (user is null)
        {
            response.Succeeded = false;
            return response;
        }

        var signInResult = await _signInManager.PasswordSignInAsync(user, query.Password, false, false);

        if (!signInResult.Succeeded)
        {
            response.Succeeded = false;
            return response;
        }

        response.Username = query.Email;
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