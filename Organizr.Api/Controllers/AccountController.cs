using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Organizr.Core.Services;
using Organizr.Infrastructure.DTO;

namespace Organizr.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
    private readonly AccountService _accountService;

    public AccountController(AccountService accountService)
    {
        _accountService = accountService;
    }
    
    [HttpPost("Register")]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDto request)
    {
        var result = await _accountService.RegisterUser(request);

        if (!result)
        {
            return BadRequest("User could not be created");
        }

        return Ok("User has been created");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserDto request)
    {
        var result = await _accountService.Login(request);

        if (!result.Succeeded)
        {
            return BadRequest("Failed login");
        }

        return Ok(result);
    }
    
    [HttpPost("login-with-predetermined-user-and-password")]
    public async Task<IActionResult> LoginWithPredeterminedUserAndPassword()
    {
        var request = new LoginUserDto()
        {
            Email = "user@organizr.com",
            Password = "Tester1+"
        };
        
        var result = await _accountService.Login(request);

        if (!result.Succeeded)
        {
            return BadRequest("Failed login");
        }

        return Ok(result);
    }
    
    [HttpGet("TestAuth")]
    [Authorize]
    public IActionResult Test()
    {
        return Ok("If you see this, you're authorized!");
    } 
}