using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
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
    public async Task<bool> RegisterUser(RegisterUserDto request)
    {
        var user = new OrganizrUser
        {
            UserName = request.Email,
            Email = request.Email,
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        return result.Succeeded;
    }

    [AllowAnonymous]
    public async Task<LoginUserResponseDto> Login(LoginUserDto request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        var response = new LoginUserResponseDto();

        if (user is null)
        {
            response.Succeeded = false;
            return response;
        }

        var signInResult = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);

        if (!signInResult.Succeeded)
        {
            response.Succeeded = false;
            return response;
        }

        response.Username = request.Email;
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