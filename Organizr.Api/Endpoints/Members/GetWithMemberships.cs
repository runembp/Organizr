using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Requests.Members;
using Organizr.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace Organizr.Api.Endpoints.Members;

public class GetWithMemberships : BaseApiEndpoint
{
    public GetWithMemberships(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpGet("api/members/{memberId:int}/memberships")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Member))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerOperation(
        Summary = "Gets member with memberships by id",
        Tags = new [] {"Members"})]
    public async Task<IActionResult> Handle([FromRoute] int memberId, [FromQuery] bool? includeMemberships)
    {
        if (memberId <= 0)
        {
            return BadRequest("Medlems id er ikke i et korrekt format");
        }

        if (includeMemberships is not null && includeMemberships == true)
        {
            var memberWithMembershipsAndGroupsIncluded = await Mediator.Send(new GetMemberMembershipGroupsByIdRequest { MemberId = memberId });

            if (memberWithMembershipsAndGroupsIncluded is null)
            {
                return BadRequest("Medlemmet findes ikke");
            }

            return Ok(memberWithMembershipsAndGroupsIncluded);
        }

        var result = await Mediator.Send(new GetMemberWithMembershipsByIdRequest {MemberId = memberId});

        if (result is null)
        {
            return BadRequest("Medlemmet findes ikke");
        }

        return Ok(result);
    }
}