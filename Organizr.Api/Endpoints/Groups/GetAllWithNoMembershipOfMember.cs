using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Requests.Groups;
using Organizr.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace Organizr.Api.Endpoints.Groups;

public class GetAllWithNoMembershipOfMember : BaseApiEndpoint
{
    public GetAllWithNoMembershipOfMember(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpGet("api/groups/no-membership/{memberId:int}/")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MemberGroup>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerOperation(
        Summary = "Gets a list of all Membergroups where Member has no Membership",
        Tags = new [] {"Groups"})]
    public async Task<IActionResult> GetMembergroupsWhereMemberHasNoMembership([FromRoute] int memberId, [FromQuery] bool open)
    {
        if (memberId <= 0)
        {
            return BadRequest("Medlems Id er ikke udfyldt korrekt");
        }
        
        var result = await Mediator.Send(new GetMemberGroupsWithNoMembershipOfMemberRequest {MemberId = memberId, RequestOnlyOpenGroups = open});

        if (result is null)
        {
            return BadRequest("Medlemmet findes ikke");
        }

        return Ok(result);
    }
}