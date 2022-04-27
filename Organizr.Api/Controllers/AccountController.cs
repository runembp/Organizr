using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Commands;
using Organizr.Application.Queries;
using Organizr.Application.Responses;
using Organizr.Application.Services;
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
    public async Task<ActionResult<RegisterUserResponse>> RegisterUser([FromBody] CreateOrganizrUserQuery query)
    {
        var result = await _accountService.RegisterUser(query);

        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        return Created("Created?" ,result);
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginUserResponse>> Login([FromBody] LoginUserQuery query)
    {
        var result = await _accountService.Login(query);

        if (!result.Succeeded)
        {
            return BadRequest("Failed login");
        }

        return Ok(result);
    }
    
    [HttpPost("RegisterOrganizationAdministrator")]
    public async Task<ActionResult<RegisterUserResponse>> RegisterOrganizationAdministrator([FromBody] RegisterUserQuery query)
    {
        var result = await _accountService.RegisterOrganizationAdministrator(query);

        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        return Ok(result.Succeeded);
    }
}