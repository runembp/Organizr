using MediatR;
using Organizr.Domain.Entities;

namespace Organizr.Application.Requests.News;

public class GetAllNewsPostsByGroupIdRequest : IRequest<List<NewsPost>>
{
    public int GroupId { get; set; }
}