using AutoMapper;
using MediatR;
using Organizr.Application.Commands;
using Organizr.Application.Responses;
using Organizr.Core.Entities;
using Organizr.Core.Repositories;

namespace Organizr.Application.Handlers.CommandHandlers;

public class CreateOrganizrUserHandler : IRequestHandler<CreateOrganizrUserCommand, OrganizrUserResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateOrganizrUserHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<OrganizrUserResponse> Handle(CreateOrganizrUserCommand request, CancellationToken cancellationToken)
    {
        var memberEntity = _mapper.Map<OrganizrUser>(request);
        if (memberEntity is null)
        {
            throw new ApplicationException("Issue with mapper");
        }
        var newOrganizrUser = await _unitOfWork.OrganizrUserRepository.Add(memberEntity);
        var memberResponse = _mapper.Map<OrganizrUserResponse>(newOrganizrUser);
        return memberResponse;
    }

}


