using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Requests;
using Organizr.Application.Responses;
using Swashbuckle.AspNetCore.Annotations;

namespace Organizr.Api.Endpoints.Login;

public class Login : BaseApiEndpoint
{
    public Login(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpPost("api/login")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserLoginResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerOperation(
        Summary = "Authenticates based on username and password",
        Tags = new [] {"LoginEndpoint"})]
    public async Task<IActionResult> Handle([FromBody] UserLoginRequest loginRequest)
    {
        var response = await Mediator.Send(loginRequest);

        if (!response.Succeeded)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
}