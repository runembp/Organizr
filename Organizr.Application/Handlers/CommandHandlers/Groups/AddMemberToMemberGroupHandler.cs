using AutoMapper;
using MediatR;
using Organizr.Application.Commands.Groups;
using Organizr.Application.Common.Interfaces;
using Organizr.Application.Responses.Groups;
using Organizr.Domain.Entities;

namespace Organizr.Application.Handlers.CommandHandlers.Groups;

public class AddMemberToMemberGroupHandler : IRequestHandler<AddMemberToMemberGroupCommand, AddMemberToMemberGroupResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AddMemberToMemberGroupHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<AddMemberToMemberGroupResponse> Handle(AddMemberToMemberGroupCommand request, CancellationToken cancellationToken)
    {
        var response = new AddMemberToMemberGroupResponse();

        var group = _mapper.Map<MemberGroup>(request);

        if (group is null) return response;

        var result = await _unitOfWork.GroupRepository.AddMemberToGroup(request.GroupId, request.MemberId);
        if (result is null) return response;

        response.Succeeded = true;

        return response;

    }
}