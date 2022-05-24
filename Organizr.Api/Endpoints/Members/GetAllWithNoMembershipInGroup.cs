using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Requests.Members;
using Organizr.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace Organizr.Api.Endpoints.Members;

public class GetAllWithNoMembershipInGroup : BaseApiEndpoint
{
    public GetAllWithNoMembershipInGroup(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpGet("api/members/no-membership/{groupId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Member>))]
    [SwaggerOperation(
        Summary = "Gets a list of all members, who does not have a membership in the specified group",
        Tags = new [] {"MemberEndpoint"})]
    public async Task<IActionResult> Handle([FromRoute] int groupId)
    {
        var result = await Mediator.Send(new GetAllMembersWithNoMembershipInGroupRequest {GroupId = groupId});
        return Ok(result);
    }
    
}