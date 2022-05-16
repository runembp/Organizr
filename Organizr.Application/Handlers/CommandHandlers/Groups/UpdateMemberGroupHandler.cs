using AutoMapper;
using MediatR;
using Organizr.Application.Commands.Groups;
using Organizr.Application.Common.Interfaces;
using Organizr.Application.Responses.Groups;
using Organizr.Domain.Entities;

namespace Organizr.Application.Handlers.CommandHandlers.Groups;

public class UpdateMemberGroupHandler : IRequestHandler<UpdateMemberGroupCommand, UpdateMemberGroupResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateMemberGroupHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<UpdateMemberGroupResponse> Handle(UpdateMemberGroupCommand command, CancellationToken cancellationToken)
    {
        var response = new UpdateMemberGroupResponse();
        
        var group = _mapper.Map<MemberGroup>(command);

        if (group is null)
        {
            response.Error = "Gruppe er ikke i korrekt format";
            return response;
        }
        
        var result = await _unitOfWork.GroupRepository.UpdateMemberGroup(group);

        if (result is null || result.Id <= 0)
        {
            response.Error = "Gruppe kunne ikke opdateres";
            return response;
        }

        response.Succeeded = true;
        return response;
    }
}