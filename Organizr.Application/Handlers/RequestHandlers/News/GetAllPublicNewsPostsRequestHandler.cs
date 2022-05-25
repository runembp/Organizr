using MediatR;
using Organizr.Application.Common.Interfaces;
using Organizr.Application.Requests.News;
using Organizr.Domain.Entities;

namespace Organizr.Application.Handlers.RequestHandlers.News;

public class GetAllPublicNewsPostsRequestHandler : IRequestHandler<GetAllPublicNewsPostsRequest, List<NewsPost>?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllPublicNewsPostsRequestHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<NewsPost>?> Handle(GetAllPublicNewsPostsRequest request, CancellationToken cancellationToken)
    {
        return await _unitOfWork.NewsRepository.GetAllPublicNewsPosts();    
    }
}