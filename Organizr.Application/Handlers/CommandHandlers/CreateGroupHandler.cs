using AutoMapper;
using MediatR;
using Organizr.Application.Commands;
using Organizr.Application.Responses;
using Organizr.Core.Entities;
using Organizr.Core.Repositories;

namespace Organizr.Application.Handlers.CommandHandlers;

public class CreateUserGroupCommandHandler : IRequestHandler<CreateUserGroupCommand, CreateUserGroupResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateUserGroupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CreateUserGroupResponse> Handle(CreateUserGroupCommand command, CancellationToken cancellationToken)
    {
        var response = new CreateUserGroupResponse { Succeeded = false };
        
        var userGroup = _mapper.Map<UserGroup>(command);

        if (userGroup is null)
        {
            return response;
        }

        var groupNameAlreadyTaken = await _unitOfWork.UserGroupRepository.GroupExists(command.GroupName);

        if (groupNameAlreadyTaken)
        {
            return response;
        }

        var result = await _unitOfWork.UserGroupRepository.Add(userGroup);

        response.GroupName = result.Name;
        response.Succeeded = true;

        return response;
    }
}