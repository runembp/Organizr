using MediatR;
using Organizr.Application.Commands;
using Organizr.Application.Responses;
using Organizr.Core.Entities;
using Organizr.Core.Repositories;

namespace Organizr.Application.Handlers.CommandHandlers;

public class CreateUserGroupCommandHandler : IRequestHandler<CreateUserGroupCommand, CreateUserGroupResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserGroupCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateUserGroupResponse> Handle(CreateUserGroupCommand request, CancellationToken cancellationToken)
    {
        var response = new CreateUserGroupResponse { Succeeded = false };

        var groupNameAlreadyTaken = await _unitOfWork.UserGroupRepository.GroupExists(request.GroupName);

        if (groupNameAlreadyTaken)
        {
            return response;
        }

        var userGroup = new UserGroup
        {
            Name = request.GroupName,
            Open = request.GroupOpenForAll
        };

        var result = await _unitOfWork.UserGroupRepository.Add(userGroup);

        response.GroupName = result.Name;
        response.Succeeded = true;

        return response;
    }
}