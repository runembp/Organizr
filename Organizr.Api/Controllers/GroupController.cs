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
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<MemberGroup>>> GetAllGroups()
    {
        var result = await _mediator.Send(new GetAllMemberGroupsRequest());
        return Ok(result);
    }

    [HttpGet]
    [Route("{groupId:int}/members")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MemberGroup>> GetGroupByIdWithMembers(int groupId)
    {
        if (groupId <= 0)
        {
            return BadRequest("Gruppe Id er ikke udfyldt korrekt");
        }
        
        var result = await _mediator.Send(new GetMemberGroupWithMembersByIdRequest {GroupId = groupId});

        if (result is null)
        {
            return BadRequest("Gruppen findes ikke");
        }
        
        return Ok(result);
    }

    [HttpPatch]
    [Route("{groupId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<UpdateMemberGroupResponse>> UpdateGroupById(int groupId, [FromBody] UpdateMemberGroupCommand command)
    {
        var response = new UpdateMemberGroupResponse();
        
        if (groupId <= 0)
        {
            response.Error = "Gruppe Id er ikke udfyldt korrekt";
            return BadRequest(response);
        }
        
        response = await _mediator.Send(command);

        if (!response.Succeeded)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
    
    [HttpPatch]
    [Route("{groupId:int}/members")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AddMemberToMemberGroupResponse>> AddMemberToGroup(int groupId, [FromBody] int memberId)
    {
        var response = new AddMemberToMemberGroupResponse();
        
        if (groupId <= 0)
        {
            response.Error = "Gruppe Id er ikke udfyldt korrekt";
            return BadRequest(response);
        }
        
        response = await _mediator.Send(new AddMemberToMemberGroupCommand {GroupId = groupId, MemberId = memberId});

        if (!response.Succeeded)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CreateMemberGroupResponse>> CreateNewGroup([FromBody] CreateMemberGroupCommand command)
    {
        var response = await _mediator.Send(command);

        if (!response.Succeeded)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
    
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DeleteMemberGroupResponse>> DeleteGroupById([FromBody] int groupId)
    {
        var response = new DeleteMemberGroupResponse();
        
        if (groupId <= 0)
        {
            response.Error = "Gruppe Id er ikke udfyldt korrekt";
            return BadRequest(response);
        }
        
        response = await _mediator.Send(new DeleteMemberGroupCommand{Id = groupId});

        if (!response.Succeeded)
        {
            return BadRequest(response);
        }
        
        return Ok(response);
    }

    [HttpDelete]
    [Route("/api/groups/{groupId:int}/")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> RemoveMemberFromGroup(int groupId, [FromBody] int memberId)
    {
        var response = new RemoveMemberFromMemberGroupResponse();
        
        if (groupId <= 0)
        {
            response.Error = "Gruppe Id er ikke udfyldt korrekt";
            return BadRequest(response);
        }
        
        response = await _mediator.Send(new RemoveMemberFromGroupCommand {GroupId = groupId, MemberId = memberId});

        if (!response.Succeeded)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
}