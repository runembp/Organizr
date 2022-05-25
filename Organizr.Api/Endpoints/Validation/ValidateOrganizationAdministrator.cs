using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Requests.Roles;
using Swashbuckle.AspNetCore.Annotations;

namespace Organizr.Api.Endpoints.Validation;

public class GetById : BaseApiEndpoint
{
    public GetById(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpGet("api/validation")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerOperation(
        Summary = "Gets a bool based on if the Member is Organization administrator or not",
        Tags = new [] {"Validations"})]
    public async Task<IActionResult> Handle([FromQuery] int isOrganizationAdministrator)
    {
        var result = await Mediator.Send(new GetMemberRoleRequest{MemberId = isOrganizationAdministrator});

        if (result is null)
        {
            return BadRequest("Medlemmet findes ikke");
        }

        return Ok(result);
    }
}