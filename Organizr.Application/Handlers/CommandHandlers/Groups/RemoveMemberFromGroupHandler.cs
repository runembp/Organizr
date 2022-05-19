using MediatR;
using Organizr.Application.Commands.Groups;
using Organizr.Application.Common.Interfaces;
using Organizr.Application.Responses.Groups;

namespace Organizr.Application.Handlers.CommandHandlers.Groups;

public class RemoveMemberFromGroupHandler : IRequestHandler<RemoveMemberFromGroupCommand, RemoveMemberFromGroupResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoveMemberFromGroupHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<RemoveMemberFromGroupResponse> Handle(RemoveMemberFromGroupCommand command, CancellationToken cancellationToken)
    {
        var response = new RemoveMemberFromGroupResponse();
        var result = await _unitOfWork.GroupRepository.RemoveMemberFromGroup(command.GroupId, command.MemberId);

        if (result is null)
        {
            return response;
        }

        var membership = _unitOfWork.MembershipRepository.GetAll().Result.FirstOrDefault(x => x.MemberGroup.Id == command.GroupId && x.Member.Id == command.MemberId);

        if (membership is null)
        {
            return response;
        }
        
        await _unitOfWork.MembershipRepository.DeleteAsync(membership);
        response.Succeeded = true;
        return response;
    }
}