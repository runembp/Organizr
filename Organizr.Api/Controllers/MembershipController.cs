using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Requests.Memberships;
using Organizr.Domain.Entities;

namespace Organizr.Api.Controllers;

[ApiController]
[Route("api/memberships")]
public class MembershipController : ControllerBase
{
    private readonly IMediator _mediator;

    public MembershipController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Membership>))]
    public async Task<IActionResult> GetAllMemberships()
    {
        var result = await _mediator.Send(new GetAllMembershipsRequest());
        return Ok(result);
    }

    [HttpGet("members/{memberId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Membership>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetMembershipsForMember([FromRoute] int memberId)
    {
        var result = await _mediator.Send(new GetMembershipsForMemberRequest {MemberId = memberId});

        if (result is null)
        {
            return BadRequest("Medlemmet findes ikke");
        }

        return Ok(result);
    }
}