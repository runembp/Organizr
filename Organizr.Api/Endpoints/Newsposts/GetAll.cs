using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Requests.News;
using Organizr.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace Organizr.Api.Endpoints.Newsposts;

public class GetAll : BaseApiEndpoint
{
    public GetAll(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpGet("api/newsposts")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<NewsPost>))]
    [SwaggerOperation(
        Summary = "Gets a list of all news posts",
        Tags = new [] {"NewsPostEndpoint"})]
    public async Task<IActionResult> Handle()
    {
        var result = await Mediator.Send(new GetAllPublicNewsPostsRequest());
        return Ok(result);
    }
}