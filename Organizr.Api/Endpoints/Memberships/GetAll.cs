using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Requests.Memberships;
using Organizr.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace Organizr.Api.Endpoints.Memberships;

public class GetAll : BaseApiEndpoint
{
    public GetAll(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpGet("api/memberships")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Membership>))]
    [SwaggerOperation(
        Summary = "Gets a list of all Memberships, or a list of all Memberships of a Member, if the memberId parameter is recieved",
        Tags = new [] {"Memberships"})]
    public async Task<IActionResult> GetAllMemberships([FromQuery] int? memberId)
    {
        if (memberId is not null)
        {
            var membershipsForSpecificMember = await Mediator.Send(new GetMembershipsForMemberRequest {MemberId = (int) memberId});

            if (membershipsForSpecificMember is null)
            {
                return BadRequest("Medlemmet findes ikke");
            }

            return Ok(membershipsForSpecificMember);
        }
        
        var allMemberships = await Mediator.Send(new GetAllMembershipsRequest());
        return Ok(allMemberships);
    }
}