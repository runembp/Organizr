using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Commands.Groups;
using Organizr.Application.Responses.Groups;
using Swashbuckle.AspNetCore.Annotations;

namespace Organizr.Api.Endpoints.Groups;

public class Update : BaseApiEndpoint
{
    public Update(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpPatch("api/groups/{groupId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateMemberGroupResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerOperation(
        Summary = "Updates a Group",
        Tags = new [] {"Groups"})]
    public async Task<IActionResult> Handle([FromRoute] int groupId, [FromBody] UpdateMemberGroupCommand command)
    {
        var response = new UpdateMemberGroupResponse();

        if (groupId <= 0)
        {
            response.Error = "Gruppe Id er ikke udfyldt korrekt";
            return BadRequest(response);
        }

        command.Id = groupId;

        response = await Mediator.Send(command);

        if (!response.Succeeded)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
}