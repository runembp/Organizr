using AutoMapper;
using MediatR;
using Organizr.Application.Commands;
using Organizr.Application.Common.IRepositories;
using Organizr.Application.Responses;
using Organizr.Domain.Entities;

namespace Organizr.Application.Handlers.CommandHandlers;

public class CreateMemberGroupCommandHandler : IRequestHandler<CreateMemberGroupCommand, CreateMemberGroupResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateMemberGroupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CreateMemberGroupResponse> Handle(CreateMemberGroupCommand command, CancellationToken cancellationToken)
    {
        var response = new CreateMemberGroupResponse { Succeeded = false };

        var userGroup = _mapper.Map<MemberGroup>(command);

        if (userGroup is null)
        {
            return response;
        }

        var groupNameAlreadyTaken = await _unitOfWork.GroupRepository.GroupExists(command.Name);

        if (groupNameAlreadyTaken)
        {
            return response;
        }

        var result = await _unitOfWork.GroupRepository.Add(userGroup);

        response.GroupName = result.Name;
        response.Succeeded = true;

        return response;
    }
}