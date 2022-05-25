﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Requests.Members;
using Organizr.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace Organizr.Api.Endpoints.Members;

public class GetWithMemberships : BaseApiEndpoint
{
    public GetWithMemberships(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpGet("api/members/{memberId:int}/groups")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Member))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerOperation(
        Summary = "Gets member with memberships by id",
        Tags = new [] {"Members"})]
    public async Task<IActionResult> Handle([FromRoute] int memberId)
    {
        if (memberId <= 0)
        {
            return BadRequest("Medlems id er ikke i et korrekt format");
        }

        var result = await Mediator.Send(new GetMemberWithMembershipsByIdRequest {MemberId = memberId});

        if (result is null)
        {
            return BadRequest("Medlemmet findes ikke");
        }

        return Ok(result);
    }
}