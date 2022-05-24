using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Requests.Configurations;
using Organizr.Domain.Entities;
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
        Summary = "Gets a list of all configurations",
        Tags = new [] {"ConfigurationEndpoint"})]
    public async Task<IActionResult> Handle()
    {
        var result = await Mediator.Send(new GetAllConfigurationsRequest());
        return Ok(result);
    }
}