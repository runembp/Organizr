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
    public async Task<List<MemberGroup>> GetAllGroups()
    {
        return await _mediator.Send(new GetAllMemberGroupsRequest());
    }

    [HttpGet]
    [Route("{groupId:int}/members")]
    public async Task<MemberGroup?> GetGroupByIdWithMembers(int groupId)
    {
        return await _mediator.Send(new GetMemberGroupWithMembersByIdRequest {GroupId = groupId});
    }

    [HttpPatch]
    [Route("{groupId:int}")]
    public async Task<MemberGroup> UpdateGroupById(int groupId, [FromBody] UpdateMemberGroupCommand command)
    {
        return await _mediator.Send(command);
    }
    
    [HttpPatch]
    [Route("{groupId:int}/members")]
    public async Task<MemberGroup> AddMemberToGroup(int groupId, [FromBody] int memberId)
    {
        return await _mediator.Send(new AddMemberToMemberGroupCommand {GroupId = groupId, MemberId = memberId});
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
    [Route("/api/groups/{groupId:int}/")]
    public async Task<IActionResult> RemoveMemberFromGroup(int groupId, [FromBody] int memberId)
    {
        var result = await _mediator.Send(new RemoveMemberFromGroupCommand {GroupId = groupId, MemberId = memberId});
        return Ok(result);
    }
}