using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Requests.Groups;
using Organizr.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace Organizr.Api.Endpoints.Groups;

public class GetAll : BaseApiEndpoint
{
    public GetAll(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpGet("api/groups")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MemberGroup>))]
    [SwaggerOperation(
        Summary = "Gets a list of all Groups",
        Tags = new [] {"Groups"})]
    public async Task<IActionResult> Handle([FromQuery] int? memberId, [FromQuery] bool? includeOnlyOpenGroups)
    {
        if (memberId <= 0)
        {
            return BadRequest("Medlems Id er ikke udfyldt korrekt");
        }

        if (memberId is not null && includeOnlyOpenGroups is not null)
        {
            var openMemberGroupsWhereSpecifiedMemberHasNoMembership = await Mediator.Send(new GetMemberGroupsWithNoMembershipOfMemberRequest {MemberId = (int) memberId, RequestOnlyOpenGroups = (bool) includeOnlyOpenGroups});

            if (openMemberGroupsWhereSpecifiedMemberHasNoMembership is null)
            {
                return BadRequest("Medlemmet findes ikke");
            }
            
            return Ok(openMemberGroupsWhereSpecifiedMemberHasNoMembership);
        }
        
        var result = await Mediator.Send(new GetAllMemberGroupsRequest());
        return Ok(result);
    }
}