using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Commands.Groups;
using Organizr.Application.Requests.Groups;
using Organizr.Application.Responses.Groups;
using Organizr.Domain.Entities;

namespace Organizr.Api.Controllers;

[AllowAnonymous]
[ApiController]
[Route("api/")]
public class UserGroupController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserGroupController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("groups")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<List<MemberGroup>> GetAll()
    {
        return await _mediator.Send(new GetAllMemberGroupsRequest());
    }

    [HttpPost("group")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CreateMemberGroupResponse>> CreateMemberGroup([FromBody] CreateMemberGroupCommand command)
    {
        var result = await _mediator.Send(command);

        if (!result.Succeeded) return BadRequest(result);

        return Ok(result);
    }

    [HttpPatch("group/{groupId}/member/{memberId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AddMemberToMemberGroupResponse>> AddMemberToGroup([FromRoute] int groupId, int memberId)
    {
        var request = new AddMemberToMemberGroupCommand
        {
            GroupId = groupId,
            MemberId = memberId
        };
        
        var result = await _mediator.Send(request);

        if (!result.Succeeded) return BadRequest(result);

        return Ok(result.Succeeded);

    }

}