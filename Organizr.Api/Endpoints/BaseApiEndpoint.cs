using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Organizr.Api.Endpoints;

public class BaseApiEndpoint : ControllerBase
{
    protected IMediator Mediator { get; set; }
    
    public BaseApiEndpoint(IMediator mediator)
    {
        Mediator = mediator;
    }
    
}