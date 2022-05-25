using MediatR;
using Microsoft.AspNetCore.Mvc;
using Organizr.Application.Requests.News;
using Organizr.Domain.Entities;
using Swashbuckle.AspNetCore.Annotations;

namespace Organizr.Api.Endpoints.Newsposts
{
    public class GetAllByGroupId : BaseApiEndpoint
    {
        public GetAllByGroupId(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("api/newsposts/groups/{groupId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<NewsPost>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerOperation(
            Summary = "Gets a list of all newsposts based on groupId",
            Tags = new[] { "NewsPosts" })]
        public async Task<IActionResult> Handle([FromRoute] int groupId)
        {
            if (groupId <= 0)
            {
                return BadRequest("Medlems id er ikke i et korrekt format");
            }

            var result = await Mediator.Send(new GetAllNewsPostsByGroupIdRequest { GroupId = groupId });

            if (result is null)
            {
                return BadRequest("Gruppen findes ikke");
            }

            return Ok(result);
        }
    }
}