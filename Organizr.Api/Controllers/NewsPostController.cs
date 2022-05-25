using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Commands.NewsPosts;
using Organizr.Application.Requests.News;
using Organizr.Application.Responses.NewsPost;
using Organizr.Domain.Entities;

namespace Organizr.Api.Controllers;

[ApiController]
[Route("api/newsposts")]
public class NewsPostController : ControllerBase
{

    private readonly IMediator _mediator;

    public NewsPostController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<NewsPost>))]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllPublicNewsPostsRequest());
        return Ok(result);
    }

    [HttpGet("groups/{groupId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<NewsPost>))]
    public async Task<IActionResult> GetAllByGroupId([FromRoute] int groupId)
    {
        var result = await _mediator.Send(new GetAllNewsPostsByGroupIdRequest { GroupId = groupId });
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateNewsPostResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateNewsPost([FromBody] CreateNewsPostCommand command)
    {
        var response = await _mediator.Send(command);

        if (!response.Succeeded)
        {
            return BadRequest(response);
        }

        return CreatedAtAction(nameof(CreateNewsPost), response);

    }
}