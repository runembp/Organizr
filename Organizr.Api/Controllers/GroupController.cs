using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Commands.Groups;
using Organizr.Application.Requests.Groups;
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
        return result;
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
    public async Task<ActionResult<MemberGroup>> UpdateGroupById(int groupId, [FromBody] UpdateMemberGroupCommand command)
    {
        if (groupId <= 0)
        {
            return BadRequest("Gruppe Id er ikke udfyldt korrekt");
        }
        
        var result = await _mediator.Send(command);

        if (result is null)
        {
            return BadRequest("Gruppen findes ikke");
        }

        return Ok(result);
    }
    
    [HttpPatch]
    [Route("{groupId:int}/members")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MemberGroup>> AddMemberToGroup(int groupId, [FromBody] int memberId)
    {
        if (groupId <= 0)
        {
            return BadRequest("Gruppe Id er ikke udfyldt korrekt");
        }
        
        var result = await _mediator.Send(new AddMemberToMemberGroupCommand {GroupId = groupId, MemberId = memberId});

        if (result is null)
        {
            return BadRequest("Gruppen findes ikke");
        }

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MemberGroup>> CreateNewGroup([FromBody] CreateMemberGroupCommand command)
    {
        var result = await _mediator.Send(command);

        if (result is null)
        {
            return BadRequest("Gruppen kunne ikke oprettes");
        }

        return Ok(result);
    }
    
    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> DeleteGroupById([FromBody] int groupId)
    {
        if (groupId <= 0)
        {
            return BadRequest("Gruppe Id er ikke udfyldt korrekt");
        }
        
        var result = await _mediator.Send(new DeleteMemberGroupCommand{Id = groupId});

        if (result is null)
        {
            return BadRequest("Gruppen kunne ikke findes");
        }
        
        return NoContent();
    }

    [HttpDelete]
    [Route("/api/groups/{groupId:int}/")]
    public async Task<ActionResult<MemberGroup>> RemoveMemberFromGroup(int groupId, [FromBody] int memberId)
    {
        if (groupId <= 0)
        {
            return BadRequest("Gruppe Id er ikke udfyldt korrekt");
        }
        
        var result = await _mediator.Send(new RemoveMemberFromGroupCommand {GroupId = groupId, MemberId = memberId});

        if (result is null)
        {
            return BadRequest("Medlemmet kunne ikke findes");
        }

        return result;
    }
}