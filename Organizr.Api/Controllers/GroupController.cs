using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Commands.Groups;
using Organizr.Application.Requests.Groups;
using Organizr.Application.Responses.Groups;
using Organizr.Domain.Entities;

namespace Organizr.Api.Controllers;

[ApiController]
[Route("api/groups")]
public class GroupController : ControllerBase
{
    private readonly IMediator _mediator;

    public GroupController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MemberGroup>))]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllMemberGroupsRequest());
        return Ok(result);
    }

    [HttpGet("{groupId:int}/members")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MemberGroup))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetGroupByIdWithMembers([FromRoute] int groupId)
    {
        if (groupId <= 0)
        {
            return BadRequest("Gruppe Id er ikke udfyldt korrekt");
        }

        var result = await _mediator.Send(new GetMemberGroupWithMembersByIdRequest { GroupId = groupId });

        if (result is null)
        {
            return BadRequest("Gruppen findes ikke");
        }

        return Ok(result);
    }

    [HttpGet("no-membership/{memberId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MemberGroup>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetMembergroupsWhereMemberHasNoMembership([FromRoute] int memberId)
    {
        if (memberId <= 0)
        {
            return BadRequest("Medlems Id er ikke udfyldt korrekt");
        }
        
        var result = await _mediator.Send(new GetAllMemberGroupsWithNoMembershipOfMemberRequest {MemberId = memberId});

        if (result is null)
        {
            return BadRequest("Medlemmet findes ikke");
        }

        return Ok(result);
    }

    [HttpPatch("{groupId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateMemberGroupResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateGroupById([FromRoute] int groupId, [FromBody] UpdateMemberGroupCommand command)
    {
        var response = new UpdateMemberGroupResponse();

        if (groupId <= 0)
        {
            response.Error = "Gruppe Id er ikke udfyldt korrekt";
            return BadRequest(response);
        }

        command.Id = groupId;

        response = await _mediator.Send(command);

        if (!response.Succeeded)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }


    [HttpPatch("{groupId}/members/{memberId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddMemberToMemberGroupResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddMemberToGroup([FromRoute] int groupId, int memberId)
    {
        var response = new AddMemberToMemberGroupResponse();

        if (groupId <= 0)
        {
            response.Error = "Gruppe Id er ikke udfyldt korrekt";
            return BadRequest(response);
        }
        else if (memberId <= 0)
        {
            response.Error = "Member Id er ikke udfyldt korrekt";
            return BadRequest(response);
        }

        response = await _mediator.Send(new AddMemberToMemberGroupCommand
        {
            GroupId = groupId,
            MemberId = memberId
        });

        if (!response.Succeeded) return BadRequest(response);

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateMemberGroupResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateNewGroup([FromBody] CreateMemberGroupCommand command)
    {
        var response = await _mediator.Send(command);

        if (!response.Succeeded)
        {
            return BadRequest(response);
        }

        return CreatedAtAction(nameof(CreateNewGroup), response);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeleteMemberGroupResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteGroupById([FromBody] int groupId)
    {
        var response = new DeleteMemberGroupResponse();

        if (groupId <= 0)
        {
            response.Error = "Gruppe Id er ikke udfyldt korrekt";
            return BadRequest(response);
        }

        response = await _mediator.Send(new DeleteMemberGroupCommand { Id = groupId });

        if (!response.Succeeded)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    [HttpDelete("{groupId:int}/members/{memberId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RemoveMemberFromGroupResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RemoveMemberFromGroup([FromRoute] int groupId, int memberId)
    {
        var response = new RemoveMemberFromGroupResponse();

        if (groupId <= 0)
        {
            response.Error = "Gruppe Id er ikke udfyldt korrekt";
            return BadRequest(response);
        }

        response = await _mediator.Send(new RemoveMemberFromGroupCommand { GroupId = groupId, MemberId = memberId });

        if (!response.Succeeded)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

}