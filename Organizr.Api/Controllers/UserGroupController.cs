using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Requests.Groups;
using Organizr.Domain.Entities;

namespace Organizr.Api.Controllers;

[AllowAnonymous]
[ApiController]
[Route("api/groups")]
public class UserGroupController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserGroupController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<List<MemberGroup>> GetAll()
    {
        return await _mediator.Send(new GetAllMemberGroupsRequest());
    }
}