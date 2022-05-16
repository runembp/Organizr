using MediatR;
using Organizr.Application.Commands.Groups;
using Organizr.Application.Common.Interfaces;
using Organizr.Application.Responses.Groups;

namespace Organizr.Application.Handlers.CommandHandlers.Groups;

public class RemoveMemberFromGroupHandler : IRequestHandler<RemoveMemberFromGroupCommand, RemoveMemberFromMemberGroupResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoveMemberFromGroupHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<RemoveMemberFromMemberGroupResponse> Handle(RemoveMemberFromGroupCommand command, CancellationToken cancellationToken)
    {
        var response = new RemoveMemberFromMemberGroupResponse();
        var result = await _unitOfWork.GroupRepository.RemoveMemberFromGroup(command.GroupId, command.MemberId);

        if (result is null)
        {
            return response;
        }

        response.Succeeded = true;
        return response;
    }
}