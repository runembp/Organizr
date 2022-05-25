using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Requests.Members;
using Organizr.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace Organizr.Api.Endpoints.Members;

public class GetByEmail : BaseApiEndpoint
{
    public GetByEmail(IMediator mediator) : base(mediator)
    {
    }
    
    [HttpGet("api/members/email/{memberEmail}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Member))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerOperation(
        Summary = "Get member by email",
        Tags = new [] {"MemberEndpoint"})]
    public async Task<IActionResult> Handle([FromRoute] string memberEmail)
    {
        if (string.IsNullOrWhiteSpace(memberEmail) || !new EmailAddressAttribute().IsValid(memberEmail))
        {
            return BadRequest("Medlems emailen er ikke i et korrekt format");
        }

        var result = await Mediator.Send(new GetMemberByEmailRequest {Email = memberEmail});

        if (result is null)
        {
            return BadRequest("Medlemmet findes ikke");
        }

        return Ok(result);
    }
}