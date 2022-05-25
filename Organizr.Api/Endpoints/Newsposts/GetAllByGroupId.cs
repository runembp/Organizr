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
        [SwaggerOperation(
       Summary = "Gets a list of all news posts",
       Tags = new[] { "NewsPosts" })]
        public async Task<IActionResult> Handle([FromRoute] int groupId)
        {
            var result = await Mediator.Send(new GetAllNewsPostsByGroupIdRequest { GroupId = groupId });
            return Ok(result);
        }
    }
}