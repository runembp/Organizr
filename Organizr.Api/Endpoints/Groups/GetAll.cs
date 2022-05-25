using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Requests.Groups;
using Organizr.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace Organizr.Api.Endpoints.Groups;

public class GetAll : BaseApiEndpoint
{
    public GetAll(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpGet("api/groups")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MemberGroup>))]
    [SwaggerOperation(
        Summary = "Gets a list of all Groups",
        Tags = new [] {"Groups"})]
    public async Task<IActionResult> Handle()
    {
        var result = await Mediator.Send(new GetAllMemberGroupsRequest());
        return Ok(result);
    }
}