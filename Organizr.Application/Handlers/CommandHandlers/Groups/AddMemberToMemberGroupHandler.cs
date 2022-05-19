using AutoMapper;
using MediatR;
using Organizr.Application.Commands.Groups;
using Organizr.Application.Common.Interfaces;
using Organizr.Application.Responses.Groups;

namespace Organizr.Application.Handlers.CommandHandlers.Groups;

public class AddMemberToMemberGroupHandler : IRequestHandler<AddMemberToMemberGroupCommand, AddMemberToMemberGroupResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public AddMemberToMemberGroupHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<AddMemberToMemberGroupResponse> Handle(AddMemberToMemberGroupCommand request, CancellationToken cancellationToken)
    {
        var response = new AddMemberToMemberGroupResponse();
        
        var group = await _unitOfWork.GroupRepository.AddMemberToGroup(request.GroupId, request.MemberId);

        if (group is null || group.Id <= 0)
        {
            response.Error = "Der skete en fejl";
            return response;
        }
        
        var membership = await _unitOfWork.MembershipRepository.CreateNewMembership(request.GroupId, request.MemberId, 1);

        if (membership is null)
        {
            response.Error = "Medlemsskabet kunne ikke oprettes";
            return response;
        }
        
        response.Succeeded = true;
        return response;
    }
}