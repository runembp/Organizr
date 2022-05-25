using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Requests.Groups;
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
        Summary = "Gets a list of all members",
        Tags = new [] {"Members"})]
    public async Task<ActionResult<List<Member>>> Handle(CancellationToken cancellationToken = default)
    {
        var result = await Mediator.Send(new GetAllMembersRequest(), cancellationToken);
        return Ok(result);
    }
    
}