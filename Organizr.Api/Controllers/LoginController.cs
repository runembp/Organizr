using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Requests;
using Organizr.Application.Responses;

namespace Organizr.Api.Controllers;

[AllowAnonymous]
[ApiController]
[Route("api/login")]
public class LoginController : ControllerBase
{
    private readonly IMediator _mediator;

    public LoginController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserLoginResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login([FromBody] UserLoginRequest loginRequest)
    {
        var response = await _mediator.Send(loginRequest);

        if (!response.Succeeded)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
}