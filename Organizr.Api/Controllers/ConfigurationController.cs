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
    public async Task<List<Configuration>> Get()
    {
        return await _mediator.Send(new GetAllConfigurationsRequest());
    }

    [HttpGet]
    [Route("type/{configType:int}")]
    public async Task<List<Configuration>> GetByType(int configType)
    {
        return await _mediator.Send(new GetAllConfigurationsOfTypeRequest {ConfigType = (ConfigType) configType});
    }

    [HttpPost]
    [Route("type/{configType:int}")]
    public async Task<List<Configuration>> UpdateByType(int configType, [FromBody] List<Configuration> updatedConfigurations)
    {
        return await _mediator.Send(new UpdateConfigurationsOfTypeCommand {ConfigType = (ConfigType)configType, UpdatedConfigurations = updatedConfigurations});
    }
}

