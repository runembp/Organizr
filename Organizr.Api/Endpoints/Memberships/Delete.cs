using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Commands.Memberships;
using Organizr.Application.Responses.Memberships;
using Swashbuckle.AspNetCore.Annotations;

namespace Organizr.Api.Endpoints.Memberships;

public class Delete : BaseApiEndpoint
{
    public Delete(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpDelete("api/memberships/{membershipId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeleteMembershipResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerOperation(
        Summary = "Deletes a membership by id",
        Tags = new [] {"Memberships"})]
    public async Task<IActionResult> DeleteMembership([FromRoute] int membershipId)
    {
        if (membershipId <= 0)
        {
            return BadRequest("Medlemsskabs Id'et er ikke udfyldt korrekt");
        }

        var result = await Mediator.Send(new DeleteMembershipCommand {MembershipId = membershipId});

        if (!result.Succeeded)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
}