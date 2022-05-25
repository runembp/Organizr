using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Commands.NewsPosts;
using Organizr.Application.Responses.NewsPost;
using Swashbuckle.AspNetCore.Annotations;

namespace Organizr.Api.Endpoints.Newsposts;

public class Create : BaseApiEndpoint
{
    public Create(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpPost("api/newsposts")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateNewsPostResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerOperation(
        Summary = "Creates a new news post",
        Tags = new [] {"NewsPosts"})]
    public async Task<IActionResult> CreateNewsPost([FromBody] CreateNewsPostCommand command)
    {
        var response = await Mediator.Send(command);

        if (!response.Succeeded)
        {
            return BadRequest(response);
        }

        return CreatedAtAction(nameof(CreateNewsPost), response);
    }
}