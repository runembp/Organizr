using MediatR;
using Organizr.Application.Commands.Groups;
using Organizr.Application.Common.Interfaces;
using Organizr.Domain.Entities;

namespace Organizr.Application.Handlers.CommandHandlers.Groups;

public class RemoveMemberFromGroupHandler : IRequestHandler<RemoveMemberFromGroupCommand, Member?>
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoveMemberFromGroupHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Member?> Handle(RemoveMemberFromGroupCommand command, CancellationToken cancellationToken)
    {
        return await _unitOfWork.GroupRepository.RemoveMemberFromGroup(command.GroupId, command.MemberId);
    }
}