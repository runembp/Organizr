using MediatR;

namespace Organizr.Application.Requests.News;

public class GetAllNewsRequest : IRequest<List<Domain.Entities.News>>
{
}

