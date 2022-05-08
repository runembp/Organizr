using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Commands;
using Organizr.Application.Requests.Groups;
using Organizr.Application.Responses;
using Organizr.Domain.Entities;


namespace Organizr.Api.Controllers;

[AllowAnonymous]
[ApiController]
[Route("api/")]
public class MemberController : ControllerBase
{
    private readonly IMediator _mediator;

    public MemberController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("organizr-member")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<List<Member>> Get()
    {
        return await _mediator.Send(new GetAllMembersRequest());
    }

    [HttpPost("organizr-member")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CreateMemberResponse>> CreateMember([FromBody] CreateMemberCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result.Succeeded) return BadRequest(result);

        return Ok(result);
    }
}