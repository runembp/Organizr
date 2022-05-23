using AutoMapper;
using MediatR;
using Organizr.Application.Commands.NewsPosts;
using Organizr.Application.Common.Interfaces;
using Organizr.Application.Responses.NewsPost;
using Organizr.Domain.Entities;

namespace Organizr.Application.Handlers.CommandHandlers.NewsPosts;

public class CreateNewsPostCommandHandler : IRequestHandler<CreateNewsPostCommand, CreateNewsPostResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateNewsPostCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateNewsPostResponse> Handle(CreateNewsPostCommand command, CancellationToken cancellationToken)
    {
        var response = new CreateNewsPostResponse();

        var result = await _unitOfWork.NewsRepository.AddNewsPost(command);

        if (result is null)
        {
            response.Error = "Gruppens Id eller medlemmets Id er ikke udfyldt korrekt.";
            return response;
        }

        response.Succeeded = true;
        response.CreatedNewsPost = result;
        return response;

    }
}