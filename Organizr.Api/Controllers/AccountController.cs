using System.Security.Claims;
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

        // TODO Fix this method for proper error handling
        if (result.ToLower().Contains("error"))
        {
            return BadRequest("Failed login");
        }

        return Ok(result);
    }
    
    [HttpPost("Test")]
    public async Task<IActionResult> TestGet()
    {
        var email= User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
        var userid= User.Claims.FirstOrDefault(x => x.Type == "id")?.Value;
        return Ok();
    }
}