using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Commands.Configurations;
using Organizr.Application.Requests.Configurations;
using Organizr.Domain.Entities;
using Organizr.Domain.Enums;

namespace Organizr.Api.Controllers;

[AllowAnonymous]
[ApiController]
[Route("api/configurations/")]
public class ConfigurationController : ControllerBase
{
    private readonly IMediator _mediator;

    public ConfigurationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<Configuration>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllConfigurationsRequest());
        return Ok(result);
    }

    [HttpGet("type/{configType:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<Configuration>>> GetByType([FromRoute] int configType)
    {
        var result = await _mediator.Send(new GetAllConfigurationsOfTypeRequest {ConfigType = (ConfigType) configType});
        return Ok(result);
    }

    [HttpPost("type/{configType:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<Configuration>>> UpdateByType([FromRoute] int configType, [FromBody] List<Configuration> updatedConfigurations)
    {
        var result = await _mediator.Send(new UpdateConfigurationsOfTypeCommand {ConfigType = (ConfigType) configType, UpdatedConfigurations = updatedConfigurations});
        return Ok(result);
    }
}

