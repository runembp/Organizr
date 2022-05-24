using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Requests.Memberships;
using Organizr.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace Organizr.Api.Endpoints.Memberships;

public class GetAll : BaseApiEndpoint
{
    public GetAll(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpGet("api/memberships")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Membership>))]
    [SwaggerOperation(
        Summary = "Gets a list of all Memberships",
        Tags = new [] {"Memberships"})]
    public async Task<IActionResult> GetAllMemberships()
    {
        var result = await Mediator.Send(new GetAllMembershipsRequest());
        return Ok(result);
    }
}