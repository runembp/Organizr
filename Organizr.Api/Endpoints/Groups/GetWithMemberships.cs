using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Requests.Groups;
using Organizr.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace Organizr.Api.Endpoints.Groups;

public class GetWithMemberships : BaseApiEndpoint
{
    public GetWithMemberships(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpGet("api/groups/{groupId:int}/memberships")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MemberGroup))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerOperation(
        Summary = "Gets a group with Memberships by id",
        Tags = new [] {"Groups"})]
    public async Task<IActionResult> GetGroupByIdWithMemberships([FromRoute] int groupId)
    {
        if (groupId <= 0)
        {
            return BadRequest("Gruppe Id er ikke udfyldt korrekt");
        }

        var result = await Mediator.Send(new GetMemberGroupWithMembershipsByIdRequest { GroupId = groupId });

        if (result is null)
        {
            return BadRequest("Gruppen findes ikke");
        }

        return Ok(result);
    }
}