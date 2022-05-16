using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Commands;
using Organizr.Application.Requests.Groups;
using Organizr.Application.Requests.Members;
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

    [HttpGet("{memberId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Member))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetMemberWithGroupsById([FromRoute] int memberId)
    {
        if (memberId <= 0)
        {
            return BadRequest("Medlems id er ikke i et korrekt format");
        }

        var result = await _mediator.Send(new GetMemberWithGroupsByIdRequest {MemberId = memberId});

        if (result is null)
        {
            return BadRequest("Medlemmet findes ikke");
        }

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
}