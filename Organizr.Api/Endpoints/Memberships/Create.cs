using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Commands.Memberships;
using Organizr.Application.Responses.Memberships;
using Swashbuckle.AspNetCore.Annotations;

namespace Organizr.Api.Endpoints.Memberships;

public class Create : BaseApiEndpoint
{
    public Create(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpPost("api/memberships/")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateMembershipResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerOperation(
        Summary = "Creates a new membership",
        Tags = new [] {"Memberships"})]
    public async Task<IActionResult> Handle([FromBody] CreateMembershipCommand command)
    {
        var result = await Mediator.Send(command);

        if (!result.Succeeded)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
}