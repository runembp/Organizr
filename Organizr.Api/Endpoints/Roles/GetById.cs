using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Requests.Roles;
using Swashbuckle.AspNetCore.Annotations;

namespace Organizr.Api.Endpoints.Roles;

public class GetById : BaseApiEndpoint
{
    public GetById(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpGet("api/roles/{memberId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerOperation(
        Summary = "Gets a bool based on if the Member is Organization administrator or not",
        Tags = new [] {"Roles"})]
    public async Task<IActionResult> Handle([FromRoute] int memberId)
    {
        var result = await Mediator.Send(new GetMemberRoleRequest{MemberId = memberId});

        if (result is null)
        {
            return BadRequest("Medlemmet findes ikke");
        }

        return Ok(result);
    }
}