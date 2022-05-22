using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Commands.Roles;
using Organizr.Application.Requests.Roles;
using Organizr.Application.Responses;

namespace Organizr.Api.Controllers;

[ApiController]
[Route("api/roles")]
public class RoleController : ControllerBase
{
    private readonly IMediator _mediator;

    public RoleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{memberId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetMemberRole([FromRoute] int memberId)
    {
        var result = await _mediator.Send(new GetMemberRoleRequest{MemberId = memberId});

        if (result is null)
        {
            return BadRequest("Medlemmet findes ikke");
        }

        return Ok(result);
    }

    [HttpPatch("{memberId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ChangeMemberRoleResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateMemberRole([FromRoute] int memberId, [FromBody] bool isOrganizationAdministrator)
    {
        var result = await _mediator.Send(new ChangeMemberRoleCommand {MemberId = memberId, IsOrganizationAdministrator = isOrganizationAdministrator});

        if (!result.Succeeded)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

}