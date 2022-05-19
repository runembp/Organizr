using MediatR;
using Organizr.Application.Common.Interfaces;
using Organizr.Application.Requests.News;

namespace Organizr.Application.Handlers.RequestHandlers.News;

public class GetAllNewRequestHandler : IRequestHandler<GetAllNewsRequest, List<Domain.Entities.News>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllNewRequestHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<Domain.Entities.News>> Handle(GetAllNewsRequest request, CancellationToken cancellationToken)
    {
        var news = await _unitOfWork.NewsRepository.GetAll();
        return (List<Domain.Entities.News>)news;
    }
}