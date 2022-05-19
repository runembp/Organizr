using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Requests.News;
using Organizr.Domain.Entities;

namespace Organizr.Api.Controllers;

[ApiController]
[Route("api/news")]
public class NewsController : ControllerBase
{

    private readonly IMediator _mediator;

    public NewsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<News>))]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllNewsRequest());
        return Ok(result);
    }


}

