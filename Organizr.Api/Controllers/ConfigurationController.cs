using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Requests.Configurations;
using Organizr.Domain.Entities;

namespace Organizr.Api.Controllers;

[AllowAnonymous]
[ApiController]
[Route("api/")]
public class ConfigurationController : ControllerBase
{
    private readonly IMediator _mediator;

    public ConfigurationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("configuration")]

    public async Task<List<Configuration>> Get()
    {
        return await _mediator.Send(new GetAllConfigurationsRequest());
    }
}

