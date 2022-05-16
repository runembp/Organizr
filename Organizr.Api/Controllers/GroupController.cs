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
    public async Task<List<MemberGroup>> GetAll()
    {
        return await _mediator.Send(new GetAllMemberGroupsRequest());
    }

    [HttpGet]
    [Route("{groupId:int}/members")]
    public async Task<MemberGroup?> GetGroupByIdWithMembers(int groupId)
    {
        return await _mediator.Send(new GetMemberGroupWithMembersByIdRequest {GroupId = groupId});
    }

    [HttpPatch("{groupId}")]
    public async Task<MemberGroup> UpdateGroupById([FromRoute] int groupId, [FromBody] UpdateMemberGroupCommand command)
    {

        return await _mediator.Send(new UpdateMemberGroupCommand { Id = groupId, IsOpen = command.IsOpen, Name = command.Name});
    }
    

    [HttpPatch("{groupId}/members/{memberId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddMemberToMemberGroupResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> AddMemberToGroup([FromRoute] int groupId, int memberId)
    {
        var request = new AddMemberToMemberGroupCommand
        {
            GroupId = groupId,
            MemberId = memberId
        };

        var result = await _mediator.Send(request);

        if (!result.Succeeded) return BadRequest("no");
       
        return Ok(result);
    }

    [HttpPost]
    public async Task CreateNewGroup([FromBody] CreateMemberGroupCommand command)
    {
        await _mediator.Send(command);
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteGroupById([FromBody] int id)
    {
        var result = await _mediator.Send(new DeleteMemberGroupCommand{Id = id});
        return Ok(result);
    }

    [HttpDelete]
    [Route("/api/groups/{groupId}/")]
    public async Task<IActionResult> RemoveMemberFromGroup([FromRoute] int groupId, [FromBody] int memberId)
    {
        var result = await _mediator.Send(new RemoveMemberFromGroupCommand {GroupId = groupId, MemberId = memberId});
        return Ok(result);
    }
}