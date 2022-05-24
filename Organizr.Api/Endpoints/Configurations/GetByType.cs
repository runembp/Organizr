using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Requests.Configurations;
using Organizr.Domain.Entities;
using Organizr.Domain.Enums;
using Swashbuckle.AspNetCore.Annotations;

namespace Organizr.Api.Endpoints.Configurations;

public class GetByType : BaseApiEndpoint
{
    public GetByType(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpGet("api/configurations/type/{configType:int}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Configuration>))]
    [SwaggerOperation(
        Summary = "Gets a list of Configurations based on type",
        Tags = new [] {"Configurations"})]
    public async Task<IActionResult> Handle([FromRoute] int configType)
    {
        var result = await Mediator.Send(new GetAllConfigurationsOfTypeRequest {ConfigType = (ConfigType) configType});
        return Ok(result);
    }
}