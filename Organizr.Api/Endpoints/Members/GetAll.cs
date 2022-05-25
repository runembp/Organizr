using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Requests.Groups;
using Organizr.Application.Requests.Members;
using Organizr.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace Organizr.Api.Endpoints.Members;

public class GetAll : BaseApiEndpoint
{
    public GetAll(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet("api/members")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Member>))]
    [SwaggerOperation(
        Summary = "Gets a list of all members, or all Members with no membership in Group, based on GroupId",
        Tags = new[] {"Members"})]
    public async Task<IActionResult> Handle([FromQuery] bool? hasMembership, [FromQuery] int? groupId)
    {
        if (hasMembership is not null && hasMembership == false && groupId is not null)
        {
            if (groupId <= 0)
            {
                return BadRequest("Medlems id'et er ikke i et korrekt format");
            }

            var membersWithNoMembershipInGroup = await Mediator.Send(new GetAllMembersWithNoMembershipInGroupRequest {GroupId = (int) groupId});

            if (membersWithNoMembershipInGroup is null)
            {
                return BadRequest("Gruppen findes ikke");
            }

            return Ok(membersWithNoMembershipInGroup);
        }

        var allMembers = await Mediator.Send(new GetAllMembersRequest());
        return Ok(allMembers);
    }
}