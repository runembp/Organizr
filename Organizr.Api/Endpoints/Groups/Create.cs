using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Commands.Groups;
using Organizr.Application.Responses.Groups;
using Swashbuckle.AspNetCore.Annotations;

namespace Organizr.Api.Endpoints.Groups;

public class Create : BaseApiEndpoint
{
    public Create(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpPost("api/groups")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateMemberGroupResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerOperation(
        Summary = "Creates a Group",
        Tags = new [] {"Groups"})]
    public async Task<IActionResult> CreateNewGroup([FromBody] CreateMemberGroupCommand command)
    {
        var response = await Mediator.Send(command);

        if (!response.Succeeded)
        {
            return BadRequest(response);
        }

        return CreatedAtAction(nameof(CreateNewGroup), response);
    }
}