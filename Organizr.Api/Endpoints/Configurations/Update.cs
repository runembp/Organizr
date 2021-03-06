using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Commands.Configurations;
using Organizr.Domain.Entities;
using Organizr.Domain.Enums;
using Swashbuckle.AspNetCore.Annotations;

namespace Organizr.Api.Endpoints.Configurations;

public class Update : BaseApiEndpoint
{
    public Update(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpPost("api/configurations")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Configuration>))]
    [SwaggerOperation(
        Summary = "Updates a list of configurations, based on type",
        Tags = new [] {"Configurations"})]
    public async Task<IActionResult> Handle([FromQuery] int configType, [FromBody] List<Configuration> updatedConfigurations)
    {
        var result = await Mediator.Send(new UpdateConfigurationsOfTypeCommand {ConfigType = (ConfigType) configType, UpdatedConfigurations = updatedConfigurations});
        return Ok(result);
    }
}