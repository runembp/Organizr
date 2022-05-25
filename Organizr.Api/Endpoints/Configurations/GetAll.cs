using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Requests.Configurations;
using Organizr.Domain.Entities;
using Organizr.Domain.Enums;
using Swashbuckle.AspNetCore.Annotations;

namespace Organizr.Api.Endpoints.Configurations;

public class GetAll : BaseApiEndpoint
{
    public GetAll(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpGet("api/configurations")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Configuration>))]
    [SwaggerOperation(
        Summary = "Gets a list of all configurations, or all configurations of specific type if configType id is recieved",
        Tags = new [] {"Configurations"})]
    public async Task<IActionResult> Handle([FromQuery] int? configType)
    {
        if (configType is null)
        {
            var allConfigurations = await Mediator.Send(new GetAllConfigurationsRequest());
            return Ok(allConfigurations);    
        }
        
        var configurationsByType = await Mediator.Send(new GetAllConfigurationsOfTypeRequest {ConfigType = (ConfigType) configType});
        return Ok(configurationsByType);
    }
}