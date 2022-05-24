using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Commands.Memberships;
using Organizr.Application.Responses.Memberships;
using Swashbuckle.AspNetCore.Annotations;

namespace Organizr.Api.Endpoints.Memberships;

public class Update : BaseApiEndpoint
{
    public Update(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpPatch("api/memberships/{membershipId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateMembershipRoleResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerOperation(
        Summary = "Updates a Role in a membership",
        Tags = new [] {"Memberships"})]
    public async Task<IActionResult> Handle([FromRoute] int membershipId, [FromBody] UpdateMembershipRoleCommand command)
    {
        if (membershipId <= 0)
        {
            return BadRequest("Medlemsskabs Id'et er ikke udfyldt korrekt");
        }

        command.MembershipId = membershipId;
        var result = await Mediator.Send(command);

        if (!result.Succeeded)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
}