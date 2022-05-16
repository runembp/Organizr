using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Commands;
using Organizr.Application.Requests;
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
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Member>))]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllMembersRequest());
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateMemberResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateMember([FromBody] CreateMemberCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result.Succeeded)
        {
            return BadRequest(result);
        }

        return CreatedAtAction(nameof(CreateMember), result);
    }

    [HttpGet("{memberId}/groups")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<Member> GetGroupsByMemberId([FromRoute] int memberId)
    {
        var request = new GetAllGroupsByMemberIdRequest { MemberId = memberId };

       return await _mediator.Send(request);

       
    }
}