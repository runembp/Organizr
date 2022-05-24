using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Commands.Members;
using Organizr.Application.Responses.Member;
using Swashbuckle.AspNetCore.Annotations;

namespace Organizr.Api.Endpoints.Members;

public class Update : BaseApiEndpoint
{
    public Update(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpPatch("api/members/{memberId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UpdateMemberResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerOperation(
        Summary = "Updates a member",
        Tags = new [] {"MemberEndpoint"})]
    public async Task<IActionResult> Handle([FromRoute] int memberId, [FromBody] UpdateMemberCommand command)
    {
        if (memberId <= 0)
        {
            return BadRequest("Medlems id er ikke i et korrekt format");
        }

        var result = await Mediator.Send(command);

        if (!result.Succeeded)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
}