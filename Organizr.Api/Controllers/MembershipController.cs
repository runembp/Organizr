using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Requests.Memberships;
using Organizr.Domain.Entities;

namespace Organizr.Api.Controllers;

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
}