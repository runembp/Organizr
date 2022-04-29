using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Commands;
using Organizr.Application.Queries;
using Organizr.Application.Responses;
using Organizr.Application.Services;

namespace Organizr.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly AccountService _accountService;
    public UserController(AccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("user")]
    public async Task<ActionResult<RegisterUserResponse>> RegisterUser([FromBody] CreateOrganizrUserCommand command)
    {
        var result = await _accountService.RegisterUser(command);

        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        return Created("Created?", result);
    }

    [HttpPost("organisation-administrator")]
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