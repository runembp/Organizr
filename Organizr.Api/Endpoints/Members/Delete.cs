using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Commands.Members;
using Organizr.Application.Responses.Member;
using Swashbuckle.AspNetCore.Annotations;

namespace Organizr.Api.Endpoints.Members;

public class Delete : BaseApiEndpoint
{
    public Delete(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpDelete("api/members/{memberId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeleteMemberResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerOperation(
        Summary = "Deletes a Member",
        Tags = new [] {"Members"})]
    public async Task<IActionResult> DeleteMemberById([FromRoute] int memberId)
    {
        if (memberId <= 0)
        {
            return BadRequest("Medlems id er ikke i et korrekt format");
        }

        var result = await Mediator.Send(new DeleteMemberCommand {MemberId = memberId});

        if (!result.Succeeded)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
}