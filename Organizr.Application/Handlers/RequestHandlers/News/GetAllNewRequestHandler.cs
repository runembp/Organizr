using MediatR;
using Organizr.Application.Common.Interfaces;
using Organizr.Application.Requests.News;
using Organizr.Domain.Entities;

namespace Organizr.Application.Handlers.RequestHandlers.News;

public class GetAllNewRequestHandler : IRequestHandler<GetAllNewsRequest, List<Domain.Entities.NewsPost>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllNewRequestHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<NewsPost>> Handle(GetAllNewsRequest request, CancellationToken cancellationToken)
    {
        var news = await _unitOfWork.NewsRepository.GetAll();
        return (List<NewsPost>)news;
    }
}