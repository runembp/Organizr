using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Requests.Groups;
using Organizr.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace Organizr.Api.Endpoints.Groups;

public class Get : BaseApiEndpoint
{
    public Get(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpGet("api/groups/{groupId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MemberGroup))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerOperation(
        Summary = "Gets a group based on a groupId. Memberships included, if includeMemberships boolean is recieved",
        Tags = new [] {"Groups"})]
    public async Task<IActionResult> Handle([FromRoute] int groupId, [FromQuery] bool? includeMemberships) 
    {
        if (groupId <= 0)
        {
            return BadRequest("Gruppe Id er ikke udfyldt korrekt");
        }

        if (includeMemberships is not null && includeMemberships == true)
        {
            var memberGroupWithMemberships = await Mediator.Send(new GetMemberGroupWithMembershipsByIdRequest { GroupId = groupId });

            if (memberGroupWithMemberships is null)
            {
                return BadRequest("Gruppen findes ikke");
            }

            return Ok(memberGroupWithMemberships);            
        }

        var result = await Mediator.Send(new GetMemberGroupByIdRequest {GroupId = groupId});

        return Ok(result);
    }
}