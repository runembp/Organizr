using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Commands.Members;
using Organizr.Application.Responses.Member;
using Swashbuckle.AspNetCore.Annotations;

namespace Organizr.Api.Endpoints.Members;

public class Create : BaseApiEndpoint
{
    public Create(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpPost("api/members")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateMemberResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerOperation(
        Summary = "Creates a new member",
        Tags = new [] {"MemberEndpoint"})]
    public async Task<IActionResult> Handle([FromBody] CreateMemberCommand command)
    {
        var result = await Mediator.Send(command);

        if (!result.Succeeded)
        {
            return BadRequest(result);
        }

        return CreatedAtAction(nameof(Handle), result);
    }
}