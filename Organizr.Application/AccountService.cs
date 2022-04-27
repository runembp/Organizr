using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Organizr.Core.Entities;
using Organizr.Infrastructure.DTO;
using Organizr.Infrastructure.Models;

namespace Organizr.Core.Services;

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

    [AllowAnonymous]
    public async Task<bool> RegisterUser(RegisterUserQuery query)
    {
        var user = new OrganizrUser
        {
            UserName = query.Email,
            Email = query.Email,
        };

        var result = await _userManager.CreateAsync(user, query.Password);

        return result.Succeeded;
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
        response.Token = GenerateToken(user);
        response.Succeeded = signInResult.Succeeded;

        return response;
    }
    
    private string GenerateToken(OrganizrUser userInfo)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, userInfo.UserName)
            }),
            Expires = DateTime.UtcNow.AddMinutes(30),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        
        return tokenHandler.WriteToken(token);
    }
}