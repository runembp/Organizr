using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Commands;
using Organizr.Application.Queries;
using Organizr.Application.Responses;
using Organizr.Core.Entities;


namespace Organizr.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OrganizrUserController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrganizrUserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("/organizr-user")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<List<OrganizrUser>> Get()
    {
        return await _mediator.Send(new GetAllOrganizrUserQuery());
    }
    [HttpPost("/organizr-user")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<OrganizrUserResponse>> CreateOrganizrUser([FromBody] CreateOrganizrUserCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}