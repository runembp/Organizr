using AutoMapper;
using MediatR;
using Organizr.Application.Commands.Groups;
using Organizr.Application.Common.Interfaces;
using Organizr.Application.Responses.Groups;
using Organizr.Domain.Entities;

namespace Organizr.Application.Handlers.CommandHandlers.Groups;

public class CreateGroupCommandHandler : IRequestHandler<CreateMemberGroupCommand, CreateMemberGroupResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateGroupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CreateMemberGroupResponse> Handle(CreateMemberGroupCommand command, CancellationToken cancellationToken)
    {
        var response = new CreateMemberGroupResponse();
        
        var group = _mapper.Map<MemberGroup>(command);

        if (group is null)
        {
            response.Error = "Gruppen er i et forkert format";
            return response;
        }

        if (await _unitOfWork.GroupRepository.GroupExists(command.Name))
        {
            response.Error = "Der findes allerede en gruppe med dette navn";
            return response;
        }

        var result = await _unitOfWork.GroupRepository.Add(group);

        if (result.Id <= 0)
        {
            response.Error = "Gruppen kunne ikke oprettes";
            return response;
        }

        response.Succeeded = true;
        response.CreatedGroup = result;
        return response;
    }
}