using MediatR;
using Organizr.Domain.Entities;

namespace Organizr.Application.Requests.News;

public class GetAllPublicNewsPostsRequest : IRequest<List<NewsPost>>
{
}

