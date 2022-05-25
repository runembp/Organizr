using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Requests.Memberships;
using Organizr.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace Organizr.Api.Endpoints.Memberships;

public class GetAllByMemberId : BaseApiEndpoint
{
    public GetAllByMemberId(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpGet("api/memberships/members/{memberId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Membership>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerOperation(
        Summary = "Gets a list of all Memberships for a specific Member",
        Tags = new [] {"Memberships"})]
    public async Task<IActionResult> GetMembershipsForMember([FromRoute] int memberId)
    {
        var result = await Mediator.Send(new GetMembershipsForMemberRequest {MemberId = memberId});

        if (result is null)
        {
            return BadRequest("Medlemmet findes ikke");
        }

        return Ok(result);
    }
}