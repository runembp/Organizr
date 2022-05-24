using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Commands.Groups;
using Organizr.Application.Responses.Groups;
using Swashbuckle.AspNetCore.Annotations;

namespace Organizr.Api.Endpoints.Groups;

public class Delete : BaseApiEndpoint
{
    public Delete(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpDelete("api/groups")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeleteMemberGroupResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerOperation(
        Summary = "Deletes a Group",
        Tags = new [] {"Groups"})]
    public async Task<IActionResult> DeleteGroupById([FromBody] int groupId)
    {
        var response = new DeleteMemberGroupResponse();

        if (groupId <= 0)
        {
            response.Error = "Gruppe Id er ikke udfyldt korrekt";
            return BadRequest(response);
        }

        response = await Mediator.Send(new DeleteMemberGroupCommand { Id = groupId });

        if (!response.Succeeded)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
}