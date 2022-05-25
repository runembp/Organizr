using MediatR;
using Organizr.Application.Common.Interfaces;
using Organizr.Application.Requests.News;
using Organizr.Domain.Entities;

namespace Organizr.Application.Handlers.RequestHandlers.News;

public class GetAllNewsPostsByGroupIdRequestHandler : IRequestHandler<GetAllNewsPostsByGroupIdRequest, List<NewsPost>?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllNewsPostsByGroupIdRequestHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<NewsPost>?> Handle(GetAllNewsPostsByGroupIdRequest request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.NewsRepository.GetAllPublicNewsPosts();
    }
}

