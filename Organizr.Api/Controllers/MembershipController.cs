using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Commands.Memberships;
using Organizr.Application.Requests.Memberships;
using Organizr.Application.Responses.Memberships;
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

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateMembershipResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateMembership([FromBody] CreateMembershipCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result.Succeeded)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpDelete("{membershipId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeleteMembershipResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteMembership([FromRoute] int membershipId)
    {
        if (membershipId <= 0)
        {
            return BadRequest("Medlemsskabs Id'et er ikke udfyldt korrekt");
        }

        var result = await _mediator.Send(new DeleteMembershipCommand {MembershipId = membershipId});

        if (!result.Succeeded)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
}