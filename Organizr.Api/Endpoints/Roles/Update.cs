using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Commands.Roles;
using Organizr.Application.Responses.Roles;
using Swashbuckle.AspNetCore.Annotations;

namespace Organizr.Api.Endpoints.Roles;

public class Update : BaseApiEndpoint
{
    public Update(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpPatch("api/roles/{memberId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ChangeMemberRoleResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerOperation(
        Summary = "Updates a role on the specified member",
        Tags = new [] {"Roles"})]
    public async Task<IActionResult> Handle([FromRoute] int memberId, [FromBody] bool isOrganizationAdministrator)
    {
        var result = await Mediator.Send(new ChangeMemberRoleCommand {MemberId = memberId, IsOrganizationAdministrator = isOrganizationAdministrator});

        if (!result.Succeeded)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
}