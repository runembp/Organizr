using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Requests.Memberships;

namespace Organizr.Api.Controllers;

public class MembershipController : ControllerBase
{
    private readonly IMediator _mediator;

    public MembershipController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllMemberships()
    {
        var result = await _mediator.Send(new GetAllMembershipsRequest());
        return Ok(result);
    }
}