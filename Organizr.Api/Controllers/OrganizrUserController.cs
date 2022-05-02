using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Commands;
using Organizr.Application.Requests;
using Organizr.Application.Responses;
using Organizr.Core.Entities;


namespace Organizr.Api.Controllers;

[AllowAnonymous]
[ApiController]
[Route("api/")]
public class OrganizrUserController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrganizrUserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("organizr-user")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<List<OrganizrUser>> Get()
    {
        return await _mediator.Send(new GetAllOrganizrUserRequest());
    }

    [HttpPost("organizr-user")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<OrganizrUserResponse>> CreateOrganizrUser([FromBody] CreateOrganizrUserCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}