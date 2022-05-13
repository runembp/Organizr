using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Requests;
using Organizr.Application.Responses;
using Organizr.Domain.ApplicationConstants;

namespace Organizr.Api.Controllers;

[AllowAnonymous]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly IMediator _mediator;

    public LoginController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route(ApiEndpoints.Login)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<UserLoginResponse>> Login([FromBody] UserLoginRequest loginRequest)
    {
        var result = await _mediator.Send(loginRequest);

        if (!result.Succeeded) return BadRequest(result);

        return Ok(result);
    }
}