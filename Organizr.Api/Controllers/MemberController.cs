using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Commands;
using Organizr.Application.Requests.Groups;
using Organizr.Application.Responses.Member;
using Organizr.Domain.Entities;


namespace Organizr.Api.Controllers;

[AllowAnonymous]
[ApiController]
[Route("api/members")]
public class MemberController : ControllerBase
{
    private readonly IMediator _mediator;

    public MemberController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<Member>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllMembersRequest());
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateMemberResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Member?>> CreateMember([FromBody] CreateMemberCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result.Succeeded)
        {
            return BadRequest(result);
        }

        return CreatedAtAction(nameof(CreateMember), result);
    }
}